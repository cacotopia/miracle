using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;

public static class HybridThreadSync {
    public static void Main() {
        HybridLocks.Go();
        Singletons.Go();
        WriterGateDemo.Go();
        BlockingCollectionDemo.Go();
    }
}

internal static class HybridLocks {
    public static void Go() {
        Int32 x = 0;
        const Int32 iterations = 10000000;  // 10 million

        // How long does it take to increment x 10 million times 
        // adding the overhead of calling an uncontended SimpleHybridLock?
        var shl = new SimpleHybridLock();
        shl.Enter(); x++; shl.Leave();
        Stopwatch sw = Stopwatch.StartNew();
        for (Int32 i = 0; i < iterations; i++) {
            shl.Enter(); x++; shl.Leave();
        }
        Console.WriteLine("Incrementing x in SimpleHybridLock: {0:N0}", sw.ElapsedMilliseconds);

        // How long does it take to increment x 10 million times 
        // adding the overhead of calling an uncontended ANotherHybridLock?
        using (var ahl = new AnotherHybridLock()) {
            ahl.Enter(); x++; ahl.Leave();
            sw.Restart();
            for (Int32 i = 0; i < iterations; i++) {
                ahl.Enter(); x++; ahl.Leave();
            }
            Console.WriteLine("Incrementing x in AnotherHybridLock: {0:N0}", sw.ElapsedMilliseconds);
        }

        using (var oml = new OneManyLock()) {
            oml.Enter(true); x++; oml.Leave(true);
            sw.Restart();
            for (Int32 i = 0; i < iterations; i++) {
                oml.Enter(true); x++; oml.Leave(true);
            }
            Console.WriteLine("Incrementing x in OneManyLock: {0:N0}", sw.ElapsedMilliseconds);
        }

        using (var rwls = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion)) {
            rwls.EnterReadLock(); x++; rwls.ExitReadLock();
            sw.Restart();
            for (Int32 i = 0; i < iterations; i++) {
                rwls.EnterReadLock(); x++; rwls.ExitReadLock();
            }
            Console.WriteLine("Incrementing x in ReaderWriterLockSlim: {0:N0}", sw.ElapsedMilliseconds);
        }

        var rwl = new ReaderWriterLock();
        rwl.AcquireReaderLock(Timeout.Infinite); x++; rwl.ReleaseReaderLock();
        sw.Restart();
        for (Int32 i = 0; i < iterations; i++) {
            rwl.AcquireReaderLock(Timeout.Infinite); x++; rwl.ReleaseReaderLock();
        }
        Console.WriteLine("Incrementing x in ReaderWriterLock: {0:N0}", sw.ElapsedMilliseconds);

        Object l = new Object();
        Monitor.Enter(l); x++; Monitor.Exit(l);
        sw.Restart();
        for (Int32 i = 0; i < iterations; i++) {
            Monitor.Enter(l); x++; Monitor.Exit(l);
        }
        Console.WriteLine("Incrementing x in Monitor: {0:N0}", sw.ElapsedMilliseconds);

