using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SortLinesLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an IEnumerable data source
            string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

            // Change this to any value from 0 to 4.
            int sortField = 1;

            Console.WriteLine("Sorted highest to lowest by field [{0}]:", sortField);

            // Demonstrates how to return query from a method.
            // The query is executed here.
            foreach (string str in RunQuery(scores, sortField))
            {
                Console.WriteLine(str);
            }
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        // Returns the query variable, not query results!
        static IEnumerable<string> RunQuery(IEnumerable<string> source, int num)
        {
            // Split the string and sort on field[num]
            var scoreQuery = from line in source
                             let fields = line.Split(',')
                             orderby fields[num] descending
                             select line;

            return scoreQuery;
        }
    }
}
