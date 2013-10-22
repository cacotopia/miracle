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
    public partial class SelectionForm : Form
    {
        FacultyForm facultyForm = new FacultyForm();
        CourseForm courseForm = new CourseForm();
        StudentForm studentForm = new StudentForm();

        public SelectionForm()
        {
            InitializeComponent();
            this.ComboSelection.Items.Add("Faculty Information");
            this.ComboSelection.Items.Add("Course Information");
            this.ComboSelection.Items.Add("Student Information");
            this.ComboSelection.SelectedIndex = 0;
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.ComboSelection.Text == "Faculty Information")
                facultyForm.Show();
            else if (this.ComboSelection.Text == "Course Information")
                courseForm.Show();
            else if (this.ComboSelection.Text == "Student Information")
                studentForm.Show();
            else
                MessageBox.Show("Invalid Selection!");
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            logForm.Close();
            courseForm.Close();
            facultyForm.Close();
            studentForm.Close();
            Application.Exit();
        }
    }
}
