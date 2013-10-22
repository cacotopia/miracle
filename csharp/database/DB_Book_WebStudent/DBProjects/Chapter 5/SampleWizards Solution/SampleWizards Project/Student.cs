using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SampleWizards_Project
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string strName;

            strName = FindName(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Student Image Found!");
            if (this.ComboMethod.Text == "LINQ & DataSet Method")
                LINQtoDataSet();
            else
            {
                this.studentTableAdapter.ClearBeforeFill = true;
                this.studentTableAdapter.FillByStudentName(cSE_DEPTDataSet.Student, ComboName.Text);
                if (cSE_DEPTDataSet.Student.Count != 0)
                {
                    studentCourseTableAdapter.ClearBeforeFill = true;
                    studentCourseTableAdapter.FillByStudentID(cSE_DEPTDataSet.StudentCourse, txtID.Text);
                }
                else
                    MessageBox.Show("No Matched Student Found!");
            }
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void StudentForm_Load(object sender, EventArgs e)
        {
            this.studentCourseTableAdapter.Fill(this.cSE_DEPTDataSet.StudentCourse);
            ComboName.Items.Add("Erica Johnson");
            ComboName.Items.Add("Ashly Jade");
            ComboName.Items.Add("Holes Smith");
            ComboName.Items.Add("Andrew Woods");
            ComboName.Items.Add("Blue Valley");
            ComboName.SelectedIndex = 0;
            ComboMethod.Items.Add("TableAdapter");
            ComboMethod.Items.Add("LINQ Method");
            ComboMethod.SelectedIndex = 0;
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
        private void LINQtoDataSet()
        {

            this.studentTableAdapter.Fill(this.cSE_DEPTDataSet.Student);
            this.studentCourseTableAdapter.Fill(this.cSE_DEPTDataSet.StudentCourse);
            var studentinfo = (from si in cSE_DEPTDataSet.Student
                               where si.Field<string>("student_name").Equals(ComboName.Text)
                               select si);
            foreach (var sRow in studentinfo)
            {
                this.txtID.Text = sRow.student_id;
                this.txtSchoolYear.Text = sRow.schoolYear;
                this.txtGPA.Text = sRow.gpa;
                this.txtMajor.Text = sRow.major;
                this.txtCredits.Text = sRow.credits.ToString();
                this.txtEmail.Text = sRow.email;
            }
        }        
    }
}
