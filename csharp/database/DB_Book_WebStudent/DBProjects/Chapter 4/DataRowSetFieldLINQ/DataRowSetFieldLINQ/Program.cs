using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRowSetFieldLINQ
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
            IEnumerable<DataRow> facultyRow = dt.AsEnumerable();

            DataRow frow = (from fi in facultyRow
                            where fi.Field<string>("faculty_name").Equals("Ying Bai")
                            select fi).Single<DataRow>();
            frow.AcceptChanges();
            frow.SetField("faculty_name", "Susan Bai");
            Console.WriteLine(" Original Faculty Name = {0}:\n Current Faculty Name = {1}",
                frow.Field<string>("faculty_name", DataRowVersion.Original),
                frow.Field<string>("faculty_name", DataRowVersion.Current));
            accConnection.Close();
        }
    }
}
