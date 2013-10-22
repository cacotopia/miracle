using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLUpdateDeleteRTObject
{
    public partial class SPForm : Form
    {
        private TextBox[] StudentTextBox = new TextBox[7]; 
        public SPForm()
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
            string strStudentCourse = "dbo.StudentCourseINTO";
            SqlDataAdapter StudentCourseDataAdapter = new SqlDataAdapter();           
            SqlCommand sqlCmdStudentCourse = new SqlCommand();            
            DataTable sqlStudentCourseTable = new DataTable();           
            SqlDataReader sqlStudentCourseReader;
            string strName = string.Empty;

            strName = FindName(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Student's Image Found!");
            BuildCommand(ref sqlCmdStudentCourse, strStudentCourse);
            sqlCmdStudentCourse.Parameters.Add("@stdName", SqlDbType.Char).Value = ComboName.Text;
            StudentCourseDataAdapter.SelectCommand = sqlCmdStudentCourse;
            if (ComboMethod.Text == "DataAdapter Method")
            {
                StudentCourseDataAdapter.Fill(sqlStudentCourseTable);
                if (sqlStudentCourseTable.Rows.Count > 0)
                    FillCourseList(sqlStudentCourseTable);
                else
                    MessageBox.Show("No matched course_id found!");
            }
            else    //DataReader Method is selected
            {
                sqlStudentCourseReader = sqlCmdStudentCourse.ExecuteReader();
                if (sqlStudentCourseReader.HasRows == true)
                    FillCourseReader(sqlStudentCourseReader);
                else
                    MessageBox.Show("No matched course_id found!");
                sqlStudentCourseReader.Close();
            }
            sqlStudentCourseTable.Dispose();
            StudentCourseDataAdapter.Dispose();
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
        private void FillCourseList(DataTable StudentCourseTable)
        {
            CourseList.Items.Clear();
            foreach (DataRow row in StudentCourseTable.Rows)
            {
                CourseList.Items.Add(row[0]);         //the 1st column is course_id - strStudentCourse
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
