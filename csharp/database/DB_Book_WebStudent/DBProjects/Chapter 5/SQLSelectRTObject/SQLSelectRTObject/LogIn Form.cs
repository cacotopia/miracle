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

namespace SQLSelectRTObject
{
    public partial class LogInForm : Form
    {
        public SqlConnection sqlConnection;

        public LogInForm()
        {
            InitializeComponent();
            string sqlString = "Server=localhost;Data Source=.\\SQLEXPRESS;" +
                               "Database=C:\\database\\SQLServer\\CSE_DEPT.mdf;Integrated Security=SSPI";
            sqlConnection = new SqlConnection(sqlString);

            try
            {
                sqlConnection.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show("SQL Server Error");
                MessageBox.Show("Error Code = " + e.ErrorCode);
                MessageBox.Show("Error Message = " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("Invalid Connection Message = " + e.Message);
            }
            if (sqlConnection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database connection is Failed");
                Application.Exit();
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            Application.Exit();
        }
        private void cmdTabLogIn_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
            cmdString += "WHERE (user_name=@name ) AND (pass_word=@word)";

            SqlDataAdapter LogInDataAdapter = new SqlDataAdapter();
            DataTable sqlDataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            SelectionForm selForm = new SelectionForm();

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.Add("@name", SqlDbType.Char).Value = txtUserName.Text;
            sqlCommand.Parameters.Add("@word", SqlDbType.Char, 8).Value = txtPassWord.Text;
            LogInDataAdapter.SelectCommand = sqlCommand;
            LogInDataAdapter.Fill(sqlDataTable);
            if (sqlDataTable.Rows.Count > 0)
            {
                //MessageBox.Show("LogIn is successful");
                selForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("No matched username/password found!");
            sqlDataTable.Dispose();
            sqlCommand.Dispose();
            LogInDataAdapter.Dispose();
        }
        private void cmdReadLogIn_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
            cmdString += "WHERE (user_name=@name ) AND (pass_word=@word)";

            SqlCommand sqlCommand = new SqlCommand();
            SelectionForm selForm = new SelectionForm();
            SqlDataReader sqlDataReader;

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.Add("@name", SqlDbType.Char).Value = txtUserName.Text;
            sqlCommand.Parameters.Add("@word", SqlDbType.Char, 8).Value = txtPassWord.Text;
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows == true)
            {
                //MessageBox.Show("LogIn is successful");
                selForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("No matched username/password found!");

            sqlCommand.Dispose();
            sqlDataReader.Close();
        }
        public LogInForm getLogInForm()
        {
            return this;
        }                      
    }
}
