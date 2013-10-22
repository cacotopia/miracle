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
    public partial class CourseForm : Form
    {
        InsertCourseForm InsertCourse = new InsertCourseForm();     // add in November 4, 2008.

        public CourseForm()
        {
            InitializeComponent();
        }
        private void CourseForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cSE_DEPTDataSet1.COURSE' table. You can move, or remove it, as needed.
            this.cOURSETableAdapter1.Fill(this.cSE_DEPTDataSet1.COURSE);
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
            this.cmdSelect_Click(this.cmdSelect, null);
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            CSE_DEPTDataSetTableAdapters.FACULTYTableAdapter FacultyTableApt =
                                         new CSE_DEPTDataSetTableAdapters.FACULTYTableAdapter();

            string strFacultyID = FacultyTableApt.FindFacultyIDByName(ComboName.Text);
            if (strFacultyID != string.Empty)
            {
                if (this.ComboMethod.Text == "LINQ & DataSet Method")
                    LINQtoDataSet(strFacultyID);
                else
                {
                    cOURSETableAdapter1.ClearBeforeFill = true;
                    this.cOURSETableAdapter1.FillByFacultyID(cSE_DEPTDataSet1.COURSE, strFacultyID);
                    if (cSE_DEPTDataSet1.COURSE.Count == 0)
                        MessageBox.Show("No Matched Courses Found!");
                }
            }
            else
                MessageBox.Show("No matched faculty_id found!");
        }
        private void LINQtoDataSet(string facultyID)
        {
            this.cOURSETableAdapter1.FillByFacultyID(cSE_DEPTDataSet1.COURSE, facultyID);
            var courseinfo = (from ci in cSE_DEPTDataSet1.COURSE.AsEnumerable()
                              where ci.FACULTY_ID == facultyID
                              select ci);        
            foreach (var cRow in courseinfo)
            {
                //this.txtName.Text = cRow.course;
                this.txtSchedule.Text = cRow.SCHEDULE;
                this.txtClassRoom.Text = cRow.CLASSROOM;
                this.txtCredits.Text = cRow.CREDIT.ToString();
                this.txtEnroll.Text = cRow.ENROLLMENT.ToString();
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
