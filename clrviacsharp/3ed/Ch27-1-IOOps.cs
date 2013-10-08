//#define Referencing_Wintellect_Threading_dll
#if Referencing_Wintellect_Threading_dll
using Wintellect.Threading.AsyncProgModel;
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Security;
using System.Security.Permissions;


public static class IOOps {
   [STAThread]
   public static void Main() {
      Echo.Go();
      ApmExceptionHandling.Go();
      ApmUI.Go();
      ComputeBoundApm.Go();
      ThreadIO.Go();
      ApmTasks.Go();
      Eap.Go();
   }
}

internal static class ThreadIO {
   public static void Go() {
      using (ThreadIO.BeginBackgroundProcessing()) {
         // Issue low-priority I/O request in here...
      }
   }

   public static BackgroundProcessingDisposer BeginBackgroundProcessing(Boolean process = false) {
      ChangeBackgroundProcessing(process, true);
      return new BackgroundProcessingDisposer(process);
   }

   public static void EndBackgroundProcessing(Boolean process = false) {
      ChangeBackgroundProcessing(process, false);
   }

   private static void ChangeBackgroundProcessing(Boolean process, Boolean start) {
      Boolean ok = process
         ? SetPriorityClass(GetCurrentWin32ProcessHandle(),
               start ? ProcessBackgroundMode.Start : ProcessBackgroundMode.End)
         : SetThreadPriority(GetCurrentWin32ThreadHandle(),
               start ? ThreadBackgroundgMode.Start : ThreadBackgroundgMode.End);
      if (!ok) throw new Win32Exception();
   }

   // This struct lets C#'s using statement end the background processing mode
   public struct BackgroundProcessingDisposer : IDisposable {
      private readonly Boolean m_process;
      public BackgroundProcessingDisposer(Boolean process) { m_process = process; }
      public void Dispose() { EndBackgroundProcessing(m_process); }
   }


   // See Win32’s THREAD_MODE_BACKGROUND_BEGIN and THREAD_MODE_BACKGROUND_END
   private enum ThreadBackgroundgMode { Start = 0x10000, End = 0x20000 }

   // See Win32’s PROCESS_MODE_BACKGROUND_BEGIN and PROCESS_MODE_BACKGROUND_END   
   private enum ProcessBackgroundMode { Start = 0x100000, End = 0x200000 }

   [DllImport("Kernel32", EntryPoint = "GetCurrentProcess", ExactSpelling = true)]
   private static extern SafeWaitHandle GetCurrentWin32ProcessHandle();

