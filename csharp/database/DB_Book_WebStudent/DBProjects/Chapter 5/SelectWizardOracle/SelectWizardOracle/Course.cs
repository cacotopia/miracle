using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectWizardOracle
{
    public partial class CourseForm : Form
    {
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
            CSE_DEPTDataSetTableAdapters.FACULTYTableAdapter FacultyTableApt =
                                         new CSE_DEPTDataSetTableAdapters.FACULTYTableAdapter();

            string strFacultyID = FacultyTableApt.FindFacultyIDByName(ComboName.Text);
            if (strFacultyID != string.Empty)
            {
                if (this.ComboMethod.Text == "LINQ & DataSet Method")
                    LINQtoDataSet(strFacultyID);
                else
                {
                    this.courseTableAdapter.FillByFacultyID(cSE_DEPTDataSet.COURSE, strFacultyID);
                    if (cSE_DEPTDataSet.COURSE.Count == 0)
                        MessageBox.Show("No Matched Courses Found!");
                }
            }
            else
                MessageBox.Show("No matched faculty_id found!");
        }
        private void LINQtoDataSet(string facultyID)
        {
            this.courseTableAdapter.FillByFacultyID(cSE_DEPTDataSet.COURSE, facultyID);
            var courseinfo = (from ci in cSE_DEPTDataSet.COURSE.AsEnumerable()
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
    }
}
