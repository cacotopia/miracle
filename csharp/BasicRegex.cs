//Demostrate basic regular expressions
using System;
using System.Text.RegularExpressions;

class BasicRegex
{
	static void Main(string[] args)
	{
		string testString= "regular expressions are sometimes called regex or regexp";
		Console.WriteLine("The test string is\n  \"{0}\"",testString);
		Console.WriteLine("Match 'e' in the test string:");
		//match 'e' in the test string
		Regex expression = new Regex("e");
		Console.WriteLine(expression.Match(testString));
		Console.WriteLine("Match every 'e' in the test string:");
		foreach( var myMatch in expression.Matches(testString))
			Console.WriteLine("{0}",myMatch);
		Console.WriteLine("\nMatch \"regex\" in the test string:");
		foreach(var myMatch in Regex.Matches(testString,"regex"))
			Console.WriteLine("{0}",myMatch);
		Console.WriteLine("\nMatch \"regex\" or \"regexp\" using an optional 'p': ");
		foreach(var myMatch in Regex.Matches(testString,"regexp?"))
			Console.WriteLine("{0}",myMatch);
		//use alternation to match either 'cat' or 'hat'
		expression =new Regex("(c|h)at)");
		Console.WriteLine("\n\"hat cat\" matches {0},but \"cat hat\" matches {1}",expression.Match("hat cat"),expression.Match("cat hat"));
	}
}
