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
    public partial class StudentForm : Form
    {
        DataSet ds = new DataSet();
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
            ComboMethod.Items.Add("LINQ & DataSet Method");
            ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string strStudent = "SELECT student_id, gpa, credits, major, schoolYear, email, student_name FROM Student ";
            strStudent += "WHERE student_name = @Param1";
            string strStudentCourse = "SELECT course_id, student_id FROM StudentCourse WHERE student_id = @Param2";
            OleDbDataAdapter StudentDataAdapter = new OleDbDataAdapter();
            OleDbDataAdapter StudentCourseDataAdapter = new OleDbDataAdapter();
            OleDbCommand accCmdStudent = new OleDbCommand(); 
            OleDbCommand accCmdStudentCourse = new OleDbCommand();
            DataTable accStudentTable = new DataTable(); 
            DataTable accStudentCourseTable = new DataTable();
            string strName = string.Empty;

            strName = FindName(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Student's Image Found!");
            BuildCommand(ref accCmdStudent, strStudent);
            accCmdStudent.Parameters.Add("@Param1", OleDbType.Char).Value = ComboName.Text;
            StudentDataAdapter.SelectCommand = accCmdStudent;
            if (ComboMethod.Text == "DataAdapter Method")
            {
                StudentDataAdapter.Fill(accStudentTable);
                if (accStudentTable.Rows.Count > 0)
                    FillStudentTextBox(accStudentTable);
                else
                    MessageBox.Show("No matched student found!");
                BuildCommand(ref accCmdStudentCourse, strStudentCourse);
                accCmdStudentCourse.Parameters.Add("@Param2", OleDbType.Char).Value = txtID.Text;
                StudentCourseDataAdapter.SelectCommand = accCmdStudentCourse;
                StudentCourseDataAdapter.Fill(accStudentCourseTable);
                if (accStudentCourseTable.Rows.Count > 0)
                    FillCourseList(accStudentCourseTable);
                else
                    MessageBox.Show("No matched course_id found!");
            }
            else    //LINQ to DataSet Method
            {
                StudentDataAdapter.Fill(ds, "Student");
                LINQStudent(ds);
                BuildCommand(ref accCmdStudentCourse, strStudentCourse);
                accCmdStudentCourse.Parameters.Add("@Param2", OleDbType.Char).Value = txtID.Text;
                StudentCourseDataAdapter.SelectCommand = accCmdStudentCourse;
                StudentCourseDataAdapter.Fill(ds, "StudentCourse");
                LINQStudentCourse(ds);
                ds.Clear();
            }
            accStudentTable.Dispose();       
            accStudentCourseTable.Dispose();
            StudentDataAdapter.Dispose();
            StudentCourseDataAdapter.Dispose();
            accCmdStudent.Dispose();
            accCmdStudentCourse.Dispose();
        }
        private void LINQStudent(DataSet dSet)
        {
            var studentinfo = (from si in dSet.Tables["Student"].AsEnumerable()
                               where si.Field<string>("student_name") == (string)ComboName.Text
                               select si);
            foreach (var sRow in studentinfo)
            {
                this.txtID.Text = sRow.Field<string>("student_id");
                this.txtSchoolYear.Text = sRow.Field<string>("schoolYear");
                this.txtGPA.Text = sRow.Field<string>("gpa");
                this.txtCredits.Text = sRow.Field<int>("credits").ToString();
                this.txtMajor.Text = sRow.Field<string>("major");
                this.txtEmail.Text = sRow.Field<string>("email");
            }
        }
        private void LINQStudentCourse(DataSet dt)
        {
            CourseList.Items.Clear();
            var scinfo = (from sc in dt.Tables["StudentCourse"].AsEnumerable()
                          where sc.Field<string>("student_id") == (string)txtID.Text
                          select sc);
            foreach (var sRow in scinfo)
            {
                CourseList.Items.Add(sRow.Field<string>("course_id"));
            }
        }
        private void BuildCommand(ref OleDbCommand cmdObj, string cmdString)
        {
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            cmdObj.Connection = logForm.accConnection;
            cmdObj.CommandType = CommandType.Text;
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
