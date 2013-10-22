using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NonGenericLINQ
{
    public class Student
    {
        public string StudentName { get; set; }
        public int[] Scores { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrList = new ArrayList();
            arrList.Add(new Student { StudentName = "Svetlana Omelchenko", Scores = new int[] { 98, 92, 81, 60 }});
            arrList.Add(new Student { StudentName = "Claire O’Donnell", Scores = new int[] { 75, 84, 91, 39 }});
            arrList.Add(new Student { StudentName = "Sven Mortensen", Scores = new int[] { 88, 94, 65, 91 }});
            arrList.Add(new Student { StudentName = "Cesar Garcia", Scores = new int[] { 97, 89, 85, 82 }});

            var query = from Student student in arrList
                        where student.Scores[0] > 95
                        select student;

            foreach (Student s in query)
                Console.WriteLine(s.StudentName + ": " + s.Scores[0]);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit... ");
            Console.ReadKey();
        }
    }
}
