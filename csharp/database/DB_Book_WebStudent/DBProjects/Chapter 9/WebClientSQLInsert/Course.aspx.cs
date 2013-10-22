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
    WS_SQLInsert.SQLInsertBase wsSQLResult = new WS_SQLInsert.SQLInsertBase();

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
        WS_SQLInsert.WebServiceSQLInsert wsSQLInsert = new WS_SQLInsert.WebServiceSQLInsert();
        string errMsg;

        if (ComboMethod.Text == "Stored Procedure Method")
        {
            try { wsSQLResult = wsSQLInsert.GetSQLInsert(ComboName.Text); }
            catch (Exception err)
            {
                errMsg = "Web service is wrong: " + err.Message;
                Response.Write("<script>alert('" + errMsg + "')</script>");
            }
            if (wsSQLResult.SQLInsertOK == false)
                Response.Write("<script>alert('" + wsSQLResult.SQLInsertError + "')</script>");
            ProcessObject(ref wsSQLResult);
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
    private void ProcessObject(ref WS_SQLInsert.SQLInsertBase wsResult)
    {
        string errMsg;
        if (wsResult.SQLInsertOK == true)
            FillCourseListBox(ref wsResult);
        else
        {
            errMsg = "Course information cannot be retrieved: " + wsResult.SQLInsertError;
            Response.Write("<script>alert('" + errMsg + "')</script>");
        }
    }
    private void FillCourseListBox(ref WS_SQLInsert.SQLInsertBase sqlResult)
    {
        int index = 0;

        CourseList.Items.Clear();                    //clean up the course listbox
        for (index = 0; index <= sqlResult.CourseID.Length - 1; index++)
        {
            //if (sqlResult.CourseID[index] != null)
                CourseList.Items.Add(sqlResult.CourseID[index]);
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
        WS_SQLInsert.WebServiceSQLInsert wsSQLInsert = new WS_SQLInsert.WebServiceSQLInsert();
        string errMsg;

        try { wsSQLResult = wsSQLInsert.GetSQLInsertCourse(CourseList.Text); }
        catch (Exception err) { errMsg = "Web service is wrong: " + err.Message;
                                Response.Write("<script>alert('" + errMsg + "')</script>"); }

        if (wsSQLResult.SQLInsertOK == false)
            Response.Write("<script>alert('" + wsSQLResult.SQLInsertError + "')</script>");
        FillCourseDetail(ref wsSQLResult);
    }
    private void FillCourseDetail(ref WS_SQLInsert.SQLInsertBase sqlResult)
    {
        txtCourseID.Text = CourseList.Text;
        txtCourseName.Text = sqlResult.Course;
        txtSchedule.Text = sqlResult.Schedule;
        txtClassRoom.Text = sqlResult.Classroom;
        txtCredits.Text = sqlResult.Credit.ToString();
        txtEnroll.Text = sqlResult.Enrollment.ToString();
    }
    protected void cmdInsert_Click(object sender, EventArgs e)
    {
        WS_SQLInsert.WebServiceSQLInsert wsSQLInsert = new WS_SQLInsert.WebServiceSQLInsert();
        string errMsg;

        if (ComboMethod.Text == "Stored Procedure Method")
        {
            try
            {
                wsSQLResult = wsSQLInsert.SetSQLInsertSP(ComboName.Text, txtCourseID.Text,
                              txtCourseName.Text, txtSchedule.Text, txtClassRoom.Text,
                              Convert.ToInt32(txtCredits.Text), Convert.ToInt32(txtEnroll.Text));
            }
            catch (Exception err) { errMsg = "Web service is wrong: " + err.Message;
                                    Response.Write("<script>alert('" + errMsg + "')</script>"); }
            if (wsSQLResult.SQLInsertOK == false)
                Response.Write("<script>alert('" + wsSQLResult.SQLInsertError + "')</script>");
        }
        else
        {
            dsFlag = true;                      //indicate the DataSet insert is performed
            Application["dsFlag"] = dsFlag;		//reserve this flag as a global flag
            try
            {
                wsDataSet = wsSQLInsert.SQLInsertDataSet(ComboName.Text, txtCourseID.Text,
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