        sw.Restart();
        for (Int32 i = 0; i < iterations; i++) {
            lock (l) { x++; }
        }
        Console.WriteLine("Incrementing x in lock: {0:N0}", sw.ElapsedMilliseconds);
        Console.ReadLine();
    }

    public sealed class SimpleHybridLock : IDisposable {
        // The Int32 is used by the primitive user-mode constructs (Interlocked mehtods)
        private Int32 m_waiters = 0;

        // The AutoResetEvent is the primitive kernel-mode construct
        private AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        public void Enter() {
            // Indicate that this thread wants the lock
            if (Interlocked.Increment(ref m_waiters) == 1)
                return; // Lock was free, no contention, just return

            // Another thread is waiting. There is contention, block this thread
            m_waiterLock.WaitOne();  // Bad performance hit here
            // When WaitOne returns, this thread now has the lock
        }

        public void Leave() {
            // This thread is releasing the lock
            if (Interlocked.Decrement(ref m_waiters) == 0)
                return; // No other threads are blocked, just return

            // Other threads are blocked, wake 1 of them
            m_waiterLock.Set();  // Bad performance hit here
        }

        public void Dispose() { m_waiterLock.Dispose(); }
    }

    public sealed class AnotherHybridLock : IDisposable {
        // The Int32 is used by the primitive user-mode constructs (Interlocked methods)
        private Int32 m_waiters = 0;

        // The AutoResetEvent is the primitive kernel-mode construct
        private AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        // This field controls spinning in an effort to improve performance
        private Int32 m_spincount = 4000;   // Arbitrarily chosen count

        // These fields indicate which thread owns the lock and how many times it owns it
        private Int32 m_owningThreadId = 0, m_recursion = 0;

        public void Enter() {
            // If the calling thread already owns this lock, increment the recursion count and return
            Int32 threadId = Thread.CurrentThread.ManagedThreadId;
            if (threadId == m_owningThreadId) { m_recursion++; return; }

            // The calling thread doesn't own the lock, try to get it
            SpinWait spinwait = new SpinWait();
            for (Int32 spinCount = 0; spinCount < m_spincount; spinCount++) {
                // If the lock was free, this thread got it; set some state and return
                if (Interlocked.CompareExchange(ref m_waiters, 1, 0) == 0) goto GotLock;

                // Black magic: give others threads a chance to run 
                // in hopes that the lock will be released
                spinwait.SpinOnce();
            }

            // Spinning is over and the lock was still not obtained, try one more time
            if (Interlocked.Increment(ref m_waiters) > 1) {
                // Other threads are blocked and this thread must block too
                m_waiterLock.WaitOne(); // Wait for the lock; performance hit
                // When this thread wakes, it owns the lock; set some state and return
            }

        GotLock:
            // When a thread gets the lock, we record its ID and 
            // indicate that the thread owns the lock once
            m_owningThreadId = threadId; m_recursion = 1;
        }

        public void Leave() {
            // If the calling thread doesn't own the lock, there is a bug
            Int32 threadId = Thread.CurrentThread.ManagedThreadId;
            if (threadId != m_owningThreadId)
                throw new SynchronizationLockException("Lock not owned by calling thread");

            // Decrement the recursion count. If this thread still owns the lock, just return
            if (--m_recursion > 0) return;

            m_owningThreadId = 0;   // No thread owns the lock now

            // If no other threads are blocked, just return
            if (Interlocked.Decrement(ref m_waiters) == 0)
                return;

            // Other threads are blocked, wake 1 of them
            m_waiterLock.Set();	// Bad performance hit here
        }

        public void Dispose() { m_waiterLock.Dispose(); }
    }

    private sealed class Transactions : IDisposable {
        private readonly ReaderWriterLockSlim m_lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private DateTime m_timeOfLastTrans;

        public void PerformTransaction() {
            m_lock.EnterWriteLock();
            // This code has exclusive access to the data...
            m_timeOfLastTrans = DateTime.Now;
            m_lock.ExitWriteLock();
        }

        public DateTime LastTransaction {
            get {
                m_lock.EnterReadLock();
                // This code has shared access to the data...
                DateTime temp = m_timeOfLastTrans;
                m_lock.ExitReadLock();
                return temp;
            }
        }
        public void Dispose() { m_lock.Dispose(); }
    }


    public sealed class OneManyLock : IDisposable {
        #region Lock State Management
#if false
      private struct BitField {
         private Int32 m_mask, m_1, m_startBit;
         public BitField(Int32 startBit, Int32 numBits) {
            m_startBit = startBit;
            m_mask = unchecked((Int32)((1 << numBits) - 1) << startBit);
            m_1 = unchecked((Int32)1 << startBit);
         }
         public void Increment(ref Int32 value) { value += m_1; }
         public void Decrement(ref Int32 value) { value -= m_1; }
         public void Decrement(ref Int32 value, Int32 amount) { value -= m_1 * amount; }
         public Int32 Get(Int32 value) { return (value & m_mask) >> m_startBit; }
         public Int32 Set(Int32 value, Int32 fieldValue) { return (value & ~m_mask) | (fieldValue << m_startBit); }
      }

      private static BitField s_state = new BitField(0, 3);
      private static BitField s_readersReading = new BitField(3, 9);
      private static BitField s_readersWaiting = new BitField(12, 9);
      private static BitField s_writersWaiting = new BitField(21, 9);
      private static OneManyLockStates State(Int32 value) { return (OneManyLockStates)s_state.Get(value); }
      private static void State(ref Int32 ls, OneManyLockStates newState) {
         ls = s_state.Set(ls, (Int32)newState);
      }
#endif

        private enum OneManyLockStates {
            Free = 0x00000000,
            OwnedByWriter = 0x00000001,
            OwnedByReaders = 0x00000002,
            OwnedByReadersAndWriterPending = 0x00000003,
            ReservedForWriter = 0x00000004,
        }

        private const Int32 c_lsStateStartBit = 0;
        private const Int32 c_lsReadersReadingStartBit = 3;
        private const Int32 c_lsReadersWaitingStartBit = 12;
        private const Int32 c_lsWritersWaitingStartBit = 21;

        // Mask = unchecked((Int32) ((1 << numBits) - 1) << startBit);
        private const Int32 c_lsStateMask = unchecked((Int32)((1 << 3) - 1) << c_lsStateStartBit);
        private const Int32 c_lsReadersReadingMask = unchecked((Int32)((1 << 9) - 1) << c_lsReadersReadingStartBit);
        private const Int32 c_lsReadersWaitingMask = unchecked((Int32)((1 << 9) - 1) << c_lsReadersWaitingStartBit);
        private const Int32 c_lsWritersWaitingMask = unchecked((Int32)((1 << 9) - 1) << c_lsWritersWaitingStartBit);

        // FirstBit = unchecked((Int32) 1 << startBit);
        private const Int32 c_ls1ReaderReading = unchecked((Int32)1 << c_lsReadersReadingStartBit);
        private const Int32 c_ls1ReaderWaiting = unchecked((Int32)1 << c_lsReadersWaitingStartBit);
        private const Int32 c_ls1WriterWaiting = unchecked((Int32)1 << c_lsWritersWaitingStartBit);

        private static OneManyLockStates State(Int32 ls) {
            return (OneManyLockStates)(ls & c_lsStateMask);
        }
        private static void State(ref Int32 ls, OneManyLockStates newState) {
            ls = (ls & ~c_lsStateMask) | ((Int32)newState);
        }

        private static Int32 NumReadersReading(Int32 ls) { return (ls & c_lsReadersReadingMask) >> c_lsReadersReadingStartBit; }
        private static void IncReadersReading(ref Int32 ls) { ls += c_ls1ReaderReading; }
        private static void DecReadersReading(ref Int32 ls) { ls -= c_ls1ReaderReading; }

        private static Int32 NumReadersWaiting(Int32 ls) { return (ls & c_lsReadersWaitingMask) >> c_lsReadersWaitingStartBit; }
        private static void IncReadersWaiting(ref Int32 ls) { ls += c_ls1ReaderWaiting; }
        private static void DecReadersWaiting(ref Int32 ls, Int32 amount) { ls -= c_ls1ReaderWaiting * amount; }

        private static Int32 NumWritersWaiting(Int32 ls) { return (ls & c_lsWritersWaitingMask) >> c_lsWritersWaitingStartBit; }
        private static void IncWritersWaiting(ref Int32 ls) { ls += c_ls1WriterWaiting; }
        private static void DecWritersWaiting(ref Int32 ls) { ls -= c_ls1WriterWaiting; }

        private enum WakeUp { None, Writer, Readers }
        private Int32 NumWritersToWake() {
            Int32 ls = m_LockState;

            // If lock is RFW && WW>0, try to subtract 1 writer
            while ((State(ls) == OneManyLockStates.ReservedForWriter) && (NumWritersWaiting(ls) > 0)) {
                Int32 desired = ls;
                DecWritersWaiting(ref desired);
                if (InterlockedEx.IfThen(ref m_LockState, ls, desired, out ls)) {
                    // We sucessfully subtracted 1 waiting writer, wake it up
                    return 1;
                }
            }
            return 0;
        }

        private static class InterlockedEx {
            public static Boolean IfThen(ref Int32 value, Int32 @if, Int32 then, out Int32 previousValue) {
                previousValue = Interlocked.CompareExchange(ref value, then, @if);
                return (previousValue == @if);
            }
        }

        private Int32 NumReadersToWake() {
            Int32 ls = m_LockState, numReadersWaiting;

            // If lock is Free && RW>0, try to subtract all readers
            while ((State(ls) == OneManyLockStates.Free) && ((numReadersWaiting = NumReadersWaiting(ls)) > 0)) {
                Int32 desired = ls;
                DecReadersWaiting(ref desired, numReadersWaiting);
                if (InterlockedEx.IfThen(ref m_LockState, ls, desired, out ls)) {
                    // We sucessfully subtracted all waiting readers, wake them up
                    return numReadersWaiting;
                }
            }
            return 0;
        }

        /// <summary>
        /// Returns a string representing the state of the object.
        /// </summary>
        /// <returns>The string representing the state of the object.</returns>
        public override string ToString() {
            Int32 ls = m_LockState;
            return String.Format(System.Globalization.CultureInfo.InvariantCulture,
               "State={0}, RR={1}, RW={2}, WW={3}", State(ls),
               NumReadersReading(ls), NumReadersWaiting(ls),
               NumWritersWaiting(ls));
        }
        #endregion

        #region State Fields
        private Int32 m_LockState = (Int32)OneManyLockStates.Free;

        // Readers wait on this if a writer owns the lock
        private Semaphore m_ReadersLock = new Semaphore(0, Int32.MaxValue);

        // Writers wait on this if a reader owns the lock
        private AutoResetEvent m_WritersLock = new AutoResetEvent(false);
        #endregion

        #region Construction and Dispose
        /// <summary>Constructs a OneManyLock object.</summary>
        public OneManyLock() : base() { }

        /// <summary>Allow the object to clean itself up.</summary>
        /// <param name="disposing">true if the object is being disposed; false if it is being finalzied.</param>
        public void Dispose() {
            m_WritersLock.Close(); m_WritersLock = null;
            m_ReadersLock.Close(); m_ReadersLock = null;
        }
        #endregion

        #region Writer members
        /// <summary>
        /// Implements the ResourceLock's WaitToWrite behavior.
        /// </summary>
        public void Enter(Boolean exclusive) {
            if (exclusive) {
                while (WaitToWrite(ref m_LockState)) m_WritersLock.WaitOne();
            } else {
                while (WaitToRead(ref m_LockState)) m_ReadersLock.WaitOne();
            }
        }

        private static Boolean WaitToWrite(ref Int32 target) {
            Int32 i, j = target;
            Boolean wait;
            do {
                i = j;
                Int32 desired = i;
                wait = false;

                switch (State(desired)) {
                    case OneManyLockStates.Free:  // If Free -> OBW, return
                    case OneManyLockStates.ReservedForWriter: // If RFW -> OBW, return
                        State(ref desired, OneManyLockStates.OwnedByWriter);
                        break;

                    case OneManyLockStates.OwnedByWriter:  // If OBW -> WW++, wait & loop around
                        IncWritersWaiting(ref desired);
                        wait = true;
                        break;

                    case OneManyLockStates.OwnedByReaders: // If OBR or OBRAWP -> OBRAWP, WW++, wait, loop around
                    case OneManyLockStates.OwnedByReadersAndWriterPending:
                        State(ref desired, OneManyLockStates.OwnedByReadersAndWriterPending);
                        IncWritersWaiting(ref desired);
                        wait = true;
                        break;
                    default:
                        Debug.Assert(false, "Invalid Lock state");
                        break;
                }
                j = Interlocked.CompareExchange(ref target, desired, i);
            } while (i != j);
            return wait;
        }

        /// <summary>
        /// Implements the ResourceLock's OnDone behavior.
        /// </summary>
        public void Leave(Boolean write) {
            if (write) {
                Debug.Assert((State(m_LockState) == OneManyLockStates.OwnedByWriter) && (NumReadersReading(m_LockState) == 0));
                // Pre-condition:  Lock's state must be OBW (not Free/OBR/OBRAWP/RFW)
                // Post-condition: Lock's state must become Free or RFW (the lock is never passed)

                // Phase 1: Release the lock
                WakeUp wakeup = DoneWriting(ref m_LockState);

                // Phase 2: Possibly wake waiters
                switch (wakeup) {
                    case WakeUp.None:
                        break;
                    case WakeUp.Readers:
                        Int32 numReadersToWake = NumReadersToWake();
                        if (numReadersToWake > 0) m_ReadersLock.Release(numReadersToWake);
                        break;
                    case WakeUp.Writer:
                        Int32 numWritersToWake = NumWritersToWake();
                        Debug.Assert(numWritersToWake < 2);
                        if (numWritersToWake > 0) m_WritersLock.Set();
                        break;
                }
            } else {
                Debug.Assert((State(m_LockState) == OneManyLockStates.OwnedByReaders) || (State(m_LockState) == OneManyLockStates.OwnedByReadersAndWriterPending));
                // Pre-condition:  Lock's state must be OBR/OBRAWP (not Free/OBW/RFW)
                // Post-condition: Lock's state must become unchanged, Free or RFW (the lock is never passed)

                // Phase 1: Release the lock
                WakeUp wakeup = DoneReading(ref m_LockState);

                // Phase 2: Possibly wake a waiting writer
                switch (wakeup) {
                    case WakeUp.None:
                        break;
                    case WakeUp.Readers:
                        Debug.Assert(false);
                        break;
                    case WakeUp.Writer:
                        Int32 numWritersToWake = NumWritersToWake();
                        Debug.Assert(numWritersToWake < 2); // Must be 0 or 1
                        if (numWritersToWake > 0) m_WritersLock.Set();
                        break;
                }
            }
        }

        private static WakeUp DoneWriting(ref Int32 target) {
            Int32 i, j = target;
            WakeUp wakeup = WakeUp.None;
            do {
                i = j;
                Int32 desired = i;

                // if WW=0 && RW=0 -> Free
                if ((NumWritersWaiting(desired) == 0) && (NumReadersWaiting(desired) == 0)) {
                    State(ref desired, OneManyLockStates.Free);
                } else {
                    // if WW>0 && RW=0 -> RFW, possibly release a writer
                    if ((NumWritersWaiting(desired) > 0) && (NumReadersWaiting(desired) == 0)) {
                        State(ref desired, OneManyLockStates.ReservedForWriter);
                        wakeup = WakeUp.Writer;
                    } else {
                        // if WW>0 && RW>0 -> RFW, possibly release a writer
                        if ((NumWritersWaiting(desired) > 0) && (NumReadersWaiting(desired) > 0)) {
                            // JMR: Merge with above - is this even possible?
                            State(ref desired, OneManyLockStates.ReservedForWriter);
                            wakeup = WakeUp.Writer;
                        } else {
                            // if WW=0 && RW>0 -> Free, possibly release readers
                            if ((NumWritersWaiting(desired) == 0) && (NumReadersWaiting(desired) > 0)) {
                                State(ref desired, OneManyLockStates.Free);
                                wakeup = WakeUp.Readers;
                            } else {
                                Debug.Assert(false, "Invalid Lock state");
                            }
                        }
                    }
                }
                j = Interlocked.CompareExchange(ref target, desired, i);
            } while (i != j);
            return wakeup;
        }
        #endregion

        #region Reader members
        private static Boolean WaitToRead(ref Int32 target) {
            Int32 i, j = target;
            Boolean wait;
            do {
                i = j;
                Int32 desired = i;
                wait = false;

                switch (State(desired)) {
                    case OneManyLockStates.Free:  // If Free->OBR, RR=1, return
                        State(ref desired, OneManyLockStates.OwnedByReaders);
                        IncReadersReading(ref desired);
                        break;

                    case OneManyLockStates.OwnedByReaders: // If OBR -> RR++, return
                        IncReadersReading(ref desired);
                        break;

                    case OneManyLockStates.OwnedByWriter:  // If OBW/OBRAWP/RFW -> RW++, wait, loop around
                    case OneManyLockStates.OwnedByReadersAndWriterPending:
                    case OneManyLockStates.ReservedForWriter:
                        IncReadersWaiting(ref desired);
                        wait = true;
                        break;

                    default:
                        Debug.Assert(false, "Invalid Lock state");
                        break;
                }
                j = Interlocked.CompareExchange(ref target, desired, i);
            } while (i != j);
            return wait;
        }

        private static WakeUp DoneReading(ref Int32 target) {
            Int32 i, j = target;
            WakeUp wakeup = WakeUp.None;
            do {
                i = j;
                Int32 desired = i;
                DecReadersReading(ref desired);  // RR--

                // if RR>0 -> readers still reading, return
                if (NumReadersReading(desired) > 0) {
                } else { // No more readers reading
                    // if WW>0 -> RFW, return
                    if (NumWritersWaiting(desired) > 0) {
                        State(ref desired, OneManyLockStates.ReservedForWriter);
                        wakeup = WakeUp.Writer;
                    } else {
                        // All readers left and No waiting writers
                        State(ref desired, OneManyLockStates.Free);
                    }
                }
                j = Interlocked.CompareExchange(ref target, desired, i);
            } while (i != j);
            return wakeup;
        }
        #endregion
    }
}