   [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
   [return: MarshalAs(UnmanagedType.Bool)]
   private static extern Boolean SetPriorityClass(SafeWaitHandle hprocess, ProcessBackgroundMode mode);


   [DllImport("Kernel32", EntryPoint = "GetCurrentThread", ExactSpelling = true)]
   private static extern SafeWaitHandle GetCurrentWin32ThreadHandle();

   [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
   [return: MarshalAs(UnmanagedType.Bool)]
   private static extern Boolean SetThreadPriority(SafeWaitHandle hthread, ThreadBackgroundgMode mode);

   // http://msdn.microsoft.com/en-us/library/aa480216.aspx
   [DllImport("Kernel32", SetLastError = true, EntryPoint = "CancelSynchronousIo")]
   [return: MarshalAs(UnmanagedType.Bool)]
   private static extern Boolean CancelSynchronousIO(SafeWaitHandle hThread);
}

internal static class Echo {
   public static void Go() {
      ImplementedViaRawApm();

#if Referencing_Wintellect_Threading_dll
      ImplementedViaAsyncEnumerator();
#endif

      // Since all the requests are issued asynchronously, the constructors are likely to return
      // before all the requests are complete. The call below stops the application from terminating
      // until we see all the responses displayed.
      Console.ReadLine();
   }

   private static void ImplementedViaRawApm() {
      // Start 1 server per CPU
      for (Int32 n = 0; n < Environment.ProcessorCount; n++)
         new PipeServer();

      // Now make a 100 client requests against the server
      for (Int32 n = 0; n < 100; n++)
         new PipeClient("localhost", "Request #" + n);
   }

   private sealed class PipeServer {
      // Each server object performs asynchronous operations on this pipe
      private readonly NamedPipeServerStream m_pipe = new NamedPipeServerStream(
         "Echo", PipeDirection.InOut, -1, PipeTransmissionMode.Message,
         PipeOptions.Asynchronous | PipeOptions.WriteThrough);

      public PipeServer() {
         // Asynchronously accept a client connection
         m_pipe.BeginWaitForConnection(ClientConnected, null);
      }

      private void ClientConnected(IAsyncResult result) {
         // A client connected, let's accept another client
         new PipeServer(); // Accept another client

         // Accept the client connection
         m_pipe.EndWaitForConnection(result);

         // Asynchronously read a request from the client
         Byte[] data = new Byte[1000];
         m_pipe.BeginRead(data, 0, data.Length, GotRequest, data);
      }

      private void GotRequest(IAsyncResult result) {
         // The client sent us a request, process it. 
         Int32 bytesRead = m_pipe.EndRead(result);
         Byte[] data = (Byte[])result.AsyncState;

         // My sample server just changes all the characters to uppercase
         // But, you can replace this code with any compute-bound operation
         data = Encoding.UTF8.GetBytes(
            Encoding.UTF8.GetString(data, 0, bytesRead).ToUpper().ToCharArray());

         // Asynchronously send the response back to the client
         m_pipe.BeginWrite(data, 0, data.Length, WriteDone, null);
      }

      private void WriteDone(IAsyncResult result) {
         // The response was sent to the client, close our side of the connection
         m_pipe.EndWrite(result);
         m_pipe.Close();
      }
   }
   private sealed class PipeClient {
      // Each client object performs asynchronous operations on this pipe
      private readonly NamedPipeClientStream m_pipe;

      public PipeClient(String serverName, String message) {
         m_pipe = new NamedPipeClientStream(serverName, "Echo",
            PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough);
         m_pipe.Connect(); // Must Connect before setting ReadMode
         m_pipe.ReadMode = PipeTransmissionMode.Message;

         // Asynchronously send data to the server
         Byte[] output = Encoding.UTF8.GetBytes(message);
         m_pipe.BeginWrite(output, 0, output.Length, WriteDone, null);
      }

      private void WriteDone(IAsyncResult result) {
         // The data was sent to the server
         m_pipe.EndWrite(result);

         // Asynchronously read the server's response
         Byte[] data = new Byte[1000];
         m_pipe.BeginRead(data, 0, data.Length, GotResponse, data);
      }

      private void GotResponse(IAsyncResult result) {
         // The server responded, display the response and close out connection
         Int32 bytesRead = m_pipe.EndRead(result);

         Byte[] data = (Byte[])result.AsyncState;
         Console.WriteLine("Server response: " + Encoding.UTF8.GetString(data, 0, bytesRead));
         m_pipe.Close();
      }
   }

#if Referencing_Wintellect_Threading_dll
   private static void ImplementedViaAsyncEnumerator() {
      // Start 1 server per CPU
      for (Int32 n = 0; n < Environment.ProcessorCount; n++) {
         var ae = new AsyncEnumerator();
         ae.BeginExecute(PipeServerAsyncEnumerator(ae), ae.EndExecute);
      }

      // Now make a 100 client requests against the server
      for (Int32 n = 0; n < 100; n++) {
         var ae = new AsyncEnumerator();
         ae.BeginExecute(PipeClientAsyncEnumerator(ae, "localhost", "Request #" + n), ae.EndExecute);
      }
   }

   // This field records the timestamp of the most recent client's request
   private static DateTime s_lastClientRequestTimestamp = DateTime.MinValue;

   // The SyncGate enforces thread-safe access to the s_lastClientRequestTimestamp field
   private static readonly SyncGate s_gate = new SyncGate();

   private static IEnumerator<Int32> PipeServerAsyncEnumerator(AsyncEnumerator ae) {
      // Each server object performs asynchronous operations on this pipe
      using (var pipe = new NamedPipeServerStream(
         "Echo", PipeDirection.InOut, -1, PipeTransmissionMode.Message,
         PipeOptions.Asynchronous | PipeOptions.WriteThrough)) {

         // Asynchronously accept a client connection
         pipe.BeginWaitForConnection(ae.End(), null);
         yield return 1;

         // A client connected, let's accept another client
         var aeNewClient = new AsyncEnumerator();
         aeNewClient.BeginExecute(PipeServerAsyncEnumerator(aeNewClient), aeNewClient.EndExecute);

         // Accept the client connection
         pipe.EndWaitForConnection(ae.DequeueAsyncResult());

         // Asynchronously read a request from the client
         Byte[] data = new Byte[1000];
         pipe.BeginRead(data, 0, data.Length, ae.End(), null);
         yield return 1;

         // The client sent us a request, process it. 
         Int32 bytesRead = pipe.EndRead(ae.DequeueAsyncResult());
         
         // Get the timestamp of this client's request
         DateTime now = DateTime.Now;

         // We want to save the timestamp of the most-recent client request. Since multiple
         // clients are running concurrently, this has to be done in a thread-safe way
         s_gate.BeginRegion(SyncGateMode.Exclusive, ae.End()); // Request exclusive access
         yield return 1;   // The iterator resumes when exclusive access is granted

         if (s_lastClientRequestTimestamp < now) 
            s_lastClientRequestTimestamp = now;

         s_gate.EndRegion(ae.DequeueAsyncResult());   // Relinquish exclusive access

         // My sample server just changes all the characters to uppercase
         // But, you can replace this code with any compute-bound operation
         data = Encoding.UTF8.GetBytes(
            Encoding.UTF8.GetString(data, 0, bytesRead).ToUpper().ToCharArray());

         // Asynchronously send the response back to the client
         pipe.BeginWrite(data, 0, data.Length, ae.End(), null);
         yield return 1;
         // The response was sent to the client, close our side of the connection
         pipe.EndWrite(ae.DequeueAsyncResult());
      } // Close the pipe
   }

   private static IEnumerator<Int32> PipeClientAsyncEnumerator(AsyncEnumerator ae, String serverName, String message) {
      // Each client object performs asynchronous operations on this pipe
      using (var pipe = new NamedPipeClientStream(serverName, "Echo",
            PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough)) {
         pipe.Connect(); // Must Connect before setting ReadMode
         pipe.ReadMode = PipeTransmissionMode.Message;

         // Asynchronously send data to the server
         Byte[] output = Encoding.UTF8.GetBytes(message);
         pipe.BeginWrite(output, 0, output.Length, ae.End(), null);
         yield return 1;

         // The data was sent to the server
         pipe.EndWrite(ae.DequeueAsyncResult());

         // Asynchronously read the server's response
         Byte[] data = new Byte[1000];
         pipe.BeginRead(data, 0, data.Length, ae.End(), data);
         yield return 1;

         // The server responded, display the response and close out connection
         Int32 bytesRead = pipe.EndRead(ae.DequeueAsyncResult());

         Console.WriteLine("Server response: " + Encoding.UTF8.GetString(data, 0, bytesRead));
      }  // Close();      
   }
#endif
}

internal static class ApmExceptionHandling {
   public static void Go() {
      WebRequest webRequest = WebRequest.Create("http://0.0.0.0/");
      webRequest.BeginGetResponse(ProcessWebResponse, webRequest);
      Console.ReadLine();
   }
   private static void ProcessWebResponse(IAsyncResult result) {
      WebRequest webRequest = (WebRequest)result.AsyncState;

      WebResponse webResponse = null;
      try {
         webResponse = webRequest.EndGetResponse(result);
         Console.WriteLine("Content length: " + webResponse.ContentLength);
      }
      catch (WebException we) {
         Console.WriteLine(we.GetType() + ": " + we.Message);
      }
      finally {
         if (webResponse != null) webResponse.Close();
      }
   }
}

internal static class ApmUI {
   public static void Go() {
      // This is a Windows Forms example
      System.Windows.Forms.Application.Run(new MyWindowsForm());

      // This is a WPF example
      new MyWpfWindow().ShowDialog();
   }

   private static AsyncCallback SyncContextCallback(AsyncCallback callback) {
      // Capture the calling thread's SynchronizationContext-derived object
      SynchronizationContext sc = SynchronizationContext.Current;

      // If there is no SC, just return what was passed in
      if (sc == null) return callback;

      // Return a delegate that, when invoked, posts to the captured SC a method that 
      // calls the original AsyncCallback passing it the IAsyncResult argument
      return asyncResult => sc.Post(result => callback((IAsyncResult)result), asyncResult);
   }

   private sealed class MyWindowsForm : System.Windows.Forms.Form {
      public MyWindowsForm() {
         Text = "Click in the window to start a Web request";
         Width = 400;
         Height = 100;
      }

      protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e) {
         // The GUI thread initiates the asynchronous Web request 
         Text = "Web request initiated";
         var webRequest = WebRequest.Create("http://Wintellect.com/");
         webRequest.BeginGetResponse(SyncContextCallback(ProcessWebResponse), webRequest);
         base.OnMouseClick(e);
      }

      private void ProcessWebResponse(IAsyncResult result) {
         // If we get here, this must be the GUI thread, it's OK to update the UI
         var webRequest = (WebRequest)result.AsyncState;
         using (var webResponse = webRequest.EndGetResponse(result)) {
            Text = "Content length: " + webResponse.ContentLength;
         }
      }
   }

   private sealed class MyWpfWindow : System.Windows.Window {
      public MyWpfWindow() {
         Title = "Click in the window to start a Web request";
         Width = 400;
         Height = 100;
      }

      protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e) {
         // The GUI thread initiates the asynchronous Web request 
         Title = "Web request initiated";
         var webRequest = WebRequest.Create("http://Wintellect.com/");
         webRequest.BeginGetResponse(SyncContextCallback(ProcessWebResponse), webRequest);
         base.OnMouseDown(e);
      }

      private void ProcessWebResponse(IAsyncResult result) {
         // If we get here, this must be the GUI thread, it's OK to update the UI
         var webRequest = (WebRequest)result.AsyncState;
         using (var webResponse = webRequest.EndGetResponse(result)) {
            Title = "Content length: " + webResponse.ContentLength;
         }
      }
   }
}

