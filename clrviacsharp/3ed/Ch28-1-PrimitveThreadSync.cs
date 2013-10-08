using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

public static class PrimitveThreadSync {
    public static void Main() {
        OptimizedAway();
        StrangeBehavior.Go();
        AsyncCoordinatorDemo.Go();
        LockComparison.Go();
        RegisteredWaitHandleDemo.Go();
    }

    private static void OptimizedAway() {
        // An expression of constants is computed at compile time then put into a local variable that is never used
        Int32 value = 1 * 100 + 0 / 1 % 2;
        if (value >= 0) Console.WriteLine("Jeff");

        for (Int32 x = 0; x < 1000; x++) ;   // A loop that does nothing
    }
}

#region LinkedList Synchronization
// This class is used by the LinkedList class
public class Node { internal Node m_next; }

public sealed class LinkedList {
    private Node m_head;

    public void Add(Node newNode) {
        // The two lines below perform very fast reference assignments
        newNode.m_next = m_head;
        m_head = newNode;
    }
}
#endregion

internal static class StrangeBehavior {
    // Compile with "/platform:x86 /o" and run it NOT under the debugger (Ctrl+F5)
    private static Boolean s_stopWorker = false;

    public static void Go() {
        Console.WriteLine("Main: letting worker run for 5 seconds");
        Thread t = new Thread(Worker);
        t.Start();
        Thread.Sleep(5000);
        s_stopWorker = true;
        Console.WriteLine("Main: waiting for worker to stop");
        t.Join();
        Environment.Exit(0);
    }

    private static void Worker(Object o) {
        Int32 x = 0;
        while (!s_stopWorker) x++;
        Console.WriteLine("Worker: stopped when x={0}", x);
    }
}

internal static class ThreadsSharingData {
    internal sealed class ThreadsSharingDataV1 {
        private Int32 m_flag = 0;
        private Int32 m_value = 0;

        // This method is executed by one thread 
        public void Thread1() {
            // Note: These could execute in reverse order
            m_value = 5;
            m_flag = 1;
        }

        // This method is executed by another thread 
        public void Thread2() {
            // Note: m_value could be read before m_flag
            if (m_flag == 1) Console.WriteLine(m_value);
        }
    }

    internal sealed class ThreadsSharingDataV2 {
        private Int32 m_flag = 0;
        private Int32 m_value = 0;

        // This method is executed by one thread 
        public void Thread1() {
            // Note: 5 must be written to m_value before 1 is written to m_flag
            m_value = 5;
            Thread.VolatileWrite(ref m_flag, 1);
        }

        // This method is executed by another thread 
        public void Thread2() {
            // Note: m_value must be read after m_flag is read 
            if (Thread.VolatileRead(ref m_flag) == 1)
                Console.WriteLine(m_value);
        }
    }

    internal sealed class ThreadsSharingDataV3 {
        private volatile Int32 m_flag = 0;
        private Int32 m_value = 0;

        // This method is executed by one thread 
        public void Thread1() {
            // Note: 5 must be written to m_value before 1 is written to m_flag
            m_value = 5;
            m_flag = 1;
        }

        // This method is executed by another thread 
        public void Thread2() {
            // Note: m_value must be read after m_flag is read 
            if (m_flag == 1)
                Console.WriteLine(m_value);
        }
    }
}

internal static class AsyncCoordinatorDemo {
    public static void Go() {
        Int32 timeout = 5000;   // Change to desired timeout
        MultiWebRequests act = new MultiWebRequests(timeout);
        Console.WriteLine("All requests issued (Timeout={0}). Hit enter to Cancel.",
           (timeout == Timeout.Infinite) ? "Infinite" : (timeout.ToString() + "ms"));
        Console.ReadLine();
        act.Cancel();

        Console.WriteLine();
        Console.WriteLine("Hit enter to terminate.");
        Console.ReadLine();
    }

    private sealed class MultiWebRequests {
        // This helper class coordinates all the asynchronous operations
        private AsyncCoordinator m_ac = new AsyncCoordinator();

        // This is the set of Web servers we want to query
        private WebRequest[] m_requests = new WebRequest[] {
            WebRequest.Create("http://Wintellect.com/"),
            WebRequest.Create("http://Microsoft.com/"),
            WebRequest.Create("http://1.1.1.1/")
        };

        // This contains the result of each Web server's operation
        private Object[] m_results;   // Either a WebResponse or an Exception

