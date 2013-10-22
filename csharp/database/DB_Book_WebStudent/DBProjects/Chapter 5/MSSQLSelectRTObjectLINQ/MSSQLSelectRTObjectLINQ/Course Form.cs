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
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
            ComboName.Items.Add("Ying Bai");
            ComboName.Items.Add("Satish Bhalla");
            ComboName.Items.Add("Black Anderson");
            ComboName.Items.Add("Steve Johnson");
            ComboName.Items.Add("Jenney King");
            ComboName.Items.Add("Alice Brown");
            ComboName.Items.Add("Debby Angles");
            ComboName.Items.Add("Jeff Henry");
            ComboName.SelectedIndex = 0;
            ComboMethod.Items.Add("LINQ to SQL Method");
            ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            
            CourseList.Items.Clear();
            var courseinfo = from ci in logForm.cse_dept.Courses
                             join fi in logForm.cse_dept.Faculties on ci.faculty_id equals fi.faculty_id
                             where fi.faculty_name == ComboName.Text
                             select new
                             {
                                 course_id = ci.course_id
                             };
            foreach (var cid in courseinfo)
            {
                CourseList.Items.Add(cid.course_id);
            }
            CourseList.SelectedIndex = 0;
        }
        private void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            IQueryable<Course> cinfo = from ci in logForm.cse_dept.Courses
                                        where ci.course_id == (string)CourseList.SelectedItem
                                        select ci;
            foreach (Course c in cinfo)
            {
                txtName.Text = c.course1;
                txtSchedule.Text = c.schedule;
                txtClassRoom.Text = c.classroom;
                txtCredits.Text = c.credit.ToString();
                txtEnroll.Text = c.enrollment.ToString();
            }
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