internal static class ComputeBoundApm {
   public static void Go() {
      // Initialize a delegate variable to refer to the method we want to call asynchronously 
      Func<UInt64, UInt64> sumDelegate = Sum;

      // Call the method using a thread pool thread 
      sumDelegate.BeginInvoke(1000000, SumIsDone, sumDelegate);

      // Executing some other code here would be useful... 

      // For this demo, I'll just suspend the primary thread 
      Console.ReadLine();
   }

   private static void SumIsDone(IAsyncResult result) {
      // Extract the sumDelegate (state) from the IAsyncResult object 
      var sumDelegate = (Func<UInt64, UInt64>)result.AsyncState;
      try {
         // Get the result and display it
         Console.WriteLine("Sum's result: " + sumDelegate.EndInvoke(result));
      }
      catch (OverflowException) {
         Console.WriteLine("Sum's result is too large to calculate");
      }
   }

   private static UInt64 Sum(UInt64 n) {
      UInt64 sum = 0;
      for (UInt64 i = 1; i <= n; i++) {
         checked {
            // I use checked code so that an OverflowException gets  
            // thrown if the sum doesn't fit in a UInt64. 
            sum += i;
         }
      }
      return sum;
   }
}

internal static class ApmTasks {
   public static void Go() {
      ConvertingApmToTask();
   }