        public MultiWebRequests(Int32 timeout = Timeout.Infinite) {
            // Create the response array: one response for each request
            m_results = new Object[m_requests.Length];

            // Asynchronously initiate all the requests all at once
            for (Int32 n = 0; n < m_requests.Length; n++) {
                m_ac.AboutToBegin(1);
                m_requests[n].BeginGetResponse(EndGetResponse, n);
            }

            // Tell the helper class that all operations have been initiated
            // and to call AllDone when all operations complete, Cancel is 
            // called, or the timeout occurs
            m_ac.AllBegun(AllDone, timeout);
        }

        // Calling this method indicates that the results don't matter anymore
        public void Cancel() { m_ac.Cancel(); }

        // As each Web server responds, this method is called
        private void EndGetResponse(IAsyncResult result) {
            // Get the index corresponding to the request
            Int32 n = (Int32)result.AsyncState;
            try {
                // Store the response in the same index as the request
                m_results[n] = m_requests[n].EndGetResponse(result);
            }
            catch (WebException e) {
                // If an error occurred, store the exception instead
                m_results[n] = e;
            }
            // Tell the helper class that a Web server responded
            m_ac.JustEnded();
        }

        // This method is called after all Web servers respond, 
        // Cancel is called, or the timeout occurs
        private void AllDone(CoordinationStatus result) {
            switch (result) {
                case CoordinationStatus.Cancel:
                    Console.WriteLine("The operation was canceled");
                    break;

                case CoordinationStatus.Timeout:
                    Console.WriteLine("The operation timed-out");
                    break;

                case CoordinationStatus.AllDone:
                    Console.WriteLine("Here are the results from all the Web servers");
                    for (Int32 n = 0; n < m_requests.Length; n++) {
                        WebResponse response = m_results[n] as WebResponse;
                        if (response != null) {
                            Console.WriteLine("{0} returned {1} bytes.",
                               response.ResponseUri, response.ContentLength);
                        } else {
                            Exception e = m_results[n] as Exception;
                            if (e != null) {
                                Console.WriteLine("{0} failed due to {1}.",
                                   m_requests[n].RequestUri, e.Message);
                            }
                        }
                    }
                    break;
            }
        }
    }

    private enum CoordinationStatus {
        AllDone,
        Timeout,
        Cancel
    };

    private sealed class AsyncCoordinator {
        private Int32 m_opCount = 1;        // Decremented by AllBegun
        private Int32 m_statusReported = 0; // 0=false, 1=true
        private Action<CoordinationStatus> m_callback;
        private Timer m_timer;

        // This method MUST be called BEFORE calling a BeginXxx method
        public void AboutToBegin(Int32 opsToAdd = 1) {
            Interlocked.Add(ref m_opCount, opsToAdd);
        }

        // This method MUST be called AFTER calling an EndXxx method
        public void JustEnded() {
            if (Interlocked.Decrement(ref m_opCount) == 0)
                ReportStatus(CoordinationStatus.AllDone);
        }

        // This method MUST be called AFTER calling ALL BeginXxx methods
        public void AllBegun(Action<CoordinationStatus> callback, Int32 timeout = Timeout.Infinite) {
            m_callback = callback;
            if (timeout != Timeout.Infinite) {
                m_timer = new Timer(TimeExpired, null, timeout, Timeout.Infinite);
            }
            JustEnded();
        }

        private void TimeExpired(Object o) { ReportStatus(CoordinationStatus.Timeout); }

        public void Cancel() {
            if (m_callback == null)
                throw new InvalidOperationException("Cancel cannot be called before AllBegun");
            ReportStatus(CoordinationStatus.Cancel);
        }

        private void ReportStatus(CoordinationStatus status) {
            if (m_timer != null) {  // If timer is still in play, kill it
                Timer timer = Interlocked.Exchange(ref m_timer, null);
                if (timer != null) timer.Dispose();
            }

            // If status has never been reported, report it; else ignore it
            if (Interlocked.Exchange(ref m_statusReported, 1) == 0)
                m_callback(status);
        }
    }
}

