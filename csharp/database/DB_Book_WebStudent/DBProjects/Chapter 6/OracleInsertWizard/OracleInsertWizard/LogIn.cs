using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OracleInsertWizard
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        private void cmdLogIn_Click(object sender, EventArgs e)
        {
            SelectionForm selForm = new SelectionForm();
            lOGINTableAdapter1.ClearBeforeFill = true;
            lOGINTableAdapter1.FillByUserNamePassWord(cSE_DEPTDataSet1.LOGIN, txtUserName.Text, txtPassWord.Text);
            if (cSE_DEPTDataSet1.LOGIN.Count == 0)
            {
                MessageBox.Show("No matched username/password found!");
                txtUserName.Clear();
                txtUserName.Focus();
                txtPassWord.Clear();
            }
            else
            {
                selForm.Show();
                this.Hide();
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public LogInForm getLogInForm()
        {
            return this;
        }
        private void cmdPW_Click(object sender, EventArgs e)
        {
            string passWord;

            lOGINTableAdapter1.ClearBeforeFill = true;
            passWord = lOGINTableAdapter1.PassWordQuery(txtUserName.Text);
            if (passWord != String.Empty)
                MessageBox.Show("The Password is: " + passWord);
            else
                MessageBox.Show("No matched password found!");
        }
    }
}
