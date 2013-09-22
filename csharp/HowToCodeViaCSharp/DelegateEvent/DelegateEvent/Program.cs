/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2013/9/22
 * 时间: 20:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using DelegateEvent;

namespace DelegateEvent
{
	public delegate void GreetingDelegate(String name);
	public class GreetingManager
	{  
		//声明一个委托
		//public GreetingDelegate greetingdelegate;
		//声明一个事件
		public event GreetingDelegate MakeGreet;
		
		public void GreetPeople(String name//,GreetingDelegate greeting
		                       )
		{
			//greeting(name);
			//greeting.Invoke(name);
			/*
			if (greetingdelegate !=null) 
			{
				greetingdelegate(name);
			}
			*/
			MakeGreet(name);
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			/*
			Console.WriteLine("Hello World!");
			MakeGreeting  makegreeting;// = new MakeGreeting();
			makegreeting  = EnglishGreeting;
			makegreeting  += ChineseGreeting;
		    //	GreetPeople("Jhons",makegreeting);
			//GreetPeople("余涣龙",ChineseGreeting);
			
			// TODO: Implement Functionality Here
			makegreeting("余涣龙");
			
			makegreeting  -= EnglishGreeting;
			makegreeting("Cacotopia");
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			*/
			GreetingManager gm = new GreetingManager();
			gm.MakeGreet += EnglishGreeting;
			gm.MakeGreet += ChineseGreeting;
			//gm.greetingdelegate = EnglishGreeting;
			//gm.greetingdelegate += ChineseGreeting;
			//GreetingDelegate greeting =new GreetingDelegate(EnglishGreeting);
			//greeting += ChineseGreeting;
			
			//gm.GreetPeople("Johns",gm.greetingdelegate);
			gm.GreetPeople("Johns");
			Publisher pub = new Publisher ();
			Subscriber sub = new Subscriber();
			pub.NumberChanged += new NumberChangedEventHandler(sub.OnNumberChanged);
			pub.DoSomthing();
			//pub.NumberChanged(100);
			DelegateDemo.StaticDelegateDemo();
			DelegateDemo.InstanceDelegateDemo();
			DelegateDemo.ChainDelegateDemo1(new DelegateDemo());
			DelegateDemo.ChainDelegateDemo2(new DelegateDemo());
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		/*
		public delegate void MakeGreeting(string name);
		*/
		public static void EnglishGreeting(string name)
		{
			Console.WriteLine("Morning,"+ name);
		}
		public static void ChineseGreeting(string name)
		{
			Console.WriteLine("早上好，"+ name);
		}
		/*
		public static void GreetPeople(string name,MakeGreeting make)
		{
			//make(name);
			make.Invoke(name);
		}
		*/
		
		
	}
	
}