//Fig 27.4 :GenericContract.cs
//Generic method Maximum returns the largest of three object;
using System;
namespace Miracle 
{
	public  class Program 
	{
		public static void Main(string[] args) 
		{
			Console.WriteLine("Maximum of {0},{1} and {2} is : {3}\n",3,4,5,Maximum(3,4,5));
			Console.WriteLine("Maximum of {0},{1} and {2} is : {3}\n",6.6,7.7,8.8,Maximum(6.6,7.7,8.8));
			Console.WriteLine("Maximum of {0},{1} and {2} is : {3}\n","pear","apple","orange",Maximum("pear","apple","orange"));
		}
		private static T Maximum<T>(T x,T y,T z)  where T:IComparable<T>
		{
			T max = x;
			if(y.CompareTo(max)> 0)
			  max = y;
			if(z.CompareTo(max) > 0)
			  max = z;
			 return max; 
		}
	}
}