﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OracleInsertWizard
{
    public partial class InsertCourseForm : Form
    {
        string[] CourseInfo = new string[7];
        public InsertCourseForm()
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
            ComboMethod.Items.Add("TableAdapter Insert");
            ComboMethod.Items.Add("TableAdapter Update");
            ComboMethod.Items.Add("Stored Procedure");
            ComboMethod.SelectedIndex = 0;
            txtCourseID.DataBindings.Clear();
            txtFacultyID.DataBindings.Clear(); 
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            int check = 0, intInsert = 0; 
            CSE_DEPTDataSet.COURSERow newCourseRow;

            InitCourseInfo();
            check = CheckCourseInfo();
            if (check == 0)
            {
                fACULTYTableAdapter1.ClearBeforeFill = true;
                string strFacultyID = fACULTYTableAdapter1.FindFacultyIDByName(ComboName.Text);
                txtFacultyID.Text = strFacultyID;
                if (ComboMethod.Text == "TableAdapter Insert")
                {
                    intInsert = cOURSETableAdapter1.InsertCourse(txtCourseID.Text, txtCourse.Text, int.Parse(txtCredits.Text),
                                txtClassRoom.Text, txtSchedule.Text, int.Parse(txtEnroll.Text), txtFacultyID.Text);
                }
                else if (ComboMethod.Text == "TableAdapter Update")
                {
                    newCourseRow = cSE_DEPTDataSet1.COURSE.NewCOURSERow();
                    newCourseRow = InsertCourseRow(ref newCourseRow);
                    cSE_DEPTDataSet1.COURSE.Rows.Add(newCourseRow);
                    intInsert = cOURSETableAdapter1.Update(cSE_DEPTDataSet1.COURSE);
                }
                else // .NET Framework does not support Oracle query using stored procedures.
                    //intInsert = cOURSETableAdapter1.InsertCourseSP(txtCourseID.Text, txtCourse.Text, double.Parse(txtCredits.Text),
                    //                           txtClassRoom.Text, txtSchedule.Text, int.Parse(txtEnroll.Text), txtFacultyID.Text);
                if (intInsert != 0)                     // data insertion is successful
                {
                    cmdCancel.PerformClick();           // clean up all faculty information
                    cmdInsert.Enabled = false;          // disable the Insert button 
                }
                else
                {
                    MessageBox.Show("The course insertion is failed");
                    cmdInsert.Enabled = true;
                }
            }
            else
                MessageBox.Show("Fill all Course Information box, enter a NULL for blank column");
        }
        private CSE_DEPTDataSet.COURSERow InsertCourseRow(ref CSE_DEPTDataSet.COURSERow courseRow)
        {
            courseRow.FACULTY_ID = txtFacultyID.Text;
            courseRow.COURSE_ID = txtCourseID.Text;
            courseRow.COURSE = txtCourse.Text;
            courseRow.SCHEDULE = txtSchedule.Text;
            courseRow.CLASSROOM = txtClassRoom.Text;
            courseRow.CREDIT = int.Parse(txtCredits.Text);
            courseRow.ENROLLMENT = int.Parse(txtEnroll.Text);
            return courseRow;
        }

        private void InitCourseInfo()
        {
            CourseInfo[0] = txtFacultyID.Text;
            CourseInfo[1] = txtCourseID.Text;
            CourseInfo[2] = txtCourse.Text;
            CourseInfo[3] = txtSchedule.Text;
            CourseInfo[4] = txtClassRoom.Text;
            CourseInfo[5] = txtCredits.Text;
            CourseInfo[6] = txtEnroll.Text;
        }

        private int CheckCourseInfo()
        {
            int pos = 0, check = 0;

            for (pos = 0; pos <= 6; pos++)
            {
                if (CourseInfo[pos] == String.Empty)
                    check++;
            }
            return check;
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            txtFacultyID.Text = String.Empty;
            txtCourse.Text = String.Empty;
            txtSchedule.Text = String.Empty;
            txtClassRoom.Text = String.Empty;
            txtCredits.Text = String.Empty;
            txtEnroll.Text = String.Empty;
        }

        private void InsertCourseForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cSE_DEPTDataSet1.COURSE' table. You can move, or remove it, as needed.
            this.cOURSETableAdapter1.Fill(this.cSE_DEPTDataSet1.COURSE);
            // TODO: This line of code loads data into the 'cSE_DEPTDataSet1.FACULTY' table. You can move, or remove it, as needed.
            this.fACULTYTableAdapter1.Fill(this.cSE_DEPTDataSet1.FACULTY);
        }

        private void txtCourseID_TextChanged(object sender, EventArgs e)
        {
            cmdInsert.Enabled = true;
        }
    }
}
