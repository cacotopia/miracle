//demostrate using character classes and quantifiers

using System;
using System.Text.RegularExpressions;
class CharacterClasses
{
	static void Main(string [] args)
	{
		string testString="abc,DEF,123";
		Console.WriteLine("The test string is: {0}\"",testString);
		//find the digits in the string
		Console.WriteLine("Match any digit:");
		DisplayMatches(testString,@"\d");

		//find anything that isn't a digit
		Console.WriteLine("\nMatch any non-digit:");
                DisplayMatches(testString,@"\D");

		//find the word characters in the test string
		Console.WriteLine("\nMatch any word character:");
		DisplayMatches(testString,@"\w");

		//find sequence of word characters
		Console.WriteLine("\nMatch a group of at least one word character:");
		DisplayMatches(testString,@"\w+");

		//use a lazy quantifier
		Console.WriteLine("\nMatch a group of at least one world character(lazy):");
		DisplayMatches(testString,@"\w+?");

		//match characters from 'a' to 'f'
		Console.WriteLine("\nMatch anything from 'a'-'f': ");
		DisplayMatches(testString,"[a-f]");

		//match anything that isn't in the range 'a' to 'f'
		Console.WriteLine("\nMatch anything not from 'a' -'f':");
		DisplayMatches(testString,"[^a-f]");

		//match any sequence of letters in any case
		Console.WriteLine("\nMatch a group of at least one letter:");
		DisplayMatches(testString,"[a-zA-Z]+");

		//use the .dot metacharacter to match any character
		Console.WriteLine("\nMatch a group of any characters:");
		DisplayMatches(testString,".*");
	}//end Main
	private static void DisplayMatches(string input,string expression)
	{
		foreach( var regexMatch in Regex.Matches(input,expression))
			Console.Write("{0}",regexMatch);
		Console.WriteLine();
	}
}

