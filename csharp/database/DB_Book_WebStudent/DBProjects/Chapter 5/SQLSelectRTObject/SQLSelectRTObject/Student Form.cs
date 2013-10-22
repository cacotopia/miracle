using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLSelectRTObject
{
    public partial class StudentForm : Form
    {
        //DataSet ds = new DataSet();
        private TextBox[] StudentTextBox = new TextBox[7];        //We query 7 columns from the Student table
        public StudentForm()
        {
            InitializeComponent();
            ComboName.Items.Add("Erica Johnson");
            ComboName.Items.Add("Ashly Jade");
            ComboName.Items.Add("Holes Smith");
            ComboName.Items.Add("Andrew Woods");
            ComboName.Items.Add("Blue Valley");
            ComboName.SelectedIndex = 0;
            ComboMethod.Items.Add("DataAdapter Method");
            ComboMethod.Items.Add("DataReader Method");
            ComboMethod.SelectedIndex = 0;
            cmdSelect_Click(this.cmdSelect, null);
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        { 
            string strStudent = "dbo.StudentInfo";
            string strStudentCourse = "dbo.StudentCourseInfo";
            SqlDataAdapter StudentDataAdapter = new SqlDataAdapter();
            SqlDataAdapter StudentCourseDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCmdStudent = new SqlCommand(); 
            SqlCommand sqlCmdStudentCourse = new SqlCommand();
            DataTable sqlStudentTable = new DataTable();
            DataTable sqlStudentCourseTable = new DataTable();
            SqlDataReader sqlStudentReader, sqlStudentCourseReader;
            string strName = string.Empty;
            
            strName = FindName(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Student's Image Found!");
            BuildCommand(ref sqlCmdStudent, strStudent);
            sqlCmdStudent.Parameters.Add("@StudentName", SqlDbType.Char).Value = ComboName.Text;
            StudentDataAdapter.SelectCommand = sqlCmdStudent;
            if (ComboMethod.Text == "DataAdapter Method")
            {
                StudentDataAdapter.Fill(sqlStudentTable);
                if (sqlStudentTable.Rows.Count > 0)
                    FillStudentTextBox(sqlStudentTable);
                else
                    MessageBox.Show("No matched student found!");
                BuildCommand(ref sqlCmdStudentCourse, strStudentCourse);
                sqlCmdStudentCourse.Parameters.Add("@StudentID", SqlDbType.Char).Value = txtID.Text;
                StudentCourseDataAdapter.SelectCommand = sqlCmdStudentCourse;
                StudentCourseDataAdapter.Fill(sqlStudentCourseTable);
                if (sqlStudentCourseTable.Rows.Count > 0)
                    FillCourseList(sqlStudentCourseTable);
                else
                    MessageBox.Show("No matched course_id found!");
            }
            else    //DataReader Method is selected
            {
                sqlStudentReader = sqlCmdStudent.ExecuteReader();
                if (sqlStudentReader.HasRows == true)
                    FillStudentReader(sqlStudentReader);
                else
                    MessageBox.Show("No matched student found!");
                BuildCommand(ref sqlCmdStudentCourse, strStudentCourse);
                sqlCmdStudentCourse.Parameters.Add("@StudentID", SqlDbType.Char).Value = txtID.Text;
                StudentCourseDataAdapter.SelectCommand = sqlCmdStudentCourse;
                sqlStudentCourseReader = sqlCmdStudentCourse.ExecuteReader();
                if (sqlStudentCourseReader.HasRows == true)
                    FillCourseReader(sqlStudentCourseReader);
                else
                    MessageBox.Show("No matched course_id found!");
                sqlStudentReader.Close();
                sqlStudentCourseReader.Close();
            }
            sqlStudentTable.Dispose();       
            sqlStudentCourseTable.Dispose();
            StudentDataAdapter.Dispose();
            StudentCourseDataAdapter.Dispose();
            sqlCmdStudent.Dispose();
            sqlCmdStudentCourse.Dispose();  
        }
        private void BuildCommand(ref SqlCommand cmdObj, string cmdString)
        { 
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            cmdObj.Connection = logForm.sqlConnection;
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.CommandText = cmdString;  
        }
        private void FillStudentTextBox(DataTable StudentTable)
        {
            int pos1 =0;

            for (int pos2 = 0; pos2 <= 6; pos2++)                 //Initialize the textbox array
                StudentTextBox[pos2] = new TextBox();
            MapStudentTextBox(StudentTextBox);
            foreach (DataRow row in StudentTable.Rows)
            {
                foreach (DataColumn column in StudentTable.Columns)
                {
                    StudentTextBox[pos1].Text = row[column].ToString();
                    pos1++;
                }
            }
        }
        private void MapStudentTextBox(Object[] sTextBox)
        {
            sTextBox[0] = txtID;              //The order must be identical with the
            sTextBox[1] = txtGPA;             //order in the query string - strStudent
            sTextBox[2] = txtCredits;
            sTextBox[3] = txtMajor;
            sTextBox[4] = txtSchoolYear;
            sTextBox[5] = txtEmail;
        }
        private void FillCourseList(DataTable StudentCourseTable)
        {
            CourseList.Items.Clear();
            foreach (DataRow row in StudentCourseTable.Rows)
            {
                CourseList.Items.Add(row[0]);         //the 1st column is course_id - strStudentCourse
            }
        }
        private void FillStudentReader(SqlDataReader StudentReader)
        {
            int intIndex = 0;

            for (int pos2 = 0; pos2 <= 6; pos2++)                 //Initialize the textbox array
                StudentTextBox[pos2] = new TextBox();
            MapStudentTextBox(StudentTextBox);
            while (StudentReader.Read())
            {
                for (intIndex = 0; intIndex <= StudentReader.FieldCount - 1; intIndex++)
                    StudentTextBox[intIndex].Text = StudentReader.GetValue(intIndex).ToString();
            }
        }
        private void FillCourseReader(SqlDataReader StudentCourseReader)
        {
            int pos = 0;
            CourseList.Items.Clear();
            while (StudentCourseReader.Read())
            {
                for (pos = 0; pos <= StudentCourseReader.FieldCount - 1; pos++)
                    CourseList.Items.Add(StudentCourseReader.GetValue(pos).ToString());
            }
        }
        private string FindName(string sName)
        {
            string strName;

            switch (sName)
            {
                case "Erica Johnson":
                    strName = "Erica.jpg";
                    break;
                case "Ashly Jade":
                    strName = "Ashly.jpg";
                    break;
                case "Holes Smith":
                    strName = "Holes.jpg";
                    break;
                case "Andrew Woods":
                    strName = "Andrew.jpg";
                    break;
                case "Blue Valley":
                    strName = "Blue.jpg";
                    break;
                default:
                    strName = "No Match";
                    break;
            }
            if (strName != "No Match")
            {
                PhotoBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PhotoBox.Image = System.Drawing.Image.FromFile(strName);
            }
            return strName;
        }  
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
