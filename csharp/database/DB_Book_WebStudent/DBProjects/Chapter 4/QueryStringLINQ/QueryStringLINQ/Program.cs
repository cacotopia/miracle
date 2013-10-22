using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; 

namespace QueryStringLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string aString = "ABCDE99F-J74-12-89A";

            // Select only those characters that are numbers
            IEnumerable<char> stringQuery =
              from ch in aString
              where Char.IsDigit(ch)
              select ch;

            // Execute the query
            foreach (char c in stringQuery)
                Console.Write(c + " ");

            // Call the Count method on the existing query.
            int count = stringQuery.Count();
            Console.WriteLine("Count = {0}", count);

            // Select all characters before the first '-'
            IEnumerable<char> stringQuery2 = aString.TakeWhile(c => c != '-');

            // Execute the second query
            foreach (char c in stringQuery2)
                Console.Write(c);

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }
    }
}
