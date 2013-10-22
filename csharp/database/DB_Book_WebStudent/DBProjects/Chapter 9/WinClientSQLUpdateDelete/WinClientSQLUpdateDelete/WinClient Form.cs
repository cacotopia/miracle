using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinClientSQLUpdateDelete
{
    public partial class CourseForm : Form
    {
        WS_SQLUpdateDelete.SQLBase wsSQLResult = new WS_SQLUpdateDelete.SQLBase();

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

            ComboMethod.Items.Add("Stored Procedure Method");
            ComboMethod.SelectedIndex = 0;
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            WS_SQLUpdateDelete.WebServiceSQLUpdateDelete wsSQLSelect = new WS_SQLUpdateDelete.WebServiceSQLUpdateDelete();

            try { wsSQLResult = wsSQLSelect.GetSQLCourse(ComboName.Text); }
            catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }
            if (wsSQLResult.SQLOK == false)
            MessageBox.Show(wsSQLResult.SQLError);
            ProcessObject(ref wsSQLResult);
        }
        private void ProcessObject(ref WS_SQLUpdateDelete.SQLBase wsResult)
        {
            if (wsResult.SQLOK == true)
                FillCourseListBox(ref wsResult);
            else
                MessageBox.Show("Course information cannot be retrieved: " + wsResult.SQLError);
        }

        private void FillCourseListBox(ref WS_SQLUpdateDelete.SQLBase sqlResult)
        {
            int index = 0;

            CourseList.Items.Clear();                    //clean up the course listbox
            for (index = 0; index <= sqlResult.CourseID.Length - 1; index++)
            {
                if (sqlResult.CourseID[index] != null)
                    CourseList.Items.Add(sqlResult.CourseID[index]);
            }
        }

        private void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WS_SQLUpdateDelete.WebServiceSQLUpdateDelete wsSQLSelect = new WS_SQLUpdateDelete.WebServiceSQLUpdateDelete();

            try { wsSQLResult = wsSQLSelect.GetSQLCourseDetail(CourseList.Text); }
            catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }

            if (wsSQLResult.SQLOK == false)
                MessageBox.Show(wsSQLResult.SQLError);
            FillCourseDetail(ref wsSQLResult);
        }
        private void FillCourseDetail(ref WS_SQLUpdateDelete.SQLBase sqlResult)
        {
            txtCourseID.Text = CourseList.Text;
            txtCourseName.Text = sqlResult.Course;
            txtSchedule.Text = sqlResult.Schedule;
            txtClassRoom.Text = sqlResult.Classroom;
            txtCredits.Text = sqlResult.Credit.ToString();
            txtEnroll.Text = sqlResult.Enrollment.ToString();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            WS_SQLUpdateDelete.WebServiceSQLUpdateDelete wsSQLUpdate = new WS_SQLUpdateDelete.WebServiceSQLUpdateDelete();

        try { wsSQLResult = wsSQLUpdate.SQLUpdateSP(ComboName.Text, txtCourseID.Text, txtCourseName.Text,
                            txtSchedule.Text, txtClassRoom.Text, Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
        }

        catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }

        if (wsSQLResult.SQLOK == false)
            MessageBox.Show(wsSQLResult.SQLError);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            WS_SQLUpdateDelete.WebServiceSQLUpdateDelete wsSQLDelete = new WS_SQLUpdateDelete.WebServiceSQLUpdateDelete();

        try { wsSQLResult = wsSQLDelete.SQLDeleteSP(txtCourseID.Text); }
        catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }
        if (wsSQLResult.SQLOK == false)
            MessageBox.Show(wsSQLResult.SQLError);
        }
    }
}
