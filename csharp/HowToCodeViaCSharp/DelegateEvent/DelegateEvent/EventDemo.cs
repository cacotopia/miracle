/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2013/9/22
 * 时间: 21:43
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DelegateEvent
{
	/// <summary>
	/// Description of Publisher.
	/// 事件发布者
	/// </summary>
	public delegate void NumberChangedEventHandler(int count);
	public class Publisher
	{
		public Publisher()
		{
		}
		private int count;
		//声明委托变量
		//public NumberChangedEventHandler NumberChanged;
		//声明事件变量
		public event NumberChangedEventHandler NumberChanged; 
		public void DoSomthing()
		{
			if (NumberChanged != null) 
			{
				count ++;
				NumberChanged(count);
				
			}
		}
		
	}
	public class Subscriber
		{
			public void OnNumberChanged(int count)
			{
				Console.WriteLine("Subscriber notified :count = {0}",count);
			}
		}
}
