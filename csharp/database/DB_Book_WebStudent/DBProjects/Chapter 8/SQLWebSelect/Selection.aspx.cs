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

public partial class Selection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ComboSelection.Items.Add("Faculty Information");
        ComboSelection.Items.Add("Course Information");
        ComboSelection.Items.Add("Student Information");
    }
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        if (ComboSelection.Text == "Faculty Information")
            Response.Redirect("Faculty.aspx");
        else if (ComboSelection.Text == "Student Information")
            Response.Redirect("Student.aspx");
        else if (ComboSelection.Text == "Course Information")
            Response.Redirect("Course.aspx");
    }
    protected void cmdExit_Click(object sender, EventArgs e)
    {
        if (((SqlConnection)Application["sqlConnection"]).State == ConnectionState.Open)
            ((SqlConnection)Application["sqlConnection"]).Close();
        Response.Write("<script>window.close()</script>");
    }
}
