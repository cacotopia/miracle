//ί�к��¼�
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
			Console.WriteLine("Alarm:�εεΣ�ˮ�Ѿ���{0}��",param);
		}
		private void ShowMsg(int param)
		{
			Console.WriteLine("Display:ˮ�쿪�ˣ���ǰ�¶�{0}",param);
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
	//��ˮ��
	public class Heater
	{
		private int temperature;
		public string type ="RealFire 001";
		public string area = "China Hangzhou";
		
		public delegate void BoilEventHandler(Object sender,BoiledEventArgs e);
		public event BoilEventHandler Boiled;
		//����BoiledEventArgs�࣬���ݸ�observer ������Ȥ����Ϣ
		public class BoiledEventArgs:EventArgs
		{
			public readonly int temperature;
			public BoiledEventArgs(int temperature)
			{
				this.temperature = temperature;
			}
		}
		
		//��ˮ
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
		
		//���Թ��̳���heater ������д���Ա�������ܾ�������������ļ���
		protected virtual void OnBoiled(BoiledEventArgs e)
		{
			if (Boiled != null)
			{
				Boiled(this,e);//��������ע�����ķ���
			}
		}
		
		
	}
	//������
	public class Alarm
	{
		/*
		public void MakeAlert(int param)
		{
			Console.WriteLine("Alarm:�εεΣ�ˮ�Ѿ�{0}���ˡ�",param);
		}
		*/
		public void MakeAlert(Object sender,Heater.BoiledEventArgs e)
		{
			Heater heater = (Heater)sender;
			Console.WriteLine("Alarm : {0}-{1}",heater.area,heater.type);
			Console.WriteLine("�εεΣ�ˮ�Ѿ�{0}���ˡ�",e.temperature);
			Console.WriteLine();
		}
		
		
		
	}
	//��ʾ��
	public class Display
	{
		public static void ShowMsg(Object sender,Heater.BoiledEventArgs e)
		{
			Heater heater = (Heater) sender;
			Console.WriteLine("Display: {0}-{1}",heater.area,heater.type);
			Console.WriteLine("Display��ˮ���տ��ˣ���ǰ�¶�{0}",e.temperature);
			Console.WriteLine();
		}
	}
	}