using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryMethodSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {5, 10, 8, 3, 6, 12};

            //Query syntax:
            IEnumerable<int> querySyntax = from num in numbers
                                           where num % 2 == 0
                                           orderby num
                                           select num;

            //Method syntax:
            IEnumerable<int> methodSyntax = numbers.Where(num => num % 2 == 0).OrderBy(n => n);
            //Execute the query in query syntax
            foreach (int i in querySyntax)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(System.Environment.NewLine);
            //Execute the query in method syntax
            foreach (int i in methodSyntax)
            {
                Console.Write(i + " ");
            }
            // Keep the console open in debug mode.
            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("Press any key to exit ... ");
            Console.ReadKey();
        }
    }
}