internal static class LockComparison {
    public static void Go() {
        Int32 x = 0;
        const Int32 iterations = 10000000;  // 10 million

        // How long does it take to increment x 10 million times?
        Stopwatch sw = Stopwatch.StartNew();
        for (Int32 i = 0; i < iterations; i++) {
            x++;
        }
        Console.WriteLine("Incrementing x: {0:N0}", sw.ElapsedMilliseconds);

        // How long does it take to increment x 10 million times 
        // adding the overhead of calling a method that does nothing?
        sw.Restart();
        for (Int32 i = 0; i < iterations; i++) {
            M(); x++; M();
        }
        Console.WriteLine("Incrementing x in M: {0:N0}", sw.ElapsedMilliseconds);

        // How long does it take to increment x 10 million times 
        // adding the overhead of calling an uncontended SimpleSpinLock?
        SimpleSpinLock ssl = new SimpleSpinLock();
        sw.Restart();
        for (Int32 i = 0; i < iterations; i++) {
            ssl.Enter(); x++; ssl.Leave();
        }
        Console.WriteLine("Incrementing x in SimpleSpinLock: {0:N0}", sw.ElapsedMilliseconds);

        // How long does it take to increment x 10 million times 
        // adding the overhead of calling an uncontended SimpleWaitLock?
        using (SimpleWaitLock swl = new SimpleWaitLock()) {
            sw.Restart();
            for (Int32 i = 0; i < iterations; i++) {
                swl.Enter(); x++; swl.Leave();
            }
            Console.WriteLine("Incrementing x in SimpleWaitLock: {0:N0}", sw.ElapsedMilliseconds);
        }
        Console.ReadLine();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void M() { }

    private struct SimpleSpinLock {
        private Int32 m_ResourceInUse;	// 0=false (default), 1=true

        public void Enter() {
            // Set the resource to in-use and if this thread 
            // changed it from Free, then return
            while (Interlocked.Exchange(ref m_ResourceInUse, 1) != 0) {
                /* Black Magic goes here... */
            }
        }

        public void Leave() {
            // Mark the resource as Free
            Thread.VolatileWrite(ref m_ResourceInUse, 0);
        }
    }

    private sealed class SimpleWaitLock : IDisposable {
        private AutoResetEvent m_ResourceFree = new AutoResetEvent(true); // Initially free

        public void Enter() {
            // Block efficiently in the kernel for the resource to be free, then return
            m_ResourceFree.WaitOne();
        }

        public void Leave() {
            m_ResourceFree.Set();// Mark the resource as Free
        }

        public void Dispose() { m_ResourceFree.Dispose(); }
    }
}

internal sealed class RecursiveAutoResetEvent : IDisposable {
    private AutoResetEvent m_lock = new AutoResetEvent(true);
    private Int32 m_owningThreadId = 0;
    private Int32 m_recursionCount = 0;

    public void Enter() {
        // Obtain the calling thread's unique Int32 ID
        Int32 currentThreadId = Thread.CurrentThread.ManagedThreadId;

        // If the calling thread owns the lock, increment the recursion count
        if (m_owningThreadId == currentThreadId) {
            m_recursionCount++;
            return;
        }

        // The calling thread doesn't own the lock, wait for it
        m_lock.WaitOne();

        // The calling now owns the lock, initialize the owning thread ID & recursion count
        m_owningThreadId = currentThreadId;
        m_recursionCount--;
    }

    public void Leave() {
        // If the calling thread doesn't own the lock, we have an error
        if (m_owningThreadId != Thread.CurrentThread.ManagedThreadId)
            throw new InvalidOperationException();

        // Subtract 1 from the recursion count
        if (--m_recursionCount == 0) {
            // If the recursion count is 0, then no thread owns the lock
            m_owningThreadId = 0;
            m_lock.Set();   // Wake up 1 waiting thread (if any)
        }
    }

    public void Dispose() { m_lock.Dispose(); }
}

internal static class RegisteredWaitHandleDemo {
    public static void Go() {
        // Construct an AutoResetEvent (initially false)
        AutoResetEvent are = new AutoResetEvent(false);

        // Tell the thread pool to wait on the AutoResetEvent
        RegisteredWaitHandle rwh = ThreadPool.RegisterWaitForSingleObject(
           are,             // Wait on this AutoResetEvent
           EventOperation,  // When available, call the EventOperation method
           null,            // Pass null to EventOperation
           5000,            // Wait 5 seconds for the event to become true
           false);          // Call EventOperation everytime the event is true

        // Start our loop
        Char operation = (Char)0;
        while (operation != 'Q') {
            Console.WriteLine("S=Signal, Q=Quit?");
            operation = Char.ToUpper(Console.ReadKey(true).KeyChar);
            if (operation == 'S') are.Set(); // User want to set the event
        }

        // Tell the thread pool to stop waiting on the event
        rwh.Unregister(null);
    }

    // This method is called whenever the event is true or
    // when 5 seconds have elapsed since the last callback/timeout
    private static void EventOperation(Object state, Boolean timedOut) {
        Console.WriteLine(timedOut ? "Timeout" : "Event became true");
    }
}




