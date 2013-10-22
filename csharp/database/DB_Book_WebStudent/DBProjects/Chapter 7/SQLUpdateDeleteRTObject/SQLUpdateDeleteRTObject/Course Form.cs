using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLUpdateDeleteRTObject
{
    public partial class CourseForm : Form
    {
        private TextBox[] CourseTextBox = new TextBox[6];
        //DataSet ds = new DataSet();

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
            //ComboMethod.Items.Add("LINQ & DataSet Method");
            ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string strCourse = "SELECT Course.course_id, Course.course FROM Course JOIN Faculty ";
            strCourse += "ON (Course.faculty_id LIKE Faculty.faculty_id) AND (Faculty.faculty_name LIKE @name)";
            SqlDataAdapter CourseDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCmdCourse = new SqlCommand();
            DataTable sqlCourseTable = new DataTable();      
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            SqlDataReader sqlDataReader;

            sqlCmdCourse.Connection = logForm.sqlConnection;
            sqlCmdCourse.CommandType = CommandType.Text;
            sqlCmdCourse.CommandText = strCourse;
            sqlCmdCourse.Parameters.Add("@name", SqlDbType.Char).Value = ComboName.Text;
            if (ComboMethod.Text == "DataAdapter Method")
            {
                CourseDataAdapter.SelectCommand = sqlCmdCourse;
                CourseDataAdapter.Fill(sqlCourseTable);
                if (sqlCourseTable.Rows.Count > 0)
                    FillCourseTable(sqlCourseTable);
                else
                    MessageBox.Show("No matched course found!");
                sqlCourseTable.Dispose();
                CourseDataAdapter.Dispose();
            }
            else if (ComboMethod.Text == "DataReader Method")
            {
                sqlDataReader = sqlCmdCourse.ExecuteReader();
                if (sqlDataReader.HasRows == true)
                    FillCourseReader(sqlDataReader);
                else
                    MessageBox.Show("No matched course found!");
                sqlDataReader.Close();
                sqlDataReader.Dispose();
            }
            else     //Invalid Method is selected
                MessageBox.Show("Invalid Method Selected!");
            sqlCmdCourse.Dispose();
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
        private void FillCourseReader(SqlDataReader CourseReader)
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
            cmdString += "WHERE course_id LIKE @courseid";
            SqlDataAdapter CourseDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand();  
            DataTable sqlDataTable = new DataTable();
            SqlDataReader sqlDataReader;
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            sqlCommand.Connection = logForm.sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.Add("@courseid", SqlDbType.Char).Value = CourseList.SelectedItem;

            if (ComboMethod.Text == "DataAdapter Method")
            {
                CourseDataAdapter.SelectCommand = sqlCommand;
                CourseDataAdapter.Fill(sqlDataTable);
                if (sqlDataTable.Rows.Count > 0)
                    FillCourseTextBox(sqlDataTable);
                else
                    MessageBox.Show("No matched course information found!");
                sqlDataTable.Dispose();
                CourseDataAdapter.Dispose();
            }
            else if (ComboMethod.Text == "DataReader Method")
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows == true)
                    FillCourseReaderTextBox(sqlDataReader);
                else
                    MessageBox.Show("No matched course information found!");
                sqlDataReader.Close();
                sqlDataReader.Dispose();
            }
            else      //Invalid Method is selected
                MessageBox.Show("Invalid Method Selected!");                     
            sqlCommand.Dispose();  
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
        private void FillCourseReaderTextBox(SqlDataReader CourseReader)
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
