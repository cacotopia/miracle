﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessSelectRTObject
{
    public partial class LogInForm : Form
    {
        public OleDbConnection accConnection;

        public LogInForm()
        {
            InitializeComponent();
            string strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + 
                                         "Data Source=C:\\database\\Access\\CSE_DEPT.accdb;";
            accConnection = new OleDbConnection(strConnectionString);
            try
            {    
                accConnection.Open();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Access Error");
                MessageBox.Show("Error Code = " + e.ErrorCode);
                MessageBox.Show("Error Message = " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("Invalid Message = " + e.Message);
            }
            if (accConnection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database connection is Failed");
                Application.Exit();
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            accConnection.Close();
            accConnection.Dispose();
            Application.Exit();
        }
        private void cmdTabLogIn_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
            cmdString += "WHERE (user_name=@Param1 ) AND (pass_word=@Param2)";
        
            OleDbDataAdapter LogInDataAdapter = new OleDbDataAdapter();
            DataTable accDataTable = new DataTable();
            OleDbCommand accCommand = new OleDbCommand();
            SelectionForm selForm = new SelectionForm();

            accCommand.Connection = accConnection;
            accCommand.CommandType = CommandType.Text;
            accCommand.CommandText = cmdString;
            accCommand.Parameters.Add("@Param1", OleDbType.Char).Value = txtUserName.Text;
            accCommand.Parameters.Add("@Param2", OleDbType.Char, 8).Value = txtPassWord.Text;
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
            cmdString += "WHERE (user_name=@Param1 ) AND (pass_word=@Param2)";

            OleDbCommand accCommand = new OleDbCommand();
            SelectionForm selForm = new SelectionForm();
            OleDbDataReader accDataReader;

            accCommand.Connection = accConnection;
            accCommand.CommandType = CommandType.Text;
            accCommand.CommandText = cmdString;
            accCommand.Parameters.Add("@Param1", OleDbType.Char).Value = txtUserName.Text;
            accCommand.Parameters.Add("@Param2", OleDbType.Char, 8).Value = txtPassWord.Text;
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
