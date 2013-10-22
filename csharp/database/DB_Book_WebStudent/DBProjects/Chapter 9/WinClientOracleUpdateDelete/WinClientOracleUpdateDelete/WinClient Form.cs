using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinClientOracleUpdateDelete
{
    public partial class CourseForm : Form
    {
        WS_OracleUD.OracleBase wsOracleResult = new WS_OracleUD.OracleBase();

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
            WS_OracleUD.WebServiceOracleUpdateDelete wsOracleSelect = new WS_OracleUD.WebServiceOracleUpdateDelete();

            try { wsOracleResult = wsOracleSelect.GetOracleCourse(ComboName.Text); }
            catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }
            if (wsOracleResult.OracleOK == false)
                MessageBox.Show(wsOracleResult.OracleError);
            ProcessObject(ref wsOracleResult);
            wsOracleSelect.Dispose();
        }
        private void ProcessObject(ref WS_OracleUD.OracleBase wsResult)
        {
            if (wsResult.OracleOK == true)
                FillCourseListBox(ref wsResult);
            else
                MessageBox.Show("Course information cannot be retrieved: " + wsResult.OracleError);
        }

        private void FillCourseListBox(ref WS_OracleUD.OracleBase oraResult)
        {
            int index = 0;

            CourseList.Items.Clear();                    //clean up the course listbox
            for (index = 0; index <= oraResult.CourseID.Length - 1; index++)
            {
                if (oraResult.CourseID[index] != null)
                    CourseList.Items.Add(oraResult.CourseID[index]);
            }
        }

        private void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WS_OracleUD.WebServiceOracleUpdateDelete wsOracleSelect = new WS_OracleUD.WebServiceOracleUpdateDelete();

            try { wsOracleResult = wsOracleSelect.GetOracleCourseDetail(CourseList.Text); }
            catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }

            if (wsOracleResult.OracleOK == false)
                MessageBox.Show(wsOracleResult.OracleError);
            FillCourseDetail(ref wsOracleResult);
            wsOracleSelect.Dispose();
        }
        private void FillCourseDetail(ref WS_OracleUD.OracleBase oraResult)
        {
            txtCourseID.Text = CourseList.Text;
            txtCourseName.Text = oraResult.Course;
            txtSchedule.Text = oraResult.Schedule;
            txtClassRoom.Text = oraResult.Classroom;
            txtCredits.Text = oraResult.Credit.ToString();
            txtEnroll.Text = oraResult.Enrollment.ToString();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            WS_OracleUD.WebServiceOracleUpdateDelete wsOracleUpdate = new WS_OracleUD.WebServiceOracleUpdateDelete();

            try
            {
                wsOracleResult = wsOracleUpdate.OracleUpdateSP(ComboName.Text, txtCourseID.Text, txtCourseName.Text,
                            txtSchedule.Text, txtClassRoom.Text, Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
            }
            catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }

            if (wsOracleResult.OracleOK == false)
                MessageBox.Show(wsOracleResult.OracleError);
            wsOracleUpdate.Dispose();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            WS_OracleUD.WebServiceOracleUpdateDelete wsOracleDelete = new WS_OracleUD.WebServiceOracleUpdateDelete();

            try { wsOracleResult = wsOracleDelete.OracleDeleteSP(txtCourseID.Text); }
            catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }
            if (wsOracleResult.OracleOK == false)
                MessageBox.Show(wsOracleResult.OracleError);
            wsOracleDelete.Dispose();
        }
    }
}