internal static class Singletons {
    public static class V1 {
        public sealed class Singleton {
            // s_lock is required for thread safety and having this object assumes that creating  
            // the singleton object is more expensive than creating a System.Object object and that 
            // creating the singleton object may not be necessary at all. Otherwise, it is more  
            // efficient and easier to just create the singleton object in a class constructor
            private static readonly Object s_lock = new Object();

            // This field will refer to the one Singleton object
            private static Singleton s_value = null;

            // Private constructor prevents any code outside this class from creating an instance 
            private Singleton() { /* ... */ }

            // Public, static method that returns the Singleton object (creating it if necessary) 
            public static Singleton GetSingleton() {
                // If the Singleton was already created, just return it (this is fast)
                if (s_value != null) return s_value;

                Monitor.Enter(s_lock);  // Not created, let 1 thread create it
                if (s_value == null) {
                    // Still not created, create it
                    Singleton temp = new Singleton();

                    // Save the reference in s_value (see discussion for details)
                    Interlocked.Exchange(ref s_value, temp);
                }
                Monitor.Exit(s_lock);

                // Return a reference to the one Singleton object 
                return s_value;
            }
        }
    }

    public static class V2 {
        public sealed class Singleton {
            private static Singleton s_value = new Singleton();

            // Private constructor prevents any code outside this class from creating an instance 
            private Singleton() { }

