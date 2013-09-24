//委托和事件
using System;
namespace Miracle {
	/*
	public class Heater
	{
		private int temperature;
		public void BoilWater()
		{
			for(int i=0;i<100;i++)
			{
				temperature =i;
				if (temperature >95)
				{
					MakeAlert(temperature);
					ShowMsg(temperature);
				}
			}
		}
		private void MakeAlert(int param)
		{
			Console.WriteLine("Alarm:滴滴滴，水已经度{0}了",param);
		}
		private void ShowMsg(int param)
		{
			Console.WriteLine("Display:水快开了，当前温度{0}",param);
		}
		}
		*/
		
	class Program 
	{
		static void Main()
		{
			Heater ht= new Heater();
			Alarm am = new Alarm();
			ht.Boiled += am.MakeAlert;
			ht.Boiled +=(new Alarm()).MakeAlert;
			ht.Boiled +=Display.ShowMsg;
			ht.BoilWater();
		}
	}
	//热水器
	public class Heater
	{
		private int temperature;
		public string type ="RealFire 001";
		public string area = "China Hangzhou";
		
		public delegate void BoilEventHandler(Object sender,BoiledEventArgs e);
		public event BoilEventHandler Boiled;
		//定义BoiledEventArgs类，传递给observer 所感兴趣的信息
		public class BoiledEventArgs:EventArgs
		{
			public readonly int temperature;
			public BoiledEventArgs(int temperature)
			{
				this.temperature = temperature;
			}
		}
		
		//烧水
		public void BoilWater()
		{
			for(int i=0;i<100;i++)
			{
				temperature =i;
				if(temperature >95)
				{
					BoiledEventArgs e = new BoiledEventArgs(temperature);
					OnBoiled(e);
					//if (BoilEvent!=null)
					//{
						//BoilEvent(temperature);
					//}
				}
			}
		}
		
		//可以供继承自heater 的类重写，以便派生类拒绝其他对象对他的监视
		protected virtual void OnBoiled(BoiledEventArgs e)
		{
			if (Boiled != null)
			{
				Boiled(this,e);//调用所有注册对象的方法
			}
		}
		
		
	}
	//警报器
	public class Alarm
	{
		/*
		public void MakeAlert(int param)
		{
			Console.WriteLine("Alarm:滴滴滴，水已经{0}度了。",param);
		}
		*/
		public void MakeAlert(Object sender,Heater.BoiledEventArgs e)
		{
			Heater heater = (Heater)sender;
			Console.WriteLine("Alarm : {0}-{1}",heater.area,heater.type);
			Console.WriteLine("滴滴滴，水已经{0}度了。",e.temperature);
			Console.WriteLine();
		}
		
		
		
	}
	//显示器
	public class Display
	{
		public static void ShowMsg(Object sender,Heater.BoiledEventArgs e)
		{
			Heater heater = (Heater) sender;
			Console.WriteLine("Display: {0}-{1}",heater.area,heater.type);
			Console.WriteLine("Display：水快烧开了，当前温度{0}",e.temperature);
			Console.WriteLine();
		}
	}
	}