   private static void ProcessWebResponse(IAsyncResult result) {
      var webRequest = (WebRequest)result.AsyncState;
      using (var webResponse = webRequest.EndGetResponse(result)) {
         Console.WriteLine("Content length: " + webResponse.ContentLength);
      }
   }

   private static void ConvertingApmToTask() {
      // Instead of this:
      WebRequest webRequest = WebRequest.Create("http://Wintellect.com/");
      webRequest.BeginGetResponse(result => {
         WebResponse webResponse = null;
         try {
            webResponse = webRequest.EndGetResponse(result);
            Console.WriteLine("Content length: " + webResponse.ContentLength);
         }
         catch (WebException we) {
            Console.WriteLine("Failed: " + we.GetBaseException().Message);
         }
         finally {
            if (webResponse != null) webResponse.Close();
         }
      }, null);

      Console.ReadLine();  // for testing purposes

      // Make a Task from an async operation that FromAsync starts
      /*WebRequest*/
      webRequest = WebRequest.Create("http://Wintellect.com/");
      var t1 = Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse, null, TaskCreationOptions.None);
      var t2 = t1.ContinueWith(task => {
         WebResponse webResponse = null;
         try {
            webResponse = task.Result;
            Console.WriteLine("Content length: " + webResponse.ContentLength);
         }
         catch (AggregateException ae) {
            if (ae.GetBaseException() is WebException)
               Console.WriteLine("Failed: " + ae.GetBaseException().Message);
            else throw;
         }
         finally { if (webResponse != null) webResponse.Close(); }
      });

