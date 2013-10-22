using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InsertWizard_Project
{
    public partial class InsertFacultyForm : Form
    {
        //private Dictionary<string, string> FacultyCollection = new System.Collections.Generic.Dictionary<string, string>();
        private Dictionary<string, string> FacultyCollection = new Dictionary<string, string>();
        public FacultyForm Faculty_Form;            // added in oct 23, 2008

        public InsertFacultyForm()
        {
            InitializeComponent();
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            int check = 0, intInsert = 0;
            CSE_DEPTDataSet.FacultyRow newFacultyRow;

            CreateFacultyCollection();
            check = CheckFacultyCollection();
            if (check == 0)
            {
                //MessageBox.Show("OK, No problem and no TextBox is empty...");
                if (chkPhoto.Checked == true && (txtPhotoName.Text == "" || txtPhotoLocation.Text == ""))
                    MessageBox.Show("Photo Name/Photo Location is empty");
                if (comboMethod.Text == "TableAdapter Insert")
                    intInsert = facultyTableAdapter.InsertFaculty(txtID.Text, txtName.Text, txtOffice.Text, 
                                                txtPhone.Text, txtCollege.Text, txtTitle.Text, txtEmail.Text);
                else
                {
                    newFacultyRow = this.cSE_DEPTDataSet.Faculty.NewFacultyRow();
                    InsertFacultyRow(ref newFacultyRow);
                    cSE_DEPTDataSet.Faculty.Rows.Add(newFacultyRow);
                    intInsert = facultyTableAdapter.Update(cSE_DEPTDataSet.Faculty);
                }
                if (intInsert != 0)                     // data insertion is successful
                {
                    cmdCancel.PerformClick();           // clean up all faculty information
                    cmdInsert.Enabled = false;          // disable the Insert button 
                }
                else
                {
                    MessageBox.Show("The data insertion is failed");
                    cmdInsert.Enabled = true;
                }
            }
            RemoveFacultyCollection();
        }

        private void InsertFacultyRow(ref CSE_DEPTDataSet.FacultyRow facultyRow)
        {
            facultyRow.faculty_id = txtID.Text;
            facultyRow.faculty_name = txtName.Text;
            facultyRow.office = txtOffice.Text;
            facultyRow.phone = txtPhone.Text;
            facultyRow.college = txtCollege.Text;
            facultyRow.title = txtTitle.Text;
            facultyRow.email = txtEmail.Text;
        }
   
        private void CreateFacultyCollection()
        {
            FacultyCollection.Add("Faculty ID", txtID.Text);
            FacultyCollection.Add("Faculty Name", txtName.Text);
            FacultyCollection.Add("Faculty Title", txtTitle.Text);
            FacultyCollection.Add("Faculty Office", txtOffice.Text);
            FacultyCollection.Add("Faculty Phone", txtPhone.Text);
            FacultyCollection.Add("Faculty College", txtCollege.Text);
            FacultyCollection.Add("Faculty Email", txtEmail.Text);           
        }
        private int CheckFacultyCollection()
        {
            int check = 0;
            foreach (KeyValuePair<string, string> strCheck in FacultyCollection)
            {
                if (strCheck.Value == string.Empty)
                {
                    MessageBox.Show(strCheck.Key + " is empty!");
                    check++;
                }
            }
            return check;
        }
        private void RemoveFacultyCollection()
        {
            FacultyCollection.Remove("Faculty ID");
            FacultyCollection.Remove("Faculty Name");
            FacultyCollection.Remove("Faculty Title");
            FacultyCollection.Remove("Faculty Office");
            FacultyCollection.Remove("Faculty Phone");
            FacultyCollection.Remove("Faculty College");
            FacultyCollection.Remove("Faculty Email");
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            Faculty_Form.ComboName.Items.Clear();       // added in oct 23, 2008
            Faculty_Form.UpdateFaculty();               // added in oct 23, 2008
            Faculty_Form.ComboName.SelectedIndex = 0;   // added in oct 23, 2008
            this.Hide();
        }

        private void InsertFacultyForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cSE_DEPTDataSet.Faculty' table. You can move, or remove it, as needed.
            //this.facultyTableAdapter.Fill(this.cSE_DEPTDataSet.Faculty);
            comboMethod.Items.Add("TableAdapter Insert");
            comboMethod.Items.Add("TableAdapter Update");
            comboMethod.SelectedIndex = 0;
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtOffice.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCollege.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhotoName.Focus();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            cmdInsert.Enabled = true;
        }

        public void setFacultyForm(FacultyForm facultyForm)         // added in oct 23, 2008
        {
            Faculty_Form = facultyForm;
        }
    }
}
        