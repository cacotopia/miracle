/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2013/9/22
 * 时间: 22:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;

namespace DelegateEvent
{
	/// <summary>
	/// Description of DelegateDemo.
	/// </summary>
	//声明一个委托类型，它的实例引用一个方法，
	//该方法获取一个Int32 参数，返回void
	public delegate void Feedback(Int32 value);
	public class DelegateDemo
	{
		public DelegateDemo()
		{
		}
		//委托调用静态方法
		public static void StaticDelegateDemo()
		{
			Console.WriteLine("----------Static Delegate Demo----------");
			Counter(1,3,null);
		//	Counter(1,3 new Feedback(DelegateDemo.FeedBackToConsole));
		    Counter(1,3,new Feedback(DelegateDemo.FeedbackToConsole));
		    Counter(1,3,new Feedback(DelegateDemo.FeedbackToMsgBox));
		//	Counter(1,3,new Feedback(FeedBackToMsgBox));
			Console.WriteLine();
		}
		//委托调用实例方法
		public static void InstanceDelegateDemo()
		{
			Console.WriteLine("----------Instance Delegate Demo----------");
			DelegateDemo dd = new DelegateDemo();
			Counter(1,3,new Feedback(dd.FeedbackToFile));
			Console.WriteLine();
		}
		public static void ChainDelegateDemo1(DelegateDemo dd)
		{
			Console.WriteLine("-----Chain Delegate Demo1------");
			Feedback fb1 = new Feedback(FeedbackToConsole);
			Feedback fb2 = new Feedback(FeedbackToMsgBox);
			Feedback fb3 = new Feedback(dd.FeedbackToFile);
			
			Feedback fbchain = null;
			fbchain = (Feedback)Delegate.Combine(fbchain,fb1);
			fbchain = (Feedback)Delegate.Combine(fbchain,fb2);
			fbchain = (Feedback)Delegate.Combine(fbchain,fb3);
			Counter(1,3,fbchain);
			
			Console.WriteLine();
			fbchain= (Feedback)Delegate.Remove(fbchain,new Feedback(FeedbackToMsgBox));
			Counter(1,3,fbchain);
		}
		public static void ChainDelegateDemo2(DelegateDemo dd)
		{
			Console.WriteLine("-------Chain Delegate Demo2-----");
			Feedback fb1 = new Feedback(DelegateDemo.FeedbackToConsole);
			Feedback fb2 = new Feedback(DelegateDemo.FeedbackToMsgBox);
			Feedback fb3 = new Feedback(dd.FeedbackToFile);
			Feedback fbchain = null;
			fbchain += fb1;
			fbchain += fb2;
			fbchain += fb3;
			Counter(1,2,fbchain);
			
			Console.WriteLine("----------------------------------");
			fbchain -= new Feedback(FeedbackToMsgBox);
			Counter(1,3,fbchain);
			
			
		}
		public static void Counter(Int32 from,Int32 to,Feedback fb)
		{
			for(Int32 val = from;val<=to;val ++)
			{
				if (fb!=null)
				{
					fb(val);
				}
			}
		}
		public static void FeedbackToConsole(Int32 value)
		{
			Console.WriteLine("Feedback to Console:Item = {0}",value);
		}
		public static void FeedbackToMsgBox(Int32 value)
		{
			Console.WriteLine("Feedback to MsgBox:Item = {0}",value);
		}
		public  void FeedbackToFile(Int32 value)
		{
			StreamWriter sw = new StreamWriter("Status",true);
			sw.WriteLine("Feedback To File:Item = {0}",value);
			sw.Close();
		}
		
	}
}
