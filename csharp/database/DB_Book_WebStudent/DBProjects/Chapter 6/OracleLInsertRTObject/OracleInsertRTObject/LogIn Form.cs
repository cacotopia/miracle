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
using System.Data.OracleClient;

namespace OracleInsertRTObject
{
    public partial class LogInForm : Form
    {
        public OracleConnection oraConnection;

        public LogInForm()
        {
            InitializeComponent();
            string oraString = "Data Source = XE;" +
                               "User ID = CSE_DEPT;" +
                               "Password = reback";
            oraConnection = new OracleConnection(oraString);

            try
            {
                oraConnection.Open();
            }
            catch (OracleException e)
            {
                MessageBox.Show("Oracle Error");
                MessageBox.Show("Error Code = " + e.ErrorCode);
                MessageBox.Show("Error Message = " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("Invalid Connection Message = " + e.Message);
            }
            if (oraConnection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database connection is Failed");
                Application.Exit();
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (oraConnection.State == ConnectionState.Open)
            {
                oraConnection.Close();
                oraConnection.Dispose();
            }
            Application.Exit();
        }
        private void cmdTabLogIn_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
            cmdString += "WHERE (user_name=: name ) AND (pass_word=: word)";

            OracleDataAdapter LogInDataAdapter = new OracleDataAdapter();
            DataTable oraDataTable = new DataTable();
            OracleCommand oraCommand = new OracleCommand();
            SelectionForm selForm = new SelectionForm();

            oraCommand.Connection = oraConnection;
            oraCommand.CommandType = CommandType.Text;
            oraCommand.CommandText = cmdString;
            oraCommand.Parameters.Add("name", OracleType.Char).Value = txtUserName.Text;
            oraCommand.Parameters.Add("word", OracleType.Char, 8).Value = txtPassWord.Text;
            LogInDataAdapter.SelectCommand = oraCommand;
            LogInDataAdapter.Fill(oraDataTable);
            if (oraDataTable.Rows.Count > 0)
            {
                //MessageBox.Show("LogIn is successful");
                selForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("No matched username/password found!");
            oraDataTable.Dispose();
            oraCommand.Dispose();
            LogInDataAdapter.Dispose();
        }
        private void cmdReadLogIn_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
            cmdString += "WHERE (user_name=: name) AND (pass_word=: word)";

            OracleCommand oraCommand = new OracleCommand();
            SelectionForm selForm = new SelectionForm();
            OracleDataReader oraDataReader;

            oraCommand.Connection = oraConnection;
            oraCommand.CommandType = CommandType.Text;
            oraCommand.CommandText = cmdString;
            oraCommand.Parameters.Add("name", OracleType.Char).Value = txtUserName.Text;
            oraCommand.Parameters.Add("word", OracleType.Char, 8).Value = txtPassWord.Text;
            oraDataReader = oraCommand.ExecuteReader();
            if (oraDataReader.HasRows == true)
            {
                //MessageBox.Show("LogIn is successful");
                selForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("No matched username/password found!");

            oraCommand.Dispose();
            oraDataReader.Close();
        }
        public LogInForm getLogInForm()
        {
            return this;
        }                      
    }
}
