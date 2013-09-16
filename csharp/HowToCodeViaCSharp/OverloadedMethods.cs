//Fig 27.1 OverloadedMethods.cs
//Using overloaded methods to display arrays of different types.
using System;
namespace Miracle
{
	class Program 
	{
		static void Main()
		{
			int[] intArray = new int[] {1,2,3,4,5,6};
			double[] doubleArray = new double[] {1.1,2.2,3.3,4.4,5.5,6.6};
			char[] charArray = new char[]{'A','B','C','D','E','F'};
			Console.WriteLine("Array intArray contains :");
			DisplayArray(intArray);
			Console.WriteLine("Array doubleArray contains :");
			DisplayArray(doubleArray);
			DisplayArray(charArray);
		}
		private static void DisplayArray(int[] intArray)
		{
			foreach(var i in intArray)
			{
				Console.Write(i + " ");
			}
		}
		private static void DisplayArray(double[] doubleArray)
		{
			foreach(var dbl in doubleArray) 
			 {
			 	Console.Write(dbl + " ");
			 }
		}
		private static void DisplayArray(char[] charArray) 
		{
			foreach(var chr in charArray)
			{
				Console.Write(chr+ " ");
			}
		}
	}
}