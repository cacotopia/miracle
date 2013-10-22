using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSetCrossTableLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string strFaculty = "SELECT faculty_id, faculty_name FROM Faculty";
            string strCourse = "SELECT course_id, faculty_id FROM Course";
            OleDbDataAdapter facultyAdapter = new OleDbDataAdapter();
            OleDbDataAdapter courseAdapter = new OleDbDataAdapter();
            OleDbConnection accConnection = new OleDbConnection();
            OleDbCommand facultyCommand = new OleDbCommand();
            OleDbCommand courseCommand = new OleDbCommand();
            DataSet ds = new DataSet();

            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=C:\\database\\Access\\CSE_DEPT.accdb;";
            accConnection = new OleDbConnection(connString);
            accConnection.Open();

            facultyCommand.Connection = accConnection;
            facultyCommand.CommandType = CommandType.Text;
            facultyCommand.CommandText = strFaculty;
            facultyAdapter.SelectCommand = facultyCommand;
            facultyAdapter.Fill(ds, "Faculty");

            courseCommand.Connection = accConnection;
            courseCommand.CommandType = CommandType.Text;
            courseCommand.CommandText = strCourse;
            courseAdapter.SelectCommand = courseCommand;
            courseAdapter.Fill(ds, "Course");

            DataTable faculty = ds.Tables["Faculty"];
            DataTable course = ds.Tables["Course"];
            
            var courseinfo = from ci in course.AsEnumerable()
                             join fi in faculty.AsEnumerable()
                             on ci.Field<string>("faculty_id") equals fi.Field<string>("faculty_id")
                             where fi.Field<string>("faculty_name") == "Ying Bai"
                             select new
                             {
                                 course_id = ci.Field<string>("course_id")
                             };
            foreach (var cid in courseinfo)
            {
                Console.WriteLine(cid.course_id);
            }
            accConnection.Close();
            facultyCommand.Dispose();
            courseCommand.Dispose();
            facultyAdapter.Dispose();
            courseAdapter.Dispose();
        }
    }
}