            // Public, static method that returns the Singleton object (creating it if necessary) 
            public static Singleton GetSingleton() { return s_value; }
        }
    }

    public static class V3 {
        public sealed class Singleton {
            private static Singleton s_value = null;

            // Private constructor prevents any code outside this class from creating an instance 
            private Singleton() { }

            // Public, static method that returns the Singleton object (creating it if necessary) 
            public static Singleton GetSingleton() {
                if (s_value != null) return s_value;

                // Create a new Singleton and root it if another thread didn’t do it first
                Singleton temp = new Singleton();
                Interlocked.CompareExchange(ref s_value, temp, null);

                // If this thread lost, then the second Singleton object gets GC’d

                return s_value; // Return reference to the single object
            }
        }
    }

    public static void Go() {
        Lazy<String> s = new Lazy<String>(() => DateTime.Now.ToLongTimeString(), true);
        Console.WriteLine(s.IsValueCreated);   // false
        Console.WriteLine(s.Value);                  // Lambda is invoked now
        Console.WriteLine(s.IsValueCreated);   // true
        Thread.Sleep(10000);
        Console.WriteLine(s.Value);                  // Lambda is NOT invoked now; same result

        String name = null;
        LazyInitializer.EnsureInitialized(ref name, () => "Jeff");
        Console.WriteLine(name);   // Jeff

        LazyInitializer.EnsureInitialized(ref name, () => "Richter");
        Console.WriteLine(name);   // Jeff
    }
}

