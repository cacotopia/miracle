using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQSQLQuery
{
    public partial class FacultyForm : Form
    {
        CSE_DEPTDataContext cse_dept = new CSE_DEPTDataContext();

        public FacultyForm()
        {
            InitializeComponent();
            UpdateFaculty();
            ComboName.SelectedIndex = 0;
        }

        void UpdateFaculty()
        {
            var faculty = (from fi in cse_dept.Faculties
                           let fields = "faculty_name"
                           select fi);
            foreach (var f in faculty)
            {
                ComboName.Items.Add(f.faculty_name);
            }
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string strName = ShowFaculty(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Faculty Image found!");

            var faculty = (from fi in cse_dept.Faculties
                           where fi.faculty_name == ComboName.Text
                           select fi);
            
            foreach (var f in faculty)
            {
               txtName.Text = f.faculty_name;
               txtTitle.Text = f.title;
               txtOffice.Text = f.office;
               txtPhone.Text = f.phone;
               txtCollege.Text = f.college;
               txtEmail.Text = f.email;
           }
        }
        
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            Faculty fi = cse_dept.Faculties.Where(f => f.faculty_name == ComboName.Text).First();
            // updating the existing faculty information
            fi.faculty_name = txtName.Text;
            fi.title = txtTitle.Text;
            fi.office = txtOffice.Text;
            fi.phone = txtPhone.Text;
            fi.college = txtCollege.Text;
            fi.email = txtEmail.Text;
            cse_dept.SubmitChanges();
            ComboName.Items.Clear();
            UpdateFaculty();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            var faculty = (from fi in cse_dept.Faculties
                           where fi.faculty_name == ComboName.Text
                           select fi).Single<Faculty>();
            cse_dept.Faculties.DeleteOnSubmit(faculty);
            cse_dept.SubmitChanges();
            // clean up all textboxes
            txtName.Text = string.Empty;
            txtOffice.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtPhone.Text= string.Empty;
            txtCollege.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
        
        private void cmdInsert_Click(object sender, EventArgs e)
        {
            Faculty newFaculty = new Faculty();
            newFaculty.faculty_id = "D19886";
            newFaculty.faculty_name = txtName.Text;
            newFaculty.title = txtTitle.Text;
            newFaculty.office = txtOffice.Text;
            newFaculty.phone = txtPhone.Text;
            newFaculty.college = txtCollege.Text;
            newFaculty.email = txtEmail.Text;

            // Add the faculty to the Faculty table.
            cse_dept.Faculties.InsertOnSubmit(newFaculty);
            cse_dept.SubmitChanges();
        }

        private string ShowFaculty(string fName)
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
    }
}
