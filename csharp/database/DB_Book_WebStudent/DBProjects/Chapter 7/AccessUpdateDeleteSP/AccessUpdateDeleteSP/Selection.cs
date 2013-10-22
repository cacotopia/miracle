using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessUpdateDeleteSP
{
    public partial class SelectionForm : Form
    {
        FacultyForm facultyForm = new FacultyForm();
        CourseForm courseForm = new CourseForm();
        StudentForm studentForm = new StudentForm();
        SPForm spForm = new SPForm();

        public SelectionForm()
        {
            InitializeComponent();
            this.ComboSelection.Items.Add("Faculty Information");
            this.ComboSelection.Items.Add("Course Information");
            this.ComboSelection.Items.Add("Student Information");
            this.ComboSelection.Items.Add("SP Information");
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
            else if (this.ComboSelection.Text == "SP Information")
                spForm.Show();
            else
                MessageBox.Show("Invalid Selection!");   
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {  
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            if (logForm.accConnection.State == ConnectionState.Open)
                logForm.accConnection.Close();
            logForm.Close();
            courseForm.Close();
            facultyForm.Close();
            studentForm.Close();
            spForm.Close();
            Application.Exit();    
        }  
    }
}
