using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessUpdateDeleteSP
{
    public partial class LogInForm : Form
    {
        public OleDbConnection accConnection;

        public LogInForm()
        {
            InitializeComponent();
            string accString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                               "Data Source=C:\\database\\Access\\CSE_DEPT.accdb;";

            accConnection = new OleDbConnection(accString);

            try
            {
                accConnection.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("OLE DB Error");
                MessageBox.Show("Error Code = " + e.ErrorCode);
                MessageBox.Show("Error Message = " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("Invalid Connection Message = " + e.Message);
            }
            if (accConnection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database connection is Failed");
                Application.Exit();
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (accConnection.State == ConnectionState.Open)
            {
                accConnection.Close();
                accConnection.Dispose();
            }
            Application.Exit();
        }
        private void cmdTabLogIn_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
            cmdString += "WHERE (user_name=name ) AND (pass_word=word)";

            OleDbDataAdapter LogInDataAdapter = new OleDbDataAdapter();
            DataTable accDataTable = new DataTable();
            OleDbCommand accCommand = new OleDbCommand();
            SelectionForm selForm = new SelectionForm();

            accCommand.Connection = accConnection;
            accCommand.CommandType = CommandType.Text;
            accCommand.CommandText = cmdString;
            accCommand.Parameters.Add("name", OleDbType.Char).Value = txtUserName.Text;
            accCommand.Parameters.Add("word", OleDbType.Char, 8).Value = txtPassWord.Text;
            LogInDataAdapter.SelectCommand = accCommand;
            LogInDataAdapter.Fill(accDataTable);
            if (accDataTable.Rows.Count > 0)
            {
                //MessageBox.Show("LogIn is successful");
                selForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("No matched username/password found!");
            accDataTable.Dispose();
            accCommand.Dispose();
            LogInDataAdapter.Dispose();
        }
        private void cmdReadLogIn_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
            cmdString += "WHERE (user_name=name ) AND (pass_word=word)";

            OleDbCommand accCommand = new OleDbCommand();
            SelectionForm selForm = new SelectionForm();
            OleDbDataReader accDataReader;

            accCommand.Connection = accConnection;
            accCommand.CommandType = CommandType.Text;
            accCommand.CommandText = cmdString;
            accCommand.Parameters.Add("name", OleDbType.Char).Value = txtUserName.Text;
            accCommand.Parameters.Add("word", OleDbType.Char, 8).Value = txtPassWord.Text;
            accDataReader = accCommand.ExecuteReader();
            if (accDataReader.HasRows == true)
            {
                //MessageBox.Show("LogIn is successful");
                selForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("No matched username/password found!");

            accCommand.Dispose();
            accDataReader.Close();
        }
        public LogInForm getLogInForm()
        {
            return this;
        }                      
    }
}