internal static class ConditionVariables {
    public sealed class ConditionVariablePattern {
        private readonly Object m_lock = new Object();
        private Boolean m_condition = false;

        public void Thread1() {
            Monitor.Enter(m_lock);        // Acquire a mutual-exclusive lock

            // While under the lock, test the complex condition "atomically"
            while (!m_condition) {
                // If condition is not met, wait for another thread to change the condition
                Monitor.Wait(m_lock);	   // Temporarily release lock so other threads can get it
            }

            // The condition was met, process the data...

            Monitor.Exit(m_lock);         // Permanently release lock
        }

        public void Thread2() {
            Monitor.Enter(m_lock);        // Acquire a mutual-exclusive lock

            // Process data and modify the condition...
            m_condition = true;

            // Monitor.Pulse(m_lock);	   // Wakes one waiter AFTER lock is released
            Monitor.PulseAll(m_lock);	   // Wakes all waiters AFTER lock is released

            Monitor.Exit(m_lock);         // Release lock
        }
    }

    public sealed class SynchronizedQueue<T> {
        private readonly Object m_lock = new Object();
        private readonly Queue<T> m_queue = new Queue<T>();

        public void Enqueue(T item) {
            Monitor.Enter(m_lock);

            m_queue.Enqueue(item);
            Monitor.PulseAll(m_lock); // Wakeup any/all waiters

            Monitor.Exit(m_lock);
        }

