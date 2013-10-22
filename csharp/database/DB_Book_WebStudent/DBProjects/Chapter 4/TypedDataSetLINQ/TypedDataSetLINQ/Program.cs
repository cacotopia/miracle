using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypedDataSetLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            CSE_DEPTDataSetTableAdapters.FacultyTableAdapter da = new CSE_DEPTDataSetTableAdapters.FacultyTableAdapter();
            CSE_DEPTDataSet ds = new CSE_DEPTDataSet();
            da.Fill(ds.Faculty);

            var faculty = from fi in ds.Faculty
                          where fi.faculty_name == "Ying Bai"
                          select fi;
            foreach (var f in faculty)
            {
                Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", f.title, f.office, f.phone, f.college, f.email);
            }
        }
    }
}
