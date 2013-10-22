using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XEOracleSelectRTObject
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
                MessageBox.Show("Invalid Message = " + e.Message);
            }
            if (oraConnection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database connection is Failed");
                Application.Exit();
            }
        }
        private void cmdTabLogIn_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
            cmdString += "WHERE user_name=:UserName AND pass_word=:PassWord";
            OracleParameter oraUserName = new OracleParameter();
            OracleParameter oraPassWord = new OracleParameter();
            OracleDataAdapter LogInDataAdapter = new OracleDataAdapter();
            OracleCommand oraCommand = new OracleCommand();
            DataTable oraDataTable = new DataTable();
            SelectionForm selForm = new SelectionForm();

            oraUserName.ParameterName = "UserName";
            oraUserName.OracleType = OracleType.Char;		//very important in some applications
            oraUserName.Value = txtUserName.Text;
            oraPassWord.ParameterName = "PassWord";
            oraPassWord.OracleType = OracleType.Char;		//very important in some applications
            oraPassWord.Value = txtPassWord.Text;
            oraCommand.Connection = oraConnection;
            oraCommand.CommandType = CommandType.Text;
            oraCommand.CommandText = cmdString;
            oraCommand.Parameters.Add(oraUserName);
            oraCommand.Parameters.Add(oraPassWord);
            LogInDataAdapter.SelectCommand = oraCommand;
            LogInDataAdapter.Fill(oraDataTable);

            if (oraDataTable.Rows.Count > 0)
            {
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
            cmdString += "WHERE user_name=:UserName AND pass_word=:PassWord";
            OracleParameter oraUserName = new OracleParameter();
            OracleParameter oraPassWord = new OracleParameter();
            OracleCommand oraCommand = new OracleCommand();
            OracleDataReader oraDataReader; 
            SelectionForm selForm = new SelectionForm();

            oraUserName.ParameterName = "UserName";
            oraUserName.OracleType = OracleType.Char;
            oraUserName.Value = txtUserName.Text;
            oraPassWord.ParameterName = "PassWord";
            oraPassWord.OracleType = OracleType.Char;
            oraPassWord.Value = txtPassWord.Text;
            oraCommand.Connection = oraConnection;
            oraCommand.CommandType = CommandType.Text;
            oraCommand.CommandText = cmdString;
            oraCommand.Parameters.Add(oraUserName);
            oraCommand.Parameters.Add(oraPassWord);
            oraDataReader = oraCommand.ExecuteReader();
            if (oraDataReader.HasRows == true)
            {
                selForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("No matched username/password found!");
            oraCommand.Dispose();
            oraDataReader.Close();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            oraConnection.Close();
            oraConnection.Dispose();
            Application.Exit();
        }
        public LogInForm getLogInForm()
        {
            return this;
        }
    }
}
