using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLUpdateDeleteWizard
{
    public partial class FacultyForm : Form
    {
        public FacultyForm()
        {
            InitializeComponent();
        }
        private void FacultyForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cSE_DEPTDataSet.Faculty' table. You can move, or remove it, as needed.
            //this.facultyTableAdapter.Fill(this.cSE_DEPTDataSet.Faculty);
            ComboName.Items.Add("Ying Bai");
            ComboName.Items.Add("Satish Bhalla");
            ComboName.Items.Add("Black Anderson");
            ComboName.Items.Add("Steve Johnson");
            ComboName.Items.Add("Jenney King");
            ComboName.Items.Add("Alice Brown");
            ComboName.Items.Add("Debby Angles");
            ComboName.Items.Add("Jeff Henry");
            ComboName.SelectedIndex = 0;
            this.cmdSelect_Click(this.cmdSelect, null);
            ComboMethod.Items.Add("TableAdapter DBDirect");
            ComboMethod.Items.Add("TableAdapter.Update");
            this.ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.ClearBeforeFill = true;
            string strName = FindName(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Faculty Image Found!");
            else
            {
                this.facultyTableAdapter.FillByFacultyName(cSE_DEPTDataSet.Faculty, ComboName.Text);
                if (cSE_DEPTDataSet.Faculty.Count == 0)
                    MessageBox.Show("No Matched Faculty Found!");
            }
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
            return strName;
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
                else  // TableAdapter Update() method is selected…..
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

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {

        }
    }
}
