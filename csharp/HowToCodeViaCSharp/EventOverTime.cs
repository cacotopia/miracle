//订阅方法的异常处理
//from 张子扬 C#委托和事件详解\
//2013.09.24
using System;
using System.Threading;
namespace Miracle 
{
	public class Publisher
	{
		public event EventHandler MyEvent;
		public void DoSomething()
		{
			Console.WriteLine("DoSomething Invoked.");
			if (MyEvent!=null)
			{
				Delegate[] delArray = MyEvent.GetInvocationList();
				foreach(Delegate del in delArray)
				{
					/*
					try 
					{
						//EventHandler method = (EventHandler)del;
						method(this,EventArgs.Empty);
						//使用DynamicInvoke方法触发事件
						del.DynamicInvoke(this,);
						
					}catch(Exception e)
					{
						Console.WriteLine("Exception:{0}",e.Message);
					}
					*/
					EventHandler method = (EventHandler)del;
					method.BeginInvoke(null,EventArgs.Empty,null,null);
				}
				/*
				try{
					MyEvent(this,EventArgs.Empty);
				}catch(Exception e)
				{
					Console.WriteLine("Exception:{0}",e.Message);
				}
				*/
			}
		}
		
	}
	public class Subscriber1
	{
		public void OnEvent(Object sender,EventArgs e)
		{
			Thread.Sleep(TimeSpan.FromSeconds(3));
			Console.WriteLine("Subscriber1 Invoked.");
		}
	}
	public class Subscriber2
	{
		public void OnEvent(Object sender,EventArgs e)
		{
			throw new Exception("Subscriber2 failed.");
		}
	}
	public class Subscriber3
	{
		public void OnEvent(Object sender,EventArgs e)
		{
			Thread.Sleep(TimeSpan.FromSeconds(2));
			Console.WriteLine("Subscriber3 Invoked.");
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Publisher pub = new Publisher();
			Subscriber1 sub1 = new Subscriber1();
			Subscriber2 sub2 = new Subscriber2();
			Subscriber3 sub3 = new Subscriber3();
			pub.MyEvent += new EventHandler(sub1.OnEvent);
			pub.MyEvent += new EventHandler(sub2.OnEvent);
			pub.MyEvent += new EventHandler(sub3.OnEvent);
			pub.DoSomething();
			Console.WriteLine("Control back to client!\n");
			Console.WriteLine("Press any key to exit....");
			Console.ReadKey();
			
		}
	}
}