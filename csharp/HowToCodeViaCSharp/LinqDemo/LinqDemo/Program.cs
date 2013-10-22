/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2013/10/14
 * 时间: 19:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;


namespace LinqDemo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			
			//StringQuery();
			Console.WriteLine("---------------------");
			//SortedLines();
			Console.WriteLine("---------------------");
			//QueryContents();
			Console.WriteLine("---------------------");
			queryReflection();
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//演示LINO 查询字符串
		static void StringQuery()
		{
			String aString = "ABCDEF99F-12-BGY-124889-WE";
			IEnumerable<char> stringQuery = from ch in aString
				where Char.IsDigit(ch)
				select ch;
			foreach (char  cc in stringQuery) {
				Console.Write(cc+" ");
			}
			Console.WriteLine("Count= {0}",stringQuery.Count());
			IEnumerable<char> stringQuery2 = aString.TakeWhile(c=>c!='-');
			foreach (var ch in stringQuery2) {
				Console.WriteLine(ch);
			}
		}
		//Linq查询排序
		static void SortedLines()
		{
			String[] scores =System.IO.File.ReadAllLines("scores.csv");
			Int32 sortField= 0;
			Console.WriteLine("Sorted hightest to lowest by field{0}",sortField);
			foreach (String  str in RunQuery(scores,sortField)) {
				Console.WriteLine(str);
			}
			
		}
		static IEnumerable<String> RunQuery(IEnumerable<String> source,Int32 num)
		{
			var scoreQuery = from line in source
				let fields = line.Split(',')
				orderby fields[num] descending
				select line;
			return scoreQuery;
		}
		//Linq 与文件目录
		//查询文件夹中所有文件的内容
		#region "QueryContentsLinq"
		static void QueryContents()
		{
		//String startFolder = @"C:\Program Files\Microsoft Visual Studio 9.0\";
		String startFolder =@"D:\Program Files\Microsoft Visual Studio 9.0\";
		IEnumerable<System.IO.FileInfo> fileList = GetFiles(startFolder);
	    String searchTerm = @"Visual Studio";
	    var queryMatchingFiles = from file in fileList
	    	where file.Extension == ".htm"
	    	let fileText = GetFileText(file.FullName)
	    	where fileText.Contains(searchTerm)
	    	select file.FullName;
	    Console.WriteLine("The Term \"{0}\" was found in:",searchTerm);
	    foreach (String filename in queryMatchingFiles)
	    {
	    	Console.WriteLine(filename);
	    }
		}
		static String GetFileText(String name)
		{
			String fileContents = String.Empty;
			if (File.Exists(name))
			{
				fileContents = System.IO.File.ReadAllText(name);
		    }
			return fileContents;
		}
		static IEnumerable<System.IO.FileInfo> GetFiles(String path)
		{
			if(!System.IO.Directory.Exists(path))
			{
				throw new System.IO.DirectoryNotFoundException();
			}
			String[] fileNames = null;
			List<FileInfo> files = new List<FileInfo>();
			fileNames = System.IO.Directory.GetFiles(path,"*.*",System.IO.SearchOption.AllDirectories);
			foreach (String name in fileNames) {
				files.Add(new System.IO.FileInfo(name));
			}
			return files;
		}
		
		#endregion
		//Linq 与反射
		static void queryReflection()
		{
			Assembly assemble = Assembly.Load("System.Core,Version=3.5.0.0,Culture=neutral,"+
			                                 "PublicKeyToken =b77a5c561934e089");
			if (assemble ==null)
			{
				Console.WriteLine(" Assemble load failed...");
				return ;
			}
			var pubTypesQuery = from type in assemble.GetTypes()
				where type.IsPublic
				from method in type.GetMethods()
				where method.ReturnType.IsArray== true ||
				(method.ReturnType.GetInterface(typeof(System.Collections.Generic.IEnumerable<>).FullName)!=null
				&& method.ReturnType.FullName!="System.String")
				group method.ToString() by type.ToString();
				//select type
				foreach (var groupOfMethods in pubTypesQuery) {
					Console.WriteLine("Type:{0}",groupOfMethods.Key);
					foreach (var method in groupOfMethods) {
						Console.WriteLine(" {0}",method);
					}
				}
		}
		//基于方法的查询语法
		static void queryMethodSyntax()
		{
			Int32[] numbers = new Int32[] {5,10,8,36,13};
			//Query Syntax
			IEnumerable<Int32> querySyntax = from num in numbers
				where numbers %2 ==0
				orderby num
				select num;
			//Method Syntax
			IEnumerable<Int32> methodSyntax = numbers.Where(num => num %2 ==0).OrderBy(n=>n);
			foreach (Int32  i in querySyntax) {
				Console.Write(i +" ");
			}
			Console.WriteLine();
			foreach (Int32 i in methodSyntax) {
				Console.Write(i +" ");
			}
			Console.WriteLine();
			
		}
	}
}