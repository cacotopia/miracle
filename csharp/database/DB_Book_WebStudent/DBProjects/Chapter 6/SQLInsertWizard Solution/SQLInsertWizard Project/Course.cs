using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLInsertWizard
{
    public partial class CourseForm : Form
    {
        InsertCourseForm InsertCourse = new InsertCourseForm();     // add in November 4, 2008.

        public CourseForm()
        {
            InitializeComponent();
        }
        private void CourseForm_Load(object sender, EventArgs e)
        {
            this.ComboName.Items.Add("Ying Bai");
            ComboName.Items.Add("Satish Bhalla");
            ComboName.Items.Add("Black Anderson");
            ComboName.Items.Add("Steve Johnson");
            ComboName.Items.Add("Jenney King");
            ComboName.Items.Add("Alice Brown");
            ComboName.Items.Add("Debby Angles");
            ComboName.Items.Add("Jeff Henry");
            ComboName.SelectedIndex = 0;
            ComboMethod.Items.Add("TableAdapter Method");
            ComboMethod.Items.Add("LINQ & DataSet Method");
            this.ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            CSE_DEPTDataSetTableAdapters.FacultyTableAdapter FacultyTableApt = 
                                         new CSE_DEPTDataSetTableAdapters.FacultyTableAdapter();

            string strFacultyID = FacultyTableApt.FindFacultyIDByName(ComboName.Text);
            if (strFacultyID != string.Empty)
            {
                if (this.ComboMethod.Text == "LINQ & DataSet Method")
                    LINQtoDataSet(strFacultyID);
                else
                {
                    courseTableAdapter.ClearBeforeFill = true;
                    this.courseTableAdapter.FillByFacultyID(cSE_DEPTDataSet.Course, strFacultyID);
                    if (cSE_DEPTDataSet.Course.Count == 0)
                        MessageBox.Show("No Matched Courses Found!");
                }
            }
            else
                MessageBox.Show("No matched faculty_id found!");
        }
        private void LINQtoDataSet(string facultyID)
        {
            this.courseTableAdapter.FillByFacultyID(cSE_DEPTDataSet.Course, facultyID);
            var courseinfo = (from ci in cSE_DEPTDataSet.Course.AsEnumerable()
                              where ci.faculty_id == facultyID
                              select ci);        
            foreach (var cRow in courseinfo)
            {
                //this.txtName.Text = cRow.course;
                this.txtSchedule.Text = cRow.schedule;
                this.txtClassRoom.Text = cRow.classroom;
                this.txtCredits.Text = cRow.credit.ToString();
                this.txtEnroll.Text = cRow.enrollment.ToString();
            }
        }    
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            InsertCourse.Show();
        }        
    }
}
