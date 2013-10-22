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
    WS_SQLUpdateDelete.SQLBase wsSQLResult = new WS_SQLUpdateDelete.SQLBase();

    protected void Page_Load(object sender, EventArgs e)
    {
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
            ComboMethod.Items.Add("Stored Procedure Method");
        }
    }

    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close()</script>");
    }
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        WS_SQLUpdateDelete.WebServiceSQLUpdateDelete wsSQLSelect = new WS_SQLUpdateDelete.WebServiceSQLUpdateDelete();
        string errMsg;

        try { wsSQLResult = wsSQLSelect.GetSQLCourse(ComboName.Text); }
        catch (Exception err)
        {
            errMsg = "Web service is wrong: " + err.Message;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
        if (wsSQLResult.SQLOK == false)
            Response.Write("<script>alert('" + wsSQLResult.SQLError + "')</script>");
        ProcessObject(ref wsSQLResult);
    }
    private void ProcessObject(ref WS_SQLUpdateDelete.SQLBase wsResult)
    {
        string errMsg;
        if (wsResult.SQLOK == true)
            FillCourseListBox(ref wsResult);
        else
        {
            errMsg = "Course information cannot be retrieved: " + wsResult.SQLError;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
    }
    private void FillCourseListBox(ref WS_SQLUpdateDelete.SQLBase sqlResult)
    {
        int index = 0;

        CourseList.Items.Clear();                    //clean up the course listbox
        for (index = 0; index <= sqlResult.CourseID.Length - 1; index++)
        {
            CourseList.Items.Add(sqlResult.CourseID[index]);
        }
    }  
    protected void CourseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        WS_SQLUpdateDelete.WebServiceSQLUpdateDelete wsSQLSelect = new WS_SQLUpdateDelete.WebServiceSQLUpdateDelete();
        string errMsg;

        try { wsSQLResult = wsSQLSelect.GetSQLCourseDetail(CourseList.Text); }
        catch (Exception err) { errMsg = "Web service is wrong: " + err.Message;
                                Response.Write("<script>alert('" + errMsg + "')</script>"); }

        if (wsSQLResult.SQLOK == false)
            Response.Write("<script>alert('" + wsSQLResult.SQLError + "')</script>");
        FillCourseDetail(ref wsSQLResult);
    }
    private void FillCourseDetail(ref WS_SQLUpdateDelete.SQLBase sqlResult)
    {
        txtCourseID.Text = CourseList.Text;
        txtCourseName.Text = sqlResult.Course;
        txtSchedule.Text = sqlResult.Schedule;
        txtClassRoom.Text = sqlResult.Classroom;
        txtCredits.Text = sqlResult.Credit.ToString();
        txtEnroll.Text = sqlResult.Enrollment.ToString();
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        WS_SQLUpdateDelete.WebServiceSQLUpdateDelete wsSQLUpdate = new WS_SQLUpdateDelete.WebServiceSQLUpdateDelete();
        string errMsg;

        try
        {
            wsSQLResult = wsSQLUpdate.SQLUpdateSP(ComboName.Text, txtCourseID.Text, txtCourseName.Text,
                          txtSchedule.Text, txtClassRoom.Text, Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
        }
        catch (Exception err)
        {
            errMsg = "Web service is wrong: " + err.Message;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
        if (wsSQLResult.SQLOK == false)
            Response.Write("<script>alert('" + wsSQLResult.SQLError + "')</script>");
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        WS_SQLUpdateDelete.WebServiceSQLUpdateDelete wsSQLDelete = new WS_SQLUpdateDelete.WebServiceSQLUpdateDelete();
        string errMsg;

        try
        {
            wsSQLResult = wsSQLDelete.SQLDeleteSP(txtCourseID.Text);
        }
        catch (Exception err)
        {
            errMsg = "Web service is wrong: " + err.Message;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
        if (wsSQLResult.SQLOK == false)
            Response.Write("<script>alert('" + wsSQLResult.SQLError + "')</script>");
    }
}