        public T Dequeue() {
            Monitor.Enter(m_lock);

            // Loop waiting for condition (queue not empty)
            while (m_queue.Count == 0)
                Monitor.Wait(m_queue);

            T item = m_queue.Dequeue();
            Monitor.Exit(m_lock);
            return item;
        }
    }
}

internal static class WriterGateDemo {
    public static void Go() {
        var gate = new WriterGate();
        for (Int32 x = 0; x < 5; x++) {
            gate.Queue(() => {
                Console.WriteLine(DateTime.Now); Thread.Sleep(1000);
            });
        }
        Console.ReadLine();
        gate.Queue(() => {
            Console.WriteLine("All Done");
        });
        Console.ReadLine();
    }

    private sealed class WriterGate {
        private readonly Object m_lock = new Object();
        private Queue<Action> m_qRequests = new Queue<Action>();
        private Boolean m_inFlight = false;

        public WriterGate() { }

        public void Queue(Action callback) {
            Monitor.Enter(m_lock);
            if (m_inFlight == false) {
                m_inFlight = true;
                ThreadPool.QueueUserWorkItem(Release, callback);
            } else m_qRequests.Enqueue(callback);
            Monitor.Exit(m_lock);
        }

        private void Release(Object cb) {
            // Invoke the user's callback method
            Action callback = (Action)cb;
            callback();

            Monitor.Enter(m_lock);
            if (m_qRequests.Count > 0) {
                // There are more queued items, let one of them run
                ThreadPool.QueueUserWorkItem(Release, m_qRequests.Dequeue());
            } else {
                // There are no more queued items, the gate is free
                m_inFlight = false;
            }
            Monitor.Exit(m_lock);
        }
    }
}

internal static class BlockingCollectionDemo {
    public static void Go() {
        var bl = new BlockingCollection<Int32>(new ConcurrentQueue<Int32>());

        // A thread pool thread will do the consuming
        ThreadPool.QueueUserWorkItem(ConsumeItems, bl);

        // Add 5 items to the collection
        for (Int32 item = 0; item < 5; item++) {
            Console.WriteLine("Producing: " + item);
            bl.Add(item);
        }

        // Tell the consuming thread(s) that no more items will be added to the collection
        bl.CompleteAdding();

        Console.ReadLine();  // For testing purposes
    }

    private static void ConsumeItems(Object o) {
        var bl = (BlockingCollection<Int32>)o;

        // Block until an item shows up, then process it
        foreach (var item in bl.GetConsumingEnumerable()) {
            Console.WriteLine("Consuming: " + item);
        }

        // The collection is empty and no more items are going into it
        Console.WriteLine("All items have been consumed");
    }
}
