using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSSQLSelectRTObjectLINQ
{
    public partial class LogInForm : Form
    {
        public CSE_DEPTDataContext cse_dept = new CSE_DEPTDataContext();

        public LogInForm()
        {
            InitializeComponent();
        }

        private void cmdLogIn_Click(object sender, EventArgs e)
        {
            string username = string.Empty;
            string password = string.Empty;
            SelectionForm selForm = new SelectionForm();

            IQueryable<LogIn> loginfo = from lg in cse_dept.LogIns
                                        where lg.user_name == txtUserName.Text && 
                                        lg.pass_word == txtPassWord.Text  
                                        select lg;
            foreach (LogIn log in loginfo)
            {
                username = log.user_name;
                password = log.pass_word;
            }
            if (txtUserName.Text == string.Empty || txtPassWord.Text == string.Empty)
                MessageBox.Show("Enter a valid username/password");
            else if (username == txtUserName.Text && password == txtPassWord.Text)
            {
                //MessageBox.Show("The LogIn is successful!");
                selForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("The LogIn is failed!");
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            cse_dept.Connection.Close();
            Application.Exit();
        }
        public LogInForm getLogInForm()
        {
            return this;
        } 
    }
}
