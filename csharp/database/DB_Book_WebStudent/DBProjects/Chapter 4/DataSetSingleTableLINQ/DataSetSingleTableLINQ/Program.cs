using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace DataSetSingleTableLINQ
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
            var facultyinfo = (from fi in ds.Tables["Faculty"].AsEnumerable()
                               where fi.Field<string>("faculty_name").Equals("Ying Bai")
                               select fi);
            foreach (var fRow in facultyinfo)
            {
                Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", fRow.Field<string>("title"), fRow.Field<string>("office"),
                              fRow.Field<string>("phone"), fRow.Field<string>("college"), fRow.Field<string>("email"));
            }
            accConnection.Close();
        }
    }
}
