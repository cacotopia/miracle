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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            ComboName.Items.Add("Erica Johnson");
            ComboName.Items.Add("Ashly Jade");
            ComboName.Items.Add("Holes Smith");
            ComboName.Items.Add("Andrew Woods");
            ComboName.Items.Add("Blue Valley");
            ComboName.SelectedIndex = 0;
            ComboMethod.Items.Add("LINQ to SQL Method");
            ComboMethod.SelectedIndex = 0;
            cmdSelect_Click(this.cmdSelect, null);
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            string strName = string.Empty;

            strName = FindName(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Student's Image Found!");

            var sinfo = logForm.cse_dept.StudentInfo(ComboName.Text);
            foreach (var si in sinfo)
            {
                txtID.Text = si.student_id;
                txtSchoolYear.Text = si.schoolYear;
                txtGPA.Text = si.gpa.ToString();
                txtMajor.Text = si.major;
                txtCredits.Text = si.credits.ToString();
                txtEmail.Text = si.email;
            }
            CourseList.Items.Clear();
            var scinfo = logForm.cse_dept.StudentCourseInfo(txtID.Text);
            foreach (var sc in scinfo)
            {
                CourseList.Items.Add(sc.course_id);
            }
        }
        private string FindName(string sName)
        {
            string strName;

            switch (sName)
            {
                case "Erica Johnson":
                    strName = "Erica.jpg";
                    break;
                case "Ashly Jade":
                    strName = "Ashly.jpg";
                    break;
                case "Holes Smith":
                    strName = "Holes.jpg";
                    break;
                case "Andrew Woods":
                    strName = "Andrew.jpg";
                    break;
                case "Blue Valley":
                    strName = "Blue.jpg";
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
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
