using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessUpdateDeleteWizard_Project
{
    public partial class FacultyForm : Form
    {
        InsertFacultyForm InsertFaculty = new InsertFacultyForm();  // add in October 17, 2008.

        public FacultyForm()
        {
            InitializeComponent();          
        }

        private void FacultyForm_Load(object sender, EventArgs e)
        {
            UpdateFaculty();                        // added in oct 23 2008
            ComboName.SelectedIndex = 0;
            this.cmdSelect_Click(this.cmdSelect, null);
            ComboMethod.Items.Add("TableAdapter DBDirect");
            ComboMethod.Items.Add("TableAdapter.Update");
            this.ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.ClearBeforeFill = true;
            this.facultyTableAdapter.FillByFacultyName(cSE_DEPTDataSet.Faculty, ComboName.Text);
            if (cSE_DEPTDataSet.Faculty.Count != 0)
            {
                string strName = FindName(ComboName.Text);
                if (strName == "No Match")
                    MessageBox.Show("No Matched Faculty Image Found!");
            }
            else
                MessageBox.Show("No Matched Faculty Found!");
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            InsertFaculty.Close();                          // add in october 17, 2008.
            this.Hide();
        }
        private string FindName(string fName)
        {
            string strName;
            switch (fName)
            {
                case "Black Anderson":
                    strName = "Anderson.jpg";
                    break;
                case "Ying Bai":
                    strName = "Bai.jpg";
                    break;
                case "Satish Bhalla":
                    strName = "Satish.jpg";
                    break;
                case "Steve Johnson":
                    strName = "Johnson.jpg";
                    break;
                case "Jenney King":
                    strName = "King.jpg";
                    break;
                case "Alice Brown":
                    strName = "Brown.jpg";
                    break;
                case "Debby Angles":
                    strName = "Angles.jpg";
                    break;
                case "Jeff Henry":
                    strName = "Henry.jpg";
                    break;
                default:
                    strName = "No Match";
                    break;
            }

            if (strName != "No Match")
            {
                PhotoBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PhotoBox.Image = System.Drawing.Image.FromFile(strName);
            }
            else           // added in oct 23, 2008
            {
                PhotoBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if ((InsertFaculty.chkPhoto.Checked == true)&&(InsertFaculty.txtPhotoLocation.Text=="Default Location"))
                {
                    strName = InsertFaculty.txtPhotoName.Text;
                    PhotoBox.Image = System.Drawing.Image.FromFile(strName);
                }
                if ((InsertFaculty.chkPhoto.Checked == true) && (InsertFaculty.txtPhotoLocation.Text != "Default Location"))
                {
                    strName = InsertFaculty.txtPhotoLocation.Text + "\\" + InsertFaculty.txtPhotoName.Text;
                    PhotoBox.Image = System.Drawing.Image.FromFile(strName);
                }
            }
            return strName;
        }
        
        private void cmdInsert_Click(object sender, EventArgs e)            // added in October 17, 2008.
        {
            InsertFaculty.setFacultyForm(this);                             // added in oct 23, 2008
            InsertFaculty.Show();
        }

        public void UpdateFaculty()                                         // added in oct 21, 2008
        {
            DataColumn col = cSE_DEPTDataSet.Faculty.faculty_nameColumn;
            
            this.facultyTableAdapter.Fill(cSE_DEPTDataSet.Faculty);
            foreach (DataRow row in cSE_DEPTDataSet.Faculty.Rows)
            {
                ComboName.Items.Add(row[col].ToString());
            }
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            CSE_DEPTDataSet.FacultyRow FacultyRow;
            int intUpdate = 0;
            string strFacultyID;

            if (ComboMethod.Text == "TableAdapter DBDirect")
                intUpdate = facultyTableAdapter.UpdateFaculty(txtName.Text, txtOffice.Text, txtPhone.Text, 
                                                      txtCollege.Text, txtTitle.Text, txtEmail.Text, ComboName.Text);
            else       // TableAdapter Update method selected
            {
                strFacultyID = facultyTableAdapter.FindFacultyIDByName(ComboName.Text);
                FacultyRow = cSE_DEPTDataSet.Faculty.FindByfaculty_id(strFacultyID);
                FacultyRow = UPFacultyRow(ref FacultyRow);
                this.Validate();
                facultyBindingSource.EndEdit();
                intUpdate = facultyTableAdapter.Update(cSE_DEPTDataSet.Faculty);
            }
            if (intUpdate == 0)
                MessageBox.Show("Faculty Table Updating is failed!");      
        }
        private CSE_DEPTDataSet.FacultyRow UPFacultyRow(ref CSE_DEPTDataSet.FacultyRow fRow)
        {
            fRow.faculty_name = txtName.Text;
            fRow.office = txtOffice.Text;
            fRow.phone = txtPhone.Text;
            fRow.title = txtTitle.Text;
            fRow.college = txtCollege.Text;
            fRow.email = txtEmail.Text;
            return fRow;
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            MessageBoxButtons vbButton = MessageBoxButtons.YesNo;
            CSE_DEPTDataSet.FacultyRow FacultyRow;
            DialogResult Answer;
            string strFacultyID;
            int intDelete = 0;

            Answer = MessageBox.Show("Sure to delete this record?", "Delete", vbButton);
            if (Answer == System.Windows.Forms.DialogResult.Yes)
            {
                if (ComboMethod.Text == "TableAdapter DBDirect")
                    intDelete = facultyTableAdapter.DeleteFaculty(ComboName.Text);
                else   // TableAdapter Update() method is selected…..
                {
                    strFacultyID = facultyTableAdapter.FindFacultyIDByName(ComboName.Text);
                    FacultyRow = cSE_DEPTDataSet.Faculty.FindByfaculty_id(strFacultyID);
                    FacultyRow.Delete();            // delete data from the DataTable in DataSet
                    intDelete = facultyTableAdapter.Update(cSE_DEPTDataSet.Faculty);            
                }
            }
            if (intDelete == 0)
                MessageBox.Show("Faculty Table Deleting is failed!");
        }
    }
}