      try {
         t2.Wait();  // for testing purposes only
      }
      catch (AggregateException) { }
   }
}

internal static class Eap {
   public static void Go() {
      // Create the form and show it
      System.Windows.Forms.Application.Run(new MyForm());

      System.Windows.Forms.Application.Run(new MyFormTask());
   }

   private sealed class MyForm : System.Windows.Forms.Form {
      protected override void OnClick(EventArgs e) {
         // The System.Net.WebClient class supports the Event-based Asynchronous Pattern
         WebClient wc = new WebClient();

         // When a string completes downloading, the WebClient object raises the 
         // DownloadStringCompleted event which will invoke our ProcessString method         
         wc.DownloadStringCompleted += ProcessString;

         // Start the asynchronous operation (this is like calling a BeginXxx method)
         wc.DownloadStringAsync(new Uri("http://Wintellect.com"));
         base.OnClick(e);
      }

      // This method is guaranteed to be called via the GUI thread
      private void ProcessString(Object sender, DownloadStringCompletedEventArgs e) {
         // If an error occurred, display it; else display the downloaded string
         System.Windows.Forms.MessageBox.Show((e.Error != null) ? e.Error.Message : e.Result);
      }
   }

   private sealed class MyFormTask : System.Windows.Forms.Form {
      protected override void OnClick(EventArgs e) {
         // The System.Net.WebClient class supports the Event-based Asynchronous Pattern
         WebClient wc = new WebClient();

         // Create the TaskCompletionSource and its underlying Task object
         var tcs = new TaskCompletionSource<String>();

         // When a string completes downloading, the WebClient object raises the 
         // DownloadStringCompleted event which will invoke our ProcessString method
         wc.DownloadStringCompleted += (sender, ea) => {
            // This code always executes on the GUI thread; set the Task’s state
            if (ea.Cancelled) tcs.SetCanceled();
            else if (ea.Error != null) tcs.SetException(ea.Error);
            else tcs.SetResult(ea.Result);
         };

         // Have the Task continue with this Task that shows the result in a message box
         // NOTE: The TaskContinuationOptions.ExecuteSynchronously flag is required to have this code
         // run on the GUI thread; without the flag, the code runs on a thread pool thread 
         tcs.Task.ContinueWith(t => {
            try {
               System.Windows.Forms.MessageBox.Show(t.Result);
            }
            catch (AggregateException ae) {
               System.Windows.Forms.MessageBox.Show(ae.GetBaseException().Message);
            }
         }, TaskContinuationOptions.ExecuteSynchronously);

         // Start the asynchronous operation (this is like calling a BeginXxx method)
         wc.DownloadStringAsync(new Uri("http://Wintellect.com"));
         base.OnClick(e);
      }
   }
}
