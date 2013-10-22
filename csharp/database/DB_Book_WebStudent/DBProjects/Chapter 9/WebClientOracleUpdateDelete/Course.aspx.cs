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
    WS_OracleUpdateDelete.OracleBase wsOracleResult = new WS_OracleUpdateDelete.OracleBase();

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
        WS_OracleUpdateDelete.WebServiceOracleUpdateDelete wsOracleSelect = new WS_OracleUpdateDelete.WebServiceOracleUpdateDelete();
        string errMsg;

        try { wsOracleResult = wsOracleSelect.GetOracleCourse(ComboName.Text); }
        catch (Exception err)
        {
            errMsg = "Web service is wrong: " + err.Message;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
        if (wsOracleResult.OracleOK == false)
            Response.Write("<script>alert('" + wsOracleResult.OracleError + "')</script>");
        ProcessObject(ref wsOracleResult);
    }
    private void ProcessObject(ref WS_OracleUpdateDelete.OracleBase wsResult)
    {
        string errMsg;
        if (wsResult.OracleOK == true)
            FillCourseListBox(ref wsResult);
        else
        {
            errMsg = "Course information cannot be retrieved: " + wsResult.OracleError;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
    }
    private void FillCourseListBox(ref WS_OracleUpdateDelete.OracleBase oraResult)
    {
        int index = 0;

        CourseList.Items.Clear();                    //clean up the course listbox
        for (index = 0; index <= oraResult.CourseID.Length - 1; index++)
        {
            CourseList.Items.Add(oraResult.CourseID[index]);
        }
    }  
    protected void CourseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        WS_OracleUpdateDelete.WebServiceOracleUpdateDelete wsOracleSelect = new WS_OracleUpdateDelete.WebServiceOracleUpdateDelete();
        string errMsg;

        try { wsOracleResult = wsOracleSelect.GetOracleCourseDetail(CourseList.Text); }
        catch (Exception err) { errMsg = "Web service is wrong: " + err.Message;
                                Response.Write("<script>alert('" + errMsg + "')</script>"); }

        if (wsOracleResult.OracleOK == false)
            Response.Write("<script>alert('" + wsOracleResult.OracleError + "')</script>");
        FillCourseDetail(ref wsOracleResult);
    }
    private void FillCourseDetail(ref WS_OracleUpdateDelete.OracleBase oraResult)
    {
        txtCourseID.Text = CourseList.Text;
        txtCourseName.Text = oraResult.Course;
        txtSchedule.Text = oraResult.Schedule;
        txtClassRoom.Text = oraResult.Classroom;
        txtCredits.Text = oraResult.Credit.ToString();
        txtEnroll.Text = oraResult.Enrollment.ToString();
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        WS_OracleUpdateDelete.WebServiceOracleUpdateDelete wsOracleUpdate = new WS_OracleUpdateDelete.WebServiceOracleUpdateDelete();
        string errMsg;

        try
        {
            wsOracleResult = wsOracleUpdate.OracleUpdateSP(ComboName.Text, txtCourseID.Text, txtCourseName.Text,
                          txtSchedule.Text, txtClassRoom.Text, Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
        }
        catch (Exception err)
        {
            errMsg = "Web service is wrong: " + err.Message;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
        if (wsOracleResult.OracleOK == false)
            Response.Write("<script>alert('" + wsOracleResult.OracleError + "')</script>");
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        WS_OracleUpdateDelete.WebServiceOracleUpdateDelete wsOracleDelete = new WS_OracleUpdateDelete.WebServiceOracleUpdateDelete();
        string errMsg;

        try
        {
            wsOracleResult = wsOracleDelete.OracleDeleteSP(txtCourseID.Text);
        }
        catch (Exception err)
        {
            errMsg = "Web service is wrong: " + err.Message;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
        if (wsOracleResult.OracleOK == false)
            Response.Write("<script>alert('" + wsOracleResult.OracleError + "')</script>");
    }
}
