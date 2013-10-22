using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLUpdateDeleteRTObject
{
    public partial class InsertFacultyForm : Form
    {
        LogInForm logForm = new LogInForm();
        string[] FacultyInfo = new string[7];
        public FacultyForm Faculty_Form;            

        public InsertFacultyForm()
        {
            InitializeComponent();
            logForm = logForm.getLogInForm();
            if (logForm.sqlConnection.State != ConnectionState.Open)
                logForm.sqlConnection.Open();
        }

        private void InitFacultyInfo()
        {
            FacultyInfo[0] = txtID.Text;
            FacultyInfo[1] = txtName.Text;
            FacultyInfo[2] = txtTitle.Text;
            FacultyInfo[3] = txtOffice.Text;
            FacultyInfo[4] = txtPhone.Text;
            FacultyInfo[5] = txtCollege.Text;
            FacultyInfo[6] = txtEmail.Text;
        }

        private int CheckFacultyInfo()
        {
            int pos = 0, check = 0;

            for (pos = 0; pos <= 6; pos++)
            {
                if (FacultyInfo[pos] == string.Empty)
                    check++;
            }
            return check;
        }

        public void setFacultyForm(FacultyForm facultyForm)      // added in nov 16, 2008
        {
            Faculty_Form = facultyForm;
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            Faculty_Form.ComboName.Items.Clear();       	     // added in nov 16, 2008
            Faculty_Form.UpdateFaculty();               	     // added in nov 16, 2008
            Faculty_Form.ComboName.SelectedIndex = 0;    
            this.Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtOffice.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCollege.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhotoName.Focus();
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            int check = 0, intInsert = 0;
            string cmdString = "INSERT INTO Faculty (faculty_id, faculty_name, office, phone, college, title, email) " +
                               "VALUES (@faculty_id,@faculty_name,@office,@phone,@college,@title,@email)";
            SqlDataAdapter FacultyDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand();

            InitFacultyInfo();
            check = CheckFacultyInfo();
            if (check == 0)                 // all textboxes have been filled.
            {
                logForm = logForm.getLogInForm();
                if (chkPhoto.Checked == true && (txtPhotoName.Text == "" || txtPhotoLocation.Text == ""))
                    MessageBox.Show("Photo Name/Photo Location is empty");
                sqlCommand.Connection = logForm.sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = cmdString;
                InsertParameters(sqlCommand);
                //FacultyDataAdapter.InsertCommand = sqlCommand
                //intInsert = FacultyDataAdapter.InsertCommand.ExecuteNonQuery()
                intInsert = sqlCommand.ExecuteNonQuery();
                if (intInsert == 0)
                    MessageBox.Show("The data insertion is failed");
                else
                {
                    cmdCancel.PerformClick();             // clean up all faculty information
                    cmdInsert.Enabled = false;
                }
            }
            else
                MessageBox.Show("Fill all Faculty Information box, enter a NULL for blank column");
        }

        private void InsertParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@faculty_id", SqlDbType.Char).Value = txtID.Text;
            cmd.Parameters.Add("@faculty_name", SqlDbType.Char).Value = txtName.Text;
            cmd.Parameters.Add("@office", SqlDbType.Char).Value = txtOffice.Text;
            cmd.Parameters.Add("@phone", SqlDbType.Char).Value = txtPhone.Text;
            cmd.Parameters.Add("@college", SqlDbType.Char).Value = txtCollege.Text;
            cmd.Parameters.Add("@title", SqlDbType.Char).Value = txtTitle.Text;
            cmd.Parameters.Add("@email", SqlDbType.Char).Value = txtEmail.Text;
        }

        private void chkPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPhoto.Checked == true)
            {
                txtPhotoName.Enabled = true;
                txtPhotoLocation.Enabled = true;
                txtPhotoName.Focus();
            }
            else
            {
                txtPhotoName.Enabled = false;
                txtPhotoLocation.Enabled = false;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            cmdInsert.Enabled = true;
        }
    }
}
