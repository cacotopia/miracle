//Fig 27.1 OverloadedMethods.cs
//Using overloaded methods to display arrays of different types.
using System;
using System.Collections.Generic;
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
			DisplayArray<int>(intArray);
			Console.WriteLine("Array doubleArray contains :");
			DisplayArray(doubleArray);
			DisplayArray<double>(doubleArray);
			Console.WriteLine("Array charArray contains :");
			DisplayArray(charArray);
			DisplayArray<char>(charArray);
		}
		
		private static void DisplayArray<T>(T[] inputArray)
		{
			foreach(T element in inputArray)
			 Console.Write(element + " ");
			Console.WriteLine("Generic Method is callded.");
		}
		
		private static void DisplayArray(int[] intArray)
		{
			foreach(var i in intArray)
			{
				Console.Write(i + " ");
			}
			 Console.WriteLine("Overloaded method for int array is called.");
		}
		private static void DisplayArray(double[] doubleArray)
		{
			foreach(var dbl in doubleArray) 
			 {
			 	Console.Write(dbl + " ");
			 }
			 Console.WriteLine("Overloaded method for double array is called.");
		}
		private static void DisplayArray(char[] charArray) 
		{
			foreach(var chr in charArray)
			{
				Console.Write(chr+ " ");
			}
			Console.WriteLine("Overloaded method for char array is called.");
		}
		
	}
}