using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessSelectRTObject
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
            string strFaculty = "SELECT faculty_id FROM Faculty WHERE faculty_name = @Param1";
            string strCourse = "SELECT course_id, course, credit, classroom, schedule, enrollment, faculty_id FROM Course ";
            strCourse += "WHERE faculty_id = @Param2";
            OleDbDataAdapter CourseDataAdapter = new OleDbDataAdapter();
            OleDbDataAdapter FacultyDataAdapter = new OleDbDataAdapter();
            OleDbCommand accCmdFaculty = new OleDbCommand(); OleDbCommand accCmdCourse = new OleDbCommand();
            DataTable accCourseTable = new DataTable();      DataTable accFacultyTable = new DataTable();
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            OleDbDataReader accDataReader;
            string strFacultyID = string.Empty;
            DataRow rowFaculty;

            accCmdFaculty.Connection = logForm.accConnection;
            accCmdFaculty.CommandType = CommandType.Text;
            accCmdFaculty.CommandText = strFaculty;
            accCmdFaculty.Parameters.Add("@Param1", OleDbType.Char).Value = ComboName.Text;
            FacultyDataAdapter.SelectCommand = accCmdFaculty;
            FacultyDataAdapter.Fill(accFacultyTable);
            if (accFacultyTable.Rows.Count > 0)
            {
                rowFaculty = accFacultyTable.Rows[0];
                strFacultyID = rowFaculty[0].ToString(); 
            }
            else
                MessageBox.Show("No matched faculty_id found!");  
            accCmdCourse.Connection = logForm.accConnection;
            accCmdCourse.CommandType = CommandType.Text;
            accCmdCourse.CommandText = strCourse;
            accCmdCourse.Parameters.Add("@Param2", OleDbType.Char).Value = strFacultyID;
            if (ComboMethod.Text == "DataAdapter Method")
            {
                CourseDataAdapter.SelectCommand = accCmdCourse;
                CourseDataAdapter.Fill(accCourseTable);
                if (accCourseTable.Rows.Count > 0)
                    FillCourseTable(accCourseTable);
                else
                    MessageBox.Show("No matched course found!");
                accFacultyTable.Dispose();  accCourseTable.Dispose();  CourseDataAdapter.Dispose();
            }
            else if (ComboMethod.Text == "DataReader Method")
            {
                accDataReader = accCmdCourse.ExecuteReader();
                if (accDataReader.HasRows == true)
                    FillCourseReader(accDataReader);
                else
                    MessageBox.Show("No matched course found!");
                accDataReader.Close();
                accDataReader.Dispose();
            }
            else     //LINQ to DataSet Method is selected
            {
                CourseList.Items.Clear();
                CourseDataAdapter.SelectCommand = accCmdCourse;
                CourseDataAdapter.Fill(ds, "Course");
                var courseinfo = (from ci in ds.Tables["Course"].AsEnumerable()
                                  where ci.Field<string>("faculty_id") == (string)strFacultyID
                                  select ci);
                foreach (var cRow in courseinfo)
                    CourseList.Items.Add(cRow.Field<string>("course_id"));
                ds.Clear();
            }
            accCmdFaculty.Dispose();
            accCmdCourse.Dispose();
            CourseList.SelectedIndex = 0;
        }
        private void FillCourseTable(DataTable CourseTable)
        {
            CourseList.Items.Clear();
            foreach (DataRow row in CourseTable.Rows)
            {
                CourseList.Items.Add(row[0]);        //the 1st column is course_id - strCourse
            }
        }
        private void FillCourseReader(OleDbDataReader CourseReader)
        {
            string strCourse = string.Empty;
                                    
            CourseList.Items.Clear();
            while (CourseReader.Read())
            {
                strCourse = CourseReader.GetString(0);                       //the 1st column is course_id
                CourseList.Items.Add(strCourse);
            }
        }
        private void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmdString = "SELECT course, credit, classroom, schedule, enrollment, course_id FROM Course ";
            cmdString += "WHERE course_id = @Param1";
            OleDbDataAdapter CourseDataAdapter = new OleDbDataAdapter(); 
            OleDbCommand accCommand = new OleDbCommand();  
            DataTable accDataTable = new DataTable(); 
            OleDbDataReader accDataReader;
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            accCommand.Connection = logForm.accConnection;
            accCommand.CommandType = CommandType.Text;
            accCommand.CommandText = cmdString;
            accCommand.Parameters.Add("@Param1", OleDbType.Char).Value = CourseList.SelectedItem;
           
            if (ComboMethod.Text == "DataAdapter Method")
            {
                CourseDataAdapter.SelectCommand = accCommand;
                CourseDataAdapter.Fill(accDataTable);
                if (accDataTable.Rows.Count > 0)
                    FillCourseTextBox(accDataTable);
                else
                    MessageBox.Show("No matched course information found!");
                accDataTable.Dispose();
                CourseDataAdapter.Dispose();
            }
            else if (ComboMethod.Text == "DataReader Method")
            {
                accDataReader = accCommand.ExecuteReader();
                if (accDataReader.HasRows == true)
                    FillCourseReaderTextBox(accDataReader);
                else
                    MessageBox.Show("No matched course information found!");
                accDataReader.Close();
                accDataReader.Dispose();
            }
            else      //LINQ & DataSet Methos is selected
            {
                DataSet dc = new DataSet();
                CourseDataAdapter.SelectCommand = accCommand;
                CourseDataAdapter.Fill(dc, "Course");
                var cinfo = (from c in dc.Tables["Course"].AsEnumerable()
                                  where c.Field<string>("course_id") == (string)CourseList.SelectedItem
                                  select c);
                foreach (var crow in cinfo)
                {
                    txtName.Text = crow.Field<string>("course");
                    txtSchedule.Text = crow.Field<string>("schedule");
                    txtClassRoom.Text = crow.Field<string>("classroom");
                    txtCredits.Text = crow.Field<int>("credit").ToString();
                    txtEnroll.Text = crow.Field<int>("enrollment").ToString();
                }
                dc.Clear();
            }
            accCommand.Dispose();
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
        private void FillCourseReaderTextBox(OleDbDataReader CourseReader)
        {
            int intIndex = 0;

            for (intIndex = 0; intIndex <= 5; intIndex++)            //Initialize the object array
                CourseTextBox[intIndex] = new TextBox();
            MapCourseTable(CourseTextBox);
            while (CourseReader.Read())
            {
                for (intIndex = 0; intIndex <= CourseReader.FieldCount - 1; intIndex++)
                    CourseTextBox[intIndex].Text = CourseReader.GetValue(intIndex).ToString();
            }
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
