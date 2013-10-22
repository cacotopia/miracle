using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Course : System.Web.UI.Page
{
    private TextBox[] CourseTextBox = new TextBox[6];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((SqlConnection)Application["sqlConnection"]).State != ConnectionState.Open)
            ((SqlConnection)Application["sqlConnection"]).Open();
       
        if (!IsPostBack)			    //these items can only be added into the combo box in one time
        {
            ComboName.Items.Add("Ying Bai");
            ComboName.Items.Add("Satish Bhalla");
            ComboName.Items.Add("Black Anderson");
            ComboName.Items.Add("Steve Johnson");
            ComboName.Items.Add("Jenney King");
            ComboName.Items.Add("Alice Brown");
            ComboName.Items.Add("Debby Angles");
            ComboName.Items.Add("Jeff Henry");
        }
    }

    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Selection.aspx");
    }
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        string strCourse = "SELECT Course.course_id, Course.course FROM Course JOIN Faculty ";
        strCourse += "ON (Course.faculty_id LIKE Faculty.faculty_id) AND (Faculty.faculty_name LIKE @name)";
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;

        sqlCommand.Connection = (SqlConnection)Application["sqlConnection"];
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = strCourse;
        sqlCommand.Parameters.Add("@name", SqlDbType.Char).Value = ComboName.Text;

        sqlDataReader = sqlCommand.ExecuteReader();

        if (sqlDataReader.HasRows == true)
            FillCourseReader(sqlDataReader);
        else
            Response.Write("<script>alert('No matched course found!')</script>");
    
        sqlDataReader.Close();
        sqlCommand.Dispose();
    }
    private void FillCourseReader(SqlDataReader CourseReader)
    {
        string strCourse = string.Empty;

        CourseList.Items.Clear();
        while (CourseReader.Read())
        {
            strCourse = CourseReader.GetString(0);          //the 1st column is course_id
            CourseList.Items.Add(strCourse);
        }
    }
    protected void CourseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cmdString = "SELECT course, credit, classroom, schedule, enrollment, course_id FROM Course ";
        cmdString += "WHERE course_id LIKE @courseid";
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;

        sqlCommand.Connection = (SqlConnection)Application["sqlConnection"];
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@courseid", SqlDbType.Char).Value = CourseList.SelectedItem.ToString();
        sqlDataReader = sqlCommand.ExecuteReader();

        if (sqlDataReader.HasRows == true)
            FillCourseReaderTextBox(sqlDataReader);
        else
            Response.Write("<script>alert('No matched course information found!')</script>");

        sqlDataReader.Close();
        sqlCommand.Dispose();
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
    private void MapCourseTable(Object[] fCourse)
    {
        fCourse[0] = txtCourse;             //The order must be identical with
        fCourse[1] = txtCredit;             //the real order in the query string -
        fCourse[2] = txtClassroom;          //cmdString
        fCourse[3] = txtSchedule;
        fCourse[4] = txtEnrollment;
    }
}
