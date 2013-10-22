using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinClientSQLInsert
{
    public partial class CourseForm : Form
    {
        private bool dsFlag = false;
        private DataSet wsDataSet;
        WS_SQLInsert.SQLInsertBase wsSQLResult = new WS_SQLInsert.SQLInsertBase();

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
            ComboMethod.Items.Add("DataSet Method");
            ComboMethod.SelectedIndex = 0;
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            WS_SQLInsert.WebServiceSQLInsert wsSQLInsert = new WS_SQLInsert.WebServiceSQLInsert();

            if (ComboMethod.Text == "Stored Procedure Method")
            {
                try {wsSQLResult = wsSQLInsert.SetSQLInsertSP(ComboName.Text, txtCourseID.Text, 
                                   txtCourseName.Text, txtSchedule.Text, txtClassRoom.Text,
                                   Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
                }
                catch (Exception err) {MessageBox.Show("Web service is wrong: " + err.Message);}
                if (wsSQLResult.SQLInsertOK == false)
                    MessageBox.Show(wsSQLResult.SQLInsertError);
            }
            else
            {
                dsFlag = true;           //indicate the DataSet insert is performed
                try {wsDataSet = wsSQLInsert.SQLInsertDataSet(ComboName.Text, txtCourseID.Text, 
                                 txtCourseName.Text, txtSchedule.Text, txtClassRoom.Text,
                                 Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
                }
                catch (Exception err) {MessageBox.Show("Web service is wrong: " + err.Message);}
            }
            cmdInsert.Enabled = false;
        }

        private void txtCourseID_TextChanged(object sender, EventArgs e)
        {
            cmdInsert.Enabled = true;
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            WS_SQLInsert.WebServiceSQLInsert wsSQLInsert = new WS_SQLInsert.WebServiceSQLInsert();

            if (ComboMethod.Text == "Stored Procedure Method")
            {
                try { wsSQLResult = wsSQLInsert.GetSQLInsert(ComboName.Text); }
                catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }
                if (wsSQLResult.SQLInsertOK == false)
                    MessageBox.Show(wsSQLResult.SQLInsertError);
                ProcessObject(ref wsSQLResult);
            }
            else
            {
                if (dsFlag == false)
                    MessageBox.Show("No DataSet Insert performed, do data insertion first");
                FillCourseDataSet(ref wsDataSet);
                dsFlag = false;
            }
        }
        private void ProcessObject(ref WS_SQLInsert.SQLInsertBase wsResult)
        {
            if (wsResult.SQLInsertOK == true)
                FillCourseListBox(ref wsResult);
            else
                MessageBox.Show("Course information cannot be retrieved: " + wsResult.SQLInsertError);
        }

        private void FillCourseListBox(ref WS_SQLInsert.SQLInsertBase sqlResult)
        {
            int index = 0;

            CourseList.Items.Clear();                    //clean up the course listbox
            for (index = 0; index <= sqlResult.CourseID.Length - 1; index++)
            {
                if (sqlResult.CourseID[index] != null)
                    CourseList.Items.Add(sqlResult.CourseID[index]);
            }
        }
        private void FillCourseDataSet(ref DataSet ds)
        {
            DataTable CourseTable = new DataTable();

            CourseList.Items.Clear();                    	//clean up the course listbox
            CourseTable = ds.Tables["Course"];

            foreach (DataRow CourseRow in CourseTable.Rows)
            {
                CourseList.Items.Add(CourseRow[0]);      	//the 1st column is course_id
            }
        }

        private void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WS_SQLInsert.WebServiceSQLInsert wsSQLInsert = new WS_SQLInsert.WebServiceSQLInsert();

            try { wsSQLResult = wsSQLInsert.GetSQLInsertCourse(CourseList.Text); }
            catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }

            if (wsSQLResult.SQLInsertOK == false)
                MessageBox.Show(wsSQLResult.SQLInsertError);
            FillCourseDetail(ref wsSQLResult);
        }
        private void FillCourseDetail(ref WS_SQLInsert.SQLInsertBase sqlResult)
        {
            txtCourseID.Text = CourseList.Text;
            txtCourseName.Text = sqlResult.Course;
            txtSchedule.Text = sqlResult.Schedule;
            txtClassRoom.Text = sqlResult.Classroom;
            txtCredits.Text = sqlResult.Credit.ToString();
            txtEnroll.Text = sqlResult.Enrollment.ToString();
        }
    }
}
