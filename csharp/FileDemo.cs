using System;
using System.IO;
using System.Text;
namespace FileDemo {

 public class FileTest
 {
 
   static void Main()
  {
   string filename= null;
  StringBuilder sb = new StringBuilder();
  
  Console.WriteLine("Enter a file or directory name:");
  filename = Console.ReadLine();
  if (File.Exists(filename)) 
  {
    GetInformation(filename);
	StreamReader stream = null;
	try 
	{
	  using(stream = new StreamReader(filename)) 
	  {
	    sb.Append(stream.ReadToEnd());
		 Console.WriteLine(sb.ToString());
	  }
	}catch(IOException) 
	{
	 Console.WriteLine("Error reading from file.");
	}
  }else if (Directory.Exists(filename)) 
  {
     GetInformation(filename);
	 string[] directoryList = Directory.GetDirectories(filename);
	 sb.Append("Directory contents:");
	 
	 foreach(var directory in directoryList) 
	 { 
	  sb.Append(directory +"\n");
	 }
	 Console.WriteLine(sb.ToString());
  }else {
    Console.WriteLine(filename + "doesn't exists.");
  }
   }
   private static void GetInformation(string filename) 
   {
      Console.WriteLine(filename + "exits.");
	  Console.WriteLine("Created:" + File.GetCreationTime(filename));
	  Console.WriteLine("Last Modified:" + File.GetLastWriteTime(filename));
	  Console.WriteLine("Last Accessed:" + File.GetLastAccessTime(filename));
   }
 }

 
  

}