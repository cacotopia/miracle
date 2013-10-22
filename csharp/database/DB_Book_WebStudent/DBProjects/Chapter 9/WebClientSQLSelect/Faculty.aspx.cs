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

public partial class Faculty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ComboName.Items.Add("Ying Bai");
            ComboName.Items.Add("Satish Bhalla");
            ComboName.Items.Add("Black Anderson");
            ComboName.Items.Add("Steve Johnson");
            ComboName.Items.Add("Jenney King");
            ComboName.Items.Add("Alice Brown");
            ComboName.Items.Add("Debby Angles");
            ComboName.Items.Add("Jeff Henry");
            ComboMethod.Items.Add("Object Method");
            ComboMethod.Items.Add("Stored Procedure Method");
            ComboMethod.Items.Add("DataSet Method");
        }
    }
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        WS_SQLSelect.WebServiceSQLSelect wsSQLSelect = new WS_SQLSelect.WebServiceSQLSelect();
        WS_SQLSelect.SQLSelectResult wsSQLResult = new WS_SQLSelect.SQLSelectResult();
        DataSet wsDataSet = new DataSet();
        string errMsg;

        ShowFaculty(ComboName.Text);
        if (ComboMethod.Text == "Object Method")
        {
            try {wsSQLResult = wsSQLSelect.GetSQLSelect(ComboName.Text);}
            catch (Exception err)
            {
                errMsg = "Web service is wrong: " + err.Message;
                Response.Write("<script>alert('" + errMsg + "')</script>");
            }
            ProcessObject(ref wsSQLResult);
        }
        else if (ComboMethod.Text == "Stored Procedure Method")
        {
            try { wsSQLResult = wsSQLSelect.GetSQLSelectSP(ComboName.Text); }
            catch (Exception err)
            {
                errMsg = "Web service is wrong: " + err.Message;
                Response.Write("<script>alert('" + errMsg + "')</script>");
            }
            ProcessObject(ref wsSQLResult);
        }
        else
        {
            try { wsDataSet = wsSQLSelect.GetSQLSelectDataSet(ComboName.Text); }
            catch (Exception err)
            {
                errMsg = "Web service is wrong: " + err.Message;
                Response.Write("<script>alert('" + errMsg + "')</script>");
            }
            FillFacultyDataSet(ref wsDataSet);
        }
    }
    private void ProcessObject(ref WS_SQLSelect.SQLSelectResult wsResult)
    {
        string errMsg;
        errMsg = "Faculty information cannot be retrieved: " + wsResult.SQLRequestError;

        if (wsResult.SQLRequestOK == true)
            FillFacultyObject(ref wsResult);
        else
            Response.Write("<script>alert('" + errMsg + "')</script>");
    }

    private void FillFacultyObject(ref WS_SQLSelect.SQLSelectResult sqlResult)
    {
        txtID.Text = sqlResult.FacultyID;
        txtOffice.Text = sqlResult.FacultyOffice;
        txtPhone.Text = sqlResult.FacultyPhone;
        txtCollege.Text = sqlResult.FacultyCollege;
        txtTitle.Text = sqlResult.FacultyTitle;
        txtEmail.Text = sqlResult.FacultyEmail;
    }
    private void FillFacultyDataSet(ref DataSet ds)
    {
        DataTable FacultyTable = new DataTable();
        DataRow FacultyRow;

        FacultyTable = ds.Tables["Faculty"];
        FacultyRow = FacultyTable.Rows[0];          		 //only one rwo in the Faculty table
        txtID.Text = FacultyRow["faculty_id"].ToString();
        txtOffice.Text = FacultyRow["office"].ToString();
        txtPhone.Text = FacultyRow["phone"].ToString();
        txtCollege.Text = FacultyRow["college"].ToString();
        txtTitle.Text = FacultyRow["title"].ToString();
        txtEmail.Text = FacultyRow["email"].ToString();
    }

    private string ShowFaculty(string fName)
    {
        string FacultyImage;
        switch (fName)
        {
            case "Black Anderson":
                FacultyImage = "Anderson.jpg";
                break;
            case "Ying Bai":
                FacultyImage = "Bai.jpg";
                break;
            case "Satish Bhalla":
                FacultyImage = "Satish.jpg";
                break;
            case "Steve Johnson":
                FacultyImage = "Johnson.jpg";
                break;
            case "Jenney King":
                FacultyImage = "King.jpg";
                break;
            case "Alice Brown":
                FacultyImage = "Brown.jpg";
                break;
            case "Debby Angles":
                FacultyImage = "Angles.jpg";
                break;
            case "Jeff Henry":
                FacultyImage = "Henry.jpg";
                break;
            default:
                FacultyImage = "No Match";
                break;
        }
        if (FacultyImage != "No Match")
            PhotoBox.ImageUrl = FacultyImage;
        else
            Response.Write("<script>alert('No matched faculty image found!')</script>");
        return FacultyImage;
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close()</script>");
    }
}
