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
    private bool dsFlag = false;
    private DataSet wsDataSet = new DataSet();
    WS_OracleInsert.OracleInsertBase wsOracleResult = new WS_OracleInsert.OracleInsertBase();

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
            ComboMethod.Items.Add("DataSet Method");
        }
    }

    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close()</script>");
    }
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        WS_OracleInsert.WebServiceOracleInsert wsOracleInsert = new WS_OracleInsert.WebServiceOracleInsert();
        string errMsg;

        if (ComboMethod.Text == "Stored Procedure Method")
        {
            try { wsOracleResult = wsOracleInsert.GetOracleInsert(ComboName.Text); }
            catch (Exception err)
            {
                errMsg = "Web service is wrong: " + err.Message;
                Response.Write("<script>alert('" + errMsg + "')</script>");
            }
            if (wsOracleResult.OracleInsertOK == false)
                Response.Write("<script>alert('" + wsOracleResult.OracleInsertError + "')</script>");
            ProcessObject(ref wsOracleResult);
        }
        else
        {
            dsFlag = (bool)Application["dsFlag"];
            if (dsFlag == false)
            {
                errMsg = "No DataSet Insertion performed, do that first";
                Response.Write("<script>alert('" + errMsg + "')</script>");
            }
            wsDataSet = (DataSet)Application["wsDataSet"];
            FillCourseDataSet(ref wsDataSet);
            Application["dsFlag"] = false;
        }
    }
    private void ProcessObject(ref WS_OracleInsert.OracleInsertBase wsResult)
    {
        string errMsg;
        if (wsResult.OracleInsertOK == true)
            FillCourseListBox(ref wsResult);
        else
        {
            errMsg = "Course information cannot be retrieved: " + wsResult.OracleInsertError;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
    }
    private void FillCourseListBox(ref WS_OracleInsert.OracleInsertBase oraResult)
    {
        int index = 0;

        CourseList.Items.Clear();                    //clean up the course listbox
        for (index = 0; index <= oraResult.CourseID.Length - 1; index++)
        {
                CourseList.Items.Add(oraResult.CourseID[index]);
        }
    }
    private void FillCourseDataSet(ref DataSet ds)
    {
        DataTable CourseTable = new DataTable();

        CourseList.Items.Clear();                    	     //clean up the course listbox
        CourseTable = ds.Tables["Course"];

        foreach (DataRow CourseRow in CourseTable.Rows)
        {
            CourseList.Items.Add(CourseRow[0].ToString());  //the 1st column is course_id
        }
    }
    
    protected void CourseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        WS_OracleInsert.WebServiceOracleInsert wsOracleInsert = new WS_OracleInsert.WebServiceOracleInsert();
        string errMsg;

        try { wsOracleResult = wsOracleInsert.GetOracleInsertCourse(CourseList.Text); }
        catch (Exception err) { errMsg = "Web service is wrong: " + err.Message;
                                Response.Write("<script>alert('" + errMsg + "')</script>"); }

        if (wsOracleResult.OracleInsertOK == false)
            Response.Write("<script>alert('" + wsOracleResult.OracleInsertError + "')</script>");
        FillCourseDetail(ref wsOracleResult);
    }
    private void FillCourseDetail(ref WS_OracleInsert.OracleInsertBase oraResult)
    {
        txtCourseID.Text = CourseList.Text;
        txtCourseName.Text = oraResult.Course;
        txtSchedule.Text = oraResult.Schedule;
        txtClassRoom.Text = oraResult.Classroom;
        txtCredits.Text = oraResult.Credit.ToString();
        txtEnroll.Text = oraResult.Enrollment.ToString();
    }
    protected void cmdInsert_Click(object sender, EventArgs e)
    {
        WS_OracleInsert.WebServiceOracleInsert wsOracleInsert = new WS_OracleInsert.WebServiceOracleInsert();
        string errMsg;

        if (ComboMethod.Text == "Stored Procedure Method")
        {
            try
            {
                wsOracleResult = wsOracleInsert.SetOracleInsertSP(ComboName.Text, txtCourseID.Text,
                                 txtCourseName.Text, txtSchedule.Text, txtClassRoom.Text,
                                 Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
            }
            catch (Exception err) { errMsg = "Web service is wrong: " + err.Message;
                                    Response.Write("<script>alert('" + errMsg + "')</script>"); }
            if (wsOracleResult.OracleInsertOK == false)
                Response.Write("<script>alert('" + wsOracleResult.OracleInsertError + "')</script>");
        }
        else
        {
            dsFlag = true;                      //indicate the DataSet insert is performed
            Application["dsFlag"] = dsFlag;		//reserve this flag as a global flag
            try
            {
                wsDataSet = wsOracleInsert.OracleInsertDataSet(ComboName.Text, txtCourseID.Text,
                            txtCourseName.Text, txtSchedule.Text, txtClassRoom.Text,
                            Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
            }
            catch (Exception err) { errMsg = "Web service is wrong: " + err.Message;
                                    Response.Write("<script>alert('" + errMsg + "')</script>"); }
        }
        Application["wsDataSet"] = wsDataSet;   //reserve the global DataSet
        cmdInsert.Enabled = false;
    }
    protected void txtCourseID_TextChanged(object sender, EventArgs e)
    {
        cmdInsert.Enabled = true;
    }
}
