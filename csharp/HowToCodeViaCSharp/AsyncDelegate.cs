//委托和方法的一部调用
// from 张子扬 C#委托和事件
//2013.09.24
using System;
using System.Threading;
namespace Miracle
{
	  public delegate int AddDelegate(int x,int y);
    public class AsynDelegate
    {
    	static void Main(string[] args)
    	{
    		Console.WriteLine("Client application started.\n");
    		Thread.CurrentThread.Name = "Main Thread";
    		Calculator cal = new Calculator();
    		AddDelegate del = new AddDelegate(cal.Add);
    		//异步调用方法
    		IAsyncResult asynResult = del.BeginInvoke(2,5,null,null);
    		
    	//	int result = cal.Add(2,5);
    		//Console.WriteLine("Result:{0}",result);
    		
    		for (int i=0;i<=3;i++)
    		{
    			Thread.Sleep(TimeSpan.FromSeconds(i));
    			Console.WriteLine("{0}:Client executed {1} second(s).",Thread.CurrentThread.Name,i);
    		}
    		int result = del.EndInvoke(asynResult);
    		Console.WriteLine("Result:{0}",result);
    		Console.WriteLine("Press any key to exit....");
    		Console.ReadKey();
    	}
    }
    public class Calculator
    {
    	public int Add(int x,int y)
    	{
    		if (Thread.CurrentThread.IsThreadPoolThread)
    		{
    			Thread.CurrentThread.Name = "Pool Thread";
    		}
    		Console.WriteLine("Method Invoked");
    		for(int i=1;i<=2;i++)
    		{
    			Thread.Sleep(TimeSpan.FromSeconds(i));
    			Console.WriteLine("{0}:Add ececuted {1} secondes.",Thread.CurrentThread.Name,i);
    		}
    		Console.WriteLine("Method complete!");
    		return x+y;
    	}
    }
}