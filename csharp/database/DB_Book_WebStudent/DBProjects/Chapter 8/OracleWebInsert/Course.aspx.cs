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
using System.Data.OracleClient;

public partial class Course : System.Web.UI.Page
{
    private TextBox[] CourseTextBox = new TextBox[6];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((OracleConnection)Application["oraConnection"]).State != ConnectionState.Open)
            ((OracleConnection)Application["oraConnection"]).Open();
       
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
        string strCourse = "SELECT Course.course_id, Course.course FROM Course, Faculty ";
        strCourse += "WHERE (Course.faculty_id=Faculty.faculty_id) AND (Faculty.faculty_name=:name)";
        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraDataReader;

        oraCommand.Connection = (OracleConnection)Application["oraConnection"];
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = strCourse;
        oraCommand.Parameters.Add("name", OracleType.Char).Value = ComboName.Text;

        oraDataReader = oraCommand.ExecuteReader();

        if (oraDataReader.HasRows == true)
            FillCourseReader(oraDataReader);
        else
            Response.Write("<script>alert('No matched course found!')</script>");
    
        oraDataReader.Close();
        oraCommand.Dispose();
    }
    private void FillCourseReader(OracleDataReader CourseReader)
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
        cmdString += "WHERE course_id =: courseid";
        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraDataReader;

        oraCommand.Connection = (OracleConnection)Application["oraConnection"];
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("courseid", OracleType.Char).Value = CourseList.SelectedItem.ToString();
        oraDataReader = oraCommand.ExecuteReader();

        if (oraDataReader.HasRows == true)
            FillCourseReaderTextBox(oraDataReader);
        else
            Response.Write("<script>alert('No matched course information found!')</script>");

        oraDataReader.Close();
        oraCommand.Dispose();
    }
    private void FillCourseReaderTextBox(OracleDataReader CourseReader)
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
