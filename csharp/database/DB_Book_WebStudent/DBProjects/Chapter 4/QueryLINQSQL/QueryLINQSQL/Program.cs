using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace QueryLINQSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            CSE_DEPTDataContext cse_dept = new CSE_DEPTDataContext();

            Console.WriteLine("Make your selection:\n");
            Console.WriteLine("1: LINQ to SQL Select query");
            Console.WriteLine("2: LINQ to SQL Insert query");
            Console.WriteLine("3: LINQ to SQL Update query");
            Console.WriteLine("4: LINQ to SQL Delete query");
            Console.WriteLine("5: Exit the project\n");
            string input = Console.ReadLine();
            switch (input.ToString())
            {
                case "1":
                    LINQSelect(cse_dept);
                    break;
                case "2":
                    LINQInsert(cse_dept);
                    break;
                case "3":
                    LINQUpdate(cse_dept);
                    break;
                case "4":
                    LINQDelete(cse_dept);
                    break;
                default:
                    break;
            }
            // Keep the console window open after activity stops.
            Console.WriteLine("Press Enter key to continue ....");
            Console.ReadLine();
        }
        public static void LINQSelect(CSE_DEPTDataContext db)
        {
            var faculty = (from fi in db.Faculties
                           where fi.faculty_id == "B78880"
                           select fi);
            foreach (var f in faculty)
            {
               Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", f.faculty_name, f.title, 
                                                   f.office, f.phone, f.college, f.email);
            }
        }
        public static void LINQInsert(CSE_DEPTDataContext db)
        {
            // Create the new Faculty object.
            Faculty newFaculty = new Faculty();
            newFaculty.faculty_id = "D19886";
            newFaculty.faculty_name = "David Winner";
            newFaculty.title = "Department Chair";
            newFaculty.office = "MTC-333";
            newFaculty.phone = "750-330-1255";
            newFaculty.college = "University of Hawaii";
            newFaculty.email = "dwinner@college.edu";

            // Add the faculty to the Faculty table.
            db.Faculties.InsertOnSubmit(newFaculty);
            db.SubmitChanges();
            // Query back the new inserted faculty member
            Faculty fi = db.Faculties.Where(f => f.faculty_id == "D19886").First();
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", fi.faculty_name, fi.title,
                                                   fi.office, fi.phone, fi.college, fi.email);
            // Reset the database by deleting the new inserted faculty
            db.Faculties.DeleteOnSubmit(newFaculty);
            db.SubmitChanges();
        }
        public static void LINQUpdate(CSE_DEPTDataContext db)
        {
            Faculty fi = db.Faculties.Where(f => f.faculty_id == "B78880").First();
            // Display the existing faculty information
            Console.WriteLine("Before the Faculty table is updated....\n");
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", fi.faculty_name, fi.title,
                                                   fi.office, fi.phone, fi.college, fi.email);
            // Change the faculty name.
            fi.faculty_name = "New Faculty";
            db.SubmitChanges();
            Console.WriteLine("After the Faculty table is updated....\n");
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", fi.faculty_name, fi.title,
                                                   fi.office, fi.phone, fi.college, fi.email);
            // Recover the original column for the Faculty table
            fi.faculty_name = "Ying Bai";
            db.SubmitChanges();
        }
        public static void LINQDelete(CSE_DEPTDataContext db)
        {
            var faculty = (from fi in db.Faculties
                           where fi.faculty_id == "B78880"
                           select fi).Single<Faculty>();
            db.Faculties.DeleteOnSubmit(faculty);
            db.SubmitChanges();
            // Try to retrieve back and display the deleted faculty information
            var delfaculty = (from fi in db.Faculties
                              where fi.faculty_id == "B78880"
                              select fi).SingleOrDefault<Faculty>();
            Console.WriteLine("Faculty {0} found.\n", delfaculty != null? "is":"is not");
        }
    }
}
