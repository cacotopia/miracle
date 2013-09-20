//C# װ�������
// YuHuanLong 2013.09.19
// Enjoy Century
using System;
namespace Miracle 
{
	internal struct Point:IComparable
	{
		private Int32 m_x,m_y;
		public Point(Int32 x,Int32 y)
		{
			this.m_x=x;
			this.m_y=y;
		}
		public override String ToString()
		{
			return String.Format("({0},{1})",m_x,m_y);
		}
		public Int32 CompareTo(Point other)
		{
			return Math.Sign(Math.Sqrt(m_x*m_x+m_y*m_y)-Math.Sqrt(other.m_x*other.m_x+other.m_y*other.m_y));
		}
		public Int32 CompareTo(Object o)
		{
			if (GetType()!=o.GetType())
			{
				throw new ArgumentException("o is not a Point");
			}
			return CompareTo((Point)o);
		}
		public void Change(Int32 x,Int32 y)
		{
			m_x=x;m_y=y;
		}
	}
	internal interface IChangeBoxPoint
	{
		void BoxChange(Int32 x,Int32 y);
	}
	public static class Program
	{
		public static void Main(string[] args)
		{
			//��ջ�ϴ�������Pointʵ��
			Point p1 = new Point(10,10);
			Point p2 = new Point(20,20);
			//����ToString�����鷽����ʱ�������p1����װ��
			Console.WriteLine(p1.ToString());
			//����GetType�����鷽����ʱ��Ҫ��p1����װ��
			Console.WriteLine(p1.GetType());
			
			//����CompareTo(Point) �����P2װ��
			Console.WriteLine(p1.CompareTo(p2));
			//p1Ҫ����װ�䣬�����÷ŵ�c��
			IComparable c= p1;
			Console.WriteLine(c.GetType());
			//c����װ�䣬��Ϊ�������ñ�������һ����װ���point
			Console.WriteLine(p1.CompareTo(c));
			//p2�ᱻװ�䣬��Ϊ���õ���CompareTo��Object��
			Console.WriteLine(c.CompareTo(p2));
			//��c���䣬�ֶθ��Ƶ�p2��
			p2= (Point)c;
			Console.WriteLine(p2.ToString());
			
			Point p3 = new Point(1,1);
			Console.WriteLine(p3);
			p3.Change(2,2);
			Console.WriteLine(p3);
			Object o=p3;
			Console.WriteLine(o);
			//��oת��ΪPoint��Ҫ����װ���p3���䣬������װ��Point���ֶθ��Ƶ��߳�ջ�ϵ�һ����ʱPoint��
			//����װ���Point�������Change���õ�Ӱ��
			((Point)o).Change(3,3);
			Console.WriteLine(o); 
			Console.ReadLine();
		}
	}
}