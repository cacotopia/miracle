//C# 装箱与拆箱
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
			//在栈上创建两个Point实例
			Point p1 = new Point(10,10);
			Point p2 = new Point(20,20);
			//调用ToString（非虚方法）时，不会对p1进行装箱
			Console.WriteLine(p1.ToString());
			//调用GetType（非虚方法）时，要对p1进行装箱
			Console.WriteLine(p1.GetType());
			
			//调用CompareTo(Point) 不会对P2装箱
			Console.WriteLine(p1.CompareTo(p2));
			//p1要进行装箱，将引用放到c中
			IComparable c= p1;
			Console.WriteLine(c.GetType());
			//c不会装箱，因为它的引用本来就是一个已装箱的point
			Console.WriteLine(p1.CompareTo(c));
			//p2会被装箱，因为调用的是CompareTo（Object）
			Console.WriteLine(c.CompareTo(p2));
			//对c拆箱，字段复制到p2中
			p2= (Point)c;
			Console.WriteLine(p2.ToString());
			
			Point p3 = new Point(1,1);
			Console.WriteLine(p3);
			p3.Change(2,2);
			Console.WriteLine(p3);
			Object o=p3;
			Console.WriteLine(o);
			//将o转换为Point需要对已装箱的p3拆箱，并将已装箱Point的字段复制到线程栈上的一个零时Point中
			//但已装箱的Point不受这个Change调用的影响
			((Point)o).Change(3,3);
			Console.WriteLine(o); 
			Console.ReadLine();
		}
	}
}