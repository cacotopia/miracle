//委托与异步回调
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
namespace Delegates 
{
	class Program 
	{
		delegate int MethodDelegate(int num1,int num2);
		static void Main(string[] args)
		{
			MethodDelegate del = AddTwoNumbers;
			AsyncCallback callback = new AsyncCallback(ResultCallback);
			
			Console.WriteLine("Invoking the method asynchronously...");
			IAsyncResult result =del.BeginInvoke(5,3,callback,null);
			Console.WriteLine("Continuing with the execution...");
			Console.ReadLine();
		}
		static private int AddTwoNumbers(int num1,int num2) 
		{
			System.Threading.Thread.Sleep(5000);
			return num1 +num2;
		}
		static private void ResultCallback(IAsyncResult ar)
		{
			MethodDelegate del = (MethodDelegate)((AsyncResult)ar).AsyncDelegate;
			int result = del.EndInvoke(ar);
			Console.WriteLine("Result of additon is :" + result);
		}
	}
}