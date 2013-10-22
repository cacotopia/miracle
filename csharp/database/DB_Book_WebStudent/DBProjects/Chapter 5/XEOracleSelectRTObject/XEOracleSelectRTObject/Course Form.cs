using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XEOracleSelectRTObject
{
    public partial class CourseForm : Form
    {
        private TextBox[] CourseTextBox = new TextBox[6];
        DataSet ds = new DataSet();

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
            ComboMethod.Items.Add("DataAdapter Method");
            ComboMethod.Items.Add("DataReader Method");
            ComboMethod.Items.Add("LINQ & DataSet Method");
            ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string cmdString = "Faculty_Course.SelectFacultyCourse";
            OracleParameter paramFacultyName = new OracleParameter();
            OracleParameter paramFacultyCourse = new OracleParameter();
            OracleDataAdapter CourseDataAdapter = new OracleDataAdapter();
            OracleCommand oraCommand = new OracleCommand();
            DataTable oraDataTable = new DataTable();
            OracleDataReader oraDataReader; 
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            paramFacultyName.ParameterName = "FacultyName";
            paramFacultyName.OracleType = OracleType.VarChar;
            paramFacultyName.Value = ComboName.Text;
            paramFacultyCourse.ParameterName = "FacultyCourse";
            paramFacultyCourse.OracleType = OracleType.Cursor;
            paramFacultyCourse.Direction = ParameterDirection.Output;
            oraCommand.Connection = logForm.oraConnection;
            oraCommand.CommandType = CommandType.StoredProcedure;
            oraCommand.CommandText = cmdString;
            oraCommand.Parameters.Add(paramFacultyName);
            oraCommand.Parameters.Add(paramFacultyCourse);
            if (ComboMethod.Text == "DataAdapter Method")
            {
                CourseDataAdapter.SelectCommand = oraCommand;
                CourseDataAdapter.Fill(oraDataTable);
                if (oraDataTable.Rows.Count > 0)
                    FillCourseTable(oraDataTable);
                else
                    MessageBox.Show("No matched course found!");
                oraDataTable.Dispose();
                CourseDataAdapter.Dispose();
            }
            else if (ComboMethod.Text == "DataReader Method")
            {
                oraDataReader = oraCommand.ExecuteReader();
                if (oraDataReader.HasRows == true)
                    FillCourseReader(oraDataReader);
                else
                    MessageBox.Show("No matched course found!");
                oraDataReader.Close();
            }
            else     //LINQ to DataSet Method is selected...
            {
                CourseDataAdapter.SelectCommand = oraCommand;
                CourseDataAdapter.Fill(ds, "Course");
                var courseinfo = (from ci in ds.Tables["Course"].AsEnumerable()
                                  select ci);
                CourseList.Items.Clear();
                foreach (var cRow in courseinfo)
                {
                    CourseList.Items.Add(cRow.Field<string>("course_id"));
                }
                ds.Clear();
            }
            CourseList.SelectedIndex = 0;
        }
        private void FillCourseTable(DataTable CourseTable)
        {
            CourseList.Items.Clear();
            foreach (DataRow row in CourseTable.Rows)
            {
                CourseList.Items.Add(row[0]);             //the 1st column is course_id - cmdString
            }
        }
        private void FillCourseReader(OracleDataReader CourseReader)
        {
            string strCourse = string.Empty;

            CourseList.Items.Clear();
            while (CourseReader.Read())
            {
                strCourse = CourseReader.GetString(0);    //the 1st column is course_id
                CourseList.Items.Add(strCourse);
            }
        }
        private void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmdString = "SELECT course, credit, classroom, schedule, enrollment, course_id FROM Course ";
            cmdString += "WHERE course_id =:courseid";
            OracleDataAdapter CourseDataAdapter = new OracleDataAdapter();
            OracleCommand oraCommand = new OracleCommand();
            DataTable oraDataTable = new DataTable();
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            oraCommand.Connection = logForm.oraConnection;
            oraCommand.CommandType = CommandType.Text;
            oraCommand.CommandText = cmdString;
            oraCommand.Parameters.Add("courseid", OracleType.Char).Value = CourseList.SelectedItem;

            CourseDataAdapter.SelectCommand = oraCommand;
            CourseDataAdapter.Fill(oraDataTable);
            if (oraDataTable.Rows.Count > 0)
                FillCourseTextBox(oraDataTable);
            else
                MessageBox.Show("No matched course information found!");
            oraDataTable.Dispose();
            oraCommand.Dispose();
            CourseDataAdapter.Dispose();
        }
        private void FillCourseTextBox(DataTable CourseTable)
        {
            int pos1 = 0;

            for (int pos2 = 0; pos2 <= 5; pos2++)                 //Initialize the object array
                CourseTextBox[pos2] = new TextBox();
            MapCourseTable(CourseTextBox);
            foreach (DataRow row in CourseTable.Rows)
            {
                foreach (DataColumn column in CourseTable.Columns)
                {
                    CourseTextBox[pos1].Text = row[column].ToString();
                    pos1++;
                }
            }
        }
        private void MapCourseTable(Object[] fCourse)
        {
            fCourse[0] = txtName;            //The order must be identical with
            fCourse[1] = txtCredits;         //the real order in the query string -
            fCourse[2] = txtClassRoom;       //cmdString
            fCourse[3] = txtSchedule;
            fCourse[4] = txtEnroll;
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
