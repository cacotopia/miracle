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
    public partial class FacultyForm : Form
    {
        InsertFacultyForm InsertFaculty = new InsertFacultyForm();  // add in October 17, 2008.

        public FacultyForm()
        {
            InitializeComponent();          
        }

        private void FacultyForm_Load(object sender, EventArgs e)
        {
            //ComboName.Items.Add("Ying Bai");
            //ComboName.Items.Add("Satish Bhalla");
            //ComboName.Items.Add("Black Anderson");
            //ComboName.Items.Add("Steve Johnson");
            //ComboName.Items.Add("Jenney King");
            //ComboName.Items.Add("Alice Brown");
            //ComboName.Items.Add("Debby Angles");
            //ComboName.Items.Add("Jeff Henry");
            UpdateFaculty();                        // added in oct 23 2008
            ComboName.SelectedIndex = 0;
            this.cmdSelect_Click(this.cmdSelect, null);
            ComboMethod.Items.Add("TableAdapter Method");
            ComboMethod.Items.Add("LINQ & DataSet Method");
            this.ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.ClearBeforeFill = true;
            this.facultyTableAdapter.FillByFacultyName(cSE_DEPTDataSet.Faculty, ComboName.Text);
            if (cSE_DEPTDataSet.Faculty.Count != 0)
            {
                if (this.ComboMethod.Text == "LINQ & DataSet Method")
                    LINQtoDataSet();
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
        
        private void LINQtoDataSet()
        {
            this.facultyTableAdapter.FillByFacultyName(cSE_DEPTDataSet.Faculty, ComboName.Text);
            var facultyinfo = (from fi in cSE_DEPTDataSet.Faculty
                               where fi.Field<string>("faculty_name").Equals(ComboName.Text)
                               select fi);
           foreach (var fRow in facultyinfo)
           {
               this.TitleLabel.Text = fRow.title;
               this.OfficeLabel.Text = fRow.office;
               this.PhoneLabel.Text = fRow.phone;
               this.CollegeLabel.Text = fRow.college;
               this.EmailLabel.Text = fRow.email;
           }
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
    }
}
