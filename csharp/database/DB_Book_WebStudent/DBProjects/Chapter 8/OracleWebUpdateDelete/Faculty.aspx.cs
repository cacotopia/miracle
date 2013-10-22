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

public partial class Faculty : System.Web.UI.Page
{
    private TextBox[] FacultyTextBox = new TextBox[7];    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((OracleConnection)Application["oraConnection"]).State != ConnectionState.Open)
            ((OracleConnection)Application["oraConnection"]).Open();

        if (!IsPostBack)
        {
            UpdateFaculty();                        		 
            ComboName.SelectedIndex = 0;
        }
    }
    public void UpdateFaculty()
    {
        OracleCommand oraCommand = new OracleCommand("SELECT faculty_name FROM Faculty", 
                                       (OracleConnection)Application["oraConnection"]);
        OracleDataReader oraReader = oraCommand.ExecuteReader();
        while (oraReader.Read())
        {
            ComboName.Items.Add(oraReader[0].ToString());
        }
        oraReader.Close();
        oraCommand.Dispose();
    }
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        string cmdString = "SELECT faculty_id, faculty_name, office, phone, college, title, email FROM Faculty ";
        cmdString += "WHERE faculty_name =: name";
        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraDataReader;

        oraCommand.Connection = (OracleConnection)Application["oraConnection"];
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("name", OracleType.Char).Value = ComboName.Text;
        string strName = ShowFaculty(ComboName.Text);
        oraDataReader = oraCommand.ExecuteReader();
        if (oraDataReader.HasRows == true)
            FillFacultyReader(oraDataReader);
        else
            Response.Write("<script>alert('No matched faculty found!')</script>");
        oraDataReader.Close();
        oraCommand.Dispose();
    }
    private void FillFacultyReader(OracleDataReader FacultyReader)
    {
        int intIndex = 0;

        for (intIndex = 0; intIndex <= 6; intIndex++)        //Initialize the object array
            FacultyTextBox[intIndex] = new TextBox();
        MapFacultyTable(FacultyTextBox);
        while (FacultyReader.Read())
        {
            for (intIndex = 0; intIndex <= FacultyReader.FieldCount - 1; intIndex++)
                FacultyTextBox[intIndex].Text = FacultyReader.GetString(intIndex);
        }
    }
    private void MapFacultyTable(Object[] fText)        
    {
        fText[0] = txtID;
        fText[1] = txtName;                             
        fText[2] = txtOffice;     //The order must be identical
        fText[3] = txtPhone;      //with the real order in the query string
        fText[4] = txtCollege;
        fText[5] = txtTitle;
        fText[6] = txtEmail;
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
            if (((string)Application["FacultyImage"] == string.Empty) || (string)Application["FacultyImage"] == null)
                FacultyImage = "Default.jpg";
            else
                FacultyImage = (string)Application["FacultyImage"];
        PhotoBox.ImageUrl = FacultyImage;

        return FacultyImage;
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Selection.aspx");
    }
    protected void cmdInsert_Click(object sender, EventArgs e)
    {
        string cmdString = "INSERT INTO Faculty (faculty_id, faculty_name, office, phone, college, title, email) " +
                           "VALUES (:faculty_id,:faculty_name,:office,:phone,:college,:title,:email)";
        OracleCommand oraCommand = new OracleCommand();
        string FacultyImage;
        int intInsert = 0;

        FacultyImage = txtPhoto.Text;                	 //reserve the new inserted faculty photo location
        if (FacultyImage == string.Empty)
            FacultyImage = "Default.jpg";

        Application["FacultyImage"] = FacultyImage;      //reserve faculty image for validation
        PhotoBox.ImageUrl = FacultyImage;
        oraCommand.Connection = (OracleConnection)Application["oraConnection"];
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        InsertParameters(oraCommand);
        intInsert = oraCommand.ExecuteNonQuery();
        oraCommand.Dispose();
        if (intInsert == 0)
            Response.Write("<script>alert('The data insertion is failed')</script>");
        else
        {
            cmdInsert.Enabled = false;                      //disable the Insert button
            ComboName.Items.Clear();
            UpdateFaculty();
        }
    }
    private void InsertParameters(OracleCommand cmd)
    {
        cmd.Parameters.Add("faculty_id", OracleType.Char).Value = txtID.Text;
        cmd.Parameters.Add("faculty_name", OracleType.Char).Value = txtName.Text;
        cmd.Parameters.Add("office", OracleType.Char).Value = txtOffice.Text;
        cmd.Parameters.Add("phone", OracleType.Char).Value = txtPhone.Text;
        cmd.Parameters.Add("college", OracleType.Char).Value = txtCollege.Text;
        cmd.Parameters.Add("title", OracleType.Char).Value = txtTitle.Text;
        cmd.Parameters.Add("email", OracleType.Char).Value = txtEmail.Text;
    }
    protected void txtID_TextChanged(object sender, EventArgs e)
    {
        cmdInsert.Enabled = true;       //enable the Insert button when the faculty_id is changed
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        string cmdString = "UPDATE Faculty SET faculty_name=:name, office=:office, phone=:phone, " +
                           "college=:college, title=:title, email=:email WHERE (faculty_name =: oldName)";
        OracleCommand oraCommand = new OracleCommand();
        string FacultyImage;
        int intUpdate = 0;

        txtID.Text = string.Empty;
        FacultyImage = txtPhoto.Text;                	 //reserve the new inserted faculty photo location
        if (FacultyImage == string.Empty)
            FacultyImage = "Default.jpg";

        Application["FacultyImage"] = FacultyImage;      //reserve faculty image for validation
        oraCommand.Connection = (OracleConnection)Application["oraConnection"];
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        UpdateParameters(ref oraCommand);
        intUpdate = oraCommand.ExecuteNonQuery();
        oraCommand.Dispose();
        ComboName.Items.Clear();
        UpdateFaculty();
        txtPhoto.Text = string.Empty;                   //clean up the faculty photo box

        if (intUpdate == 0)
            Response.Write("<script>alert('The data updating is failed')</script>");
    }
    private void UpdateParameters(ref OracleCommand cmd)
    {
        cmd.Parameters.Add("name", OracleType.Char).Value = txtName.Text;
        cmd.Parameters.Add("office", OracleType.Char).Value = txtOffice.Text;
        cmd.Parameters.Add("phone", OracleType.Char).Value = txtPhone.Text;
        cmd.Parameters.Add("college", OracleType.Char).Value = txtCollege.Text;
        cmd.Parameters.Add("title", OracleType.Char).Value = txtTitle.Text;
        cmd.Parameters.Add("email", OracleType.Char).Value = txtEmail.Text;
        cmd.Parameters.Add("oldName", OracleType.Char).Value = ComboName.Text;
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        string cmdString = "DeleteFaculty_SP";

        OracleCommand oraCommand = new OracleCommand();
        int intDelete = 0;
        oraCommand.Connection = (OracleConnection)Application["oraConnection"];
        oraCommand.CommandType = CommandType.StoredProcedure;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("FacultyName", OracleType.Char).Value = ComboName.Text;
        intDelete = oraCommand.ExecuteNonQuery();
        oraCommand.Dispose();

        if (intDelete == 0)
            Response.Write("<script>alert('The data deleting is failed')</script>");
        for (intDelete = 0; intDelete < 7; intDelete++)            // clean up the Faculty textbox array
        {
            FacultyTextBox[intDelete] = new TextBox();
            FacultyTextBox[intDelete].Text = string.Empty;
        }
 //       ComboName.Items.Clear();
 //       UpdateFaculty();
    }
}
