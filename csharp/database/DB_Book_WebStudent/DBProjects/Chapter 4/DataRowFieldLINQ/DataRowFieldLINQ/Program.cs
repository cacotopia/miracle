using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRowFieldLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmdString = "SELECT * FROM Faculty";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            OleDbConnection accConnection = new OleDbConnection();
            OleDbCommand accCommand = new OleDbCommand();
            DataSet ds = new DataSet();

            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                         "Data Source=C:\\database\\Access\\CSE_DEPT.accdb;";
            accConnection = new OleDbConnection(connString);
            accConnection.Open();
            accCommand.Connection = accConnection;
            accCommand.CommandType = CommandType.Text;
            accCommand.CommandText = cmdString;

            dataAdapter.SelectCommand = accCommand;
            dataAdapter.Fill(ds, "Faculty");
            DataTable dt = ds.Tables["Faculty"];
            IEnumerable<DataRow> fRow = dt.AsEnumerable();
            
            string FacultyID = (from fi in fRow
                                where fi.Field<string>("faculty_name").Equals("Ying Bai")
                                select fi.Field<string>(dt.Columns[0], DataRowVersion.Current)).
                                Single<string>();
            
            Console.WriteLine("\nThe Selected FacultyID is: {0}", FacultyID);                                       
            accConnection.Close();
        }
    }
}
