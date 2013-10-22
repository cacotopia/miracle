using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinClientOracleInsert
{
    public partial class CourseForm : Form
    {
        private bool dsFlag = false;
        private DataSet wsDataSet;
        WS_OracleInsert.OracleInsertBase wsOracleResult = new WS_OracleInsert.OracleInsertBase();

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
            WS_OracleInsert.WebServiceOracleInsert wsOracleInsert = new WS_OracleInsert.WebServiceOracleInsert();

            if (ComboMethod.Text == "Stored Procedure Method")
            {
                try
                {
                    wsOracleResult = wsOracleInsert.SetOracleInsertSP(ComboName.Text, txtCourseID.Text, 
                                     txtCourseName.Text, txtSchedule.Text, txtClassRoom.Text,
                                     Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
                }
                catch (Exception err) {MessageBox.Show("Web service is wrong: " + err.Message);}
                if (wsOracleResult.OracleInsertOK == false)
                    MessageBox.Show(wsOracleResult.OracleInsertError);
            }
            else
            {
                dsFlag = true;           //indicate the DataSet insert is performed
                try
                {
                    wsDataSet = wsOracleInsert.OracleInsertDataSet(ComboName.Text, txtCourseID.Text, 
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
            WS_OracleInsert.WebServiceOracleInsert wsOracleInsert = new WS_OracleInsert.WebServiceOracleInsert();

            if (ComboMethod.Text == "Stored Procedure Method")
            {
                try { wsOracleResult = wsOracleInsert.GetOracleInsert(ComboName.Text); }
                catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }
                if (wsOracleResult.OracleInsertOK == false)
                    MessageBox.Show(wsOracleResult.OracleInsertError);
                ProcessObject(ref wsOracleResult);
            }
            else
            {
                if (dsFlag == false)
                    MessageBox.Show("No DataSet Insert performed, do data insertion first");
                FillCourseDataSet(ref wsDataSet);
                dsFlag = false;
            }
        }
        private void ProcessObject(ref WS_OracleInsert.OracleInsertBase wsResult)
        {
            if (wsResult.OracleInsertOK == true)
                FillCourseListBox(ref wsResult);
            else
                MessageBox.Show("Course information cannot be retrieved: " + wsResult.OracleInsertError);
        }

        private void FillCourseListBox(ref WS_OracleInsert.OracleInsertBase oraResult)
        {
            int index = 0;

            CourseList.Items.Clear();                    //clean up the course listbox
            for (index = 0; index <= oraResult.CourseID.Length - 1; index++)
            {
                if (oraResult.CourseID[index] != null)
                    CourseList.Items.Add(oraResult.CourseID[index]);
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
            WS_OracleInsert.WebServiceOracleInsert wsOracleInsert = new WS_OracleInsert.WebServiceOracleInsert();

            try { wsOracleResult = wsOracleInsert.GetOracleInsertCourse(CourseList.Text); }
            catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }

            if (wsOracleResult.OracleInsertOK == false)
                MessageBox.Show(wsOracleResult.OracleInsertError);
            FillCourseDetail(ref wsOracleResult);
        }
        private void FillCourseDetail(ref WS_OracleInsert.OracleInsertBase oraResult)
        {
            txtCourseID.Text = CourseList.Text;
            txtCourseName.Text = oraResult.Course;
            txtSchedule.Text = oraResult.Schedule;
            txtClassRoom.Text = oraResult.Classroom;
            txtCredits.Text = oraResult.Credit.ToString();
            txtEnroll.Text = oraResult.Enrollment.ToString();
        }
    }
}
