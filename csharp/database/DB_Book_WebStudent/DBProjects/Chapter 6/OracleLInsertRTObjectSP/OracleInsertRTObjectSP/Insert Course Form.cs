﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace OracleInsertRTObjectSP
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
        }

        private void InitCourseInfo()
        {
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

            for (pos = 1; pos <= 6; pos++)
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
            txtCourse.Text = String.Empty;
            txtSchedule.Text = String.Empty;
            txtClassRoom.Text = String.Empty;
            txtCredits.Text = String.Empty;
            txtEnroll.Text = String.Empty;
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            int check = 0, intInsert = 0; 
            string cmdString = "InsertFacultyCourse";
            OracleCommand oraCommand = new OracleCommand();
            LogInForm logForm = new LogInForm();

            InitCourseInfo();
            check = CheckCourseInfo();
            if (check == 0)
            {
                logForm = logForm.getLogInForm();
                oraCommand.Connection = logForm.oraConnection;
                oraCommand.CommandType = CommandType.StoredProcedure;
                oraCommand.CommandText = cmdString;
                InsertParameters(ref oraCommand);
                intInsert = oraCommand.ExecuteNonQuery();
                oraCommand.Dispose();
                if (intInsert == 0)
                    MessageBox.Show("The data insertion is failed");
                else
                {
                    cmdCancel.PerformClick();             // clean up all faculty information
                    cmdInsert.Enabled = false;
                }
            }
            else
                MessageBox.Show("Fill all Course Information box, enter a NULL for blank column");
        }
        private void InsertParameters(ref OracleCommand cmd)
        {
            cmd.Parameters.Add("FacultyName", OracleType.Char).Value = ComboName.Text;
            cmd.Parameters.Add("CourseID", OracleType.Char).Value = txtCourseID.Text;
            cmd.Parameters.Add("Course", OracleType.Char).Value = txtCourse.Text;
            cmd.Parameters.Add("Schedule", OracleType.Char).Value = txtSchedule.Text;
            cmd.Parameters.Add("Classroom", OracleType.Char).Value = txtClassRoom.Text;
            cmd.Parameters.Add("Credit", OracleType.Char).Value = txtCredits.Text;
            cmd.Parameters.Add("Enroll", OracleType.Char).Value = txtEnroll.Text;
        }
    }
}
