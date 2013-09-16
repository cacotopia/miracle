using System;
namespace Miracle
{
 public delegate void Del(string s);
 public class DelegateDemo 
 {
 	public static void sayHello(string s) 
 	{
 		Console.WriteLine("Hello {0}",s);
 	}
 	public  static void sayGoodbye(string s) 
 	{
 		Console.WriteLine("GoodBye {0}",s);
 	}
 	public static void sayGoodMorning(string s) 
 	{
 		Console.WriteLine("Good Morning {0}",s);
 	}
 	static void Main(string[] args)
 	{  
 		
 		Del a = new Del(sayHello);
 		    a += sayGoodbye;
 		    a += sayGoodMorning;
 		   // a("A");
 		   Console.WriteLine("Del A is Invoking......");
 		   a.Invoke("A");
 		Del b = new Del(sayHello);
 		   Console.WriteLine("Del B Is Invoking.......");
 		   b("B");
 		 
 		Del c =a+b;
 		Console.WriteLine("Del C is Invoking.....");
 		 c("C");  
 	}
 }
}
