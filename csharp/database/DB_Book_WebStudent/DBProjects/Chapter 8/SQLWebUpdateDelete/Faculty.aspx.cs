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

public partial class Faculty : System.Web.UI.Page
{
    private TextBox[] FacultyTextBox = new TextBox[7];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((SqlConnection)Application["sqlConnection"]).State != ConnectionState.Open)
            ((SqlConnection)Application["sqlConnection"]).Open();

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
        } 
        
        if ((string)Application["FacultyName"] != string.Empty)
        {
            ComboName.Items.Add((string)Application["FacultyName"]);
            Application["FacultyName"] = string.Empty;
        }
    }
    
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        string cmdString = "SELECT faculty_id, faculty_name, office, phone, college, title, email FROM Faculty ";
        cmdString += "WHERE faculty_name LIKE @name";
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;

        Application["oldFacultyName"] = ComboName.Text;
        sqlCommand.Connection = (SqlConnection)Application["sqlConnection"];
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@name", SqlDbType.Char).Value = ComboName.Text;
        string strName = ShowFaculty(ComboName.Text);
        sqlDataReader = sqlCommand.ExecuteReader();
        if (sqlDataReader.HasRows == true)
            FillFacultyReader(sqlDataReader);
        else
            Response.Write("<script>alert('No matched faculty found!')</script>");
        sqlDataReader.Close();
        sqlDataReader.Dispose();
        sqlCommand.Dispose();
    }
    private void FillFacultyReader(SqlDataReader FacultyReader)
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
        Response.Redirect("Insert.aspx");
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        string cmdString = "UPDATE Faculty SET faculty_name = @name, office = @office, phone = @phone, " +
                           "college = @college, title = @title, email = @email " +
                           "WHERE (faculty_name LIKE @oldName)";
        SqlCommand sqlCommand = new SqlCommand();
        int intUpdate = 0;

        txtID.Text = string.Empty;               		                        //clean up the faculty_id textbox 

        if (txtName.Text != (string)Application["oldFacultyName"])              //the faculty name is updated
        {
            ComboName.Items.Add(txtName.Text);
            ComboName.Items.Remove((string)Application["oldFacultyName"]);
        }
        sqlCommand.Connection = (SqlConnection)Application["sqlConnection"];
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        UpdateParameters(ref sqlCommand);
        intUpdate = sqlCommand.ExecuteNonQuery();
        sqlCommand.Dispose();

        if (intUpdate == 0)
            Response.Write("<script>alert('The data updating is failed')</script>");
    }
    private void UpdateParameters(ref SqlCommand cmd)
    {
        cmd.Parameters.Add("@name", SqlDbType.Char).Value = txtName.Text;
        cmd.Parameters.Add("@office", SqlDbType.Char).Value = txtOffice.Text;
        cmd.Parameters.Add("@phone", SqlDbType.Char).Value = txtPhone.Text;
        cmd.Parameters.Add("@college", SqlDbType.Char).Value = txtCollege.Text;
        cmd.Parameters.Add("@title", SqlDbType.Char).Value = txtTitle.Text;
        cmd.Parameters.Add("@email", SqlDbType.Char).Value = txtEmail.Text;
        cmd.Parameters.Add("@oldName", SqlDbType.Char).Value = ComboName.Text;
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        string cmdString = "DELETE FROM Faculty WHERE (faculty_name LIKE @FacultyName)";
        SqlCommand sqlCommand = new SqlCommand();
        int intDelete = 0;

        sqlCommand.Connection = (SqlConnection)Application["sqlConnection"]; 
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@FacultyName", SqlDbType.Char).Value = ComboName.Text;
        intDelete = sqlCommand.ExecuteNonQuery();
        sqlCommand.Dispose();

        if (intDelete == 0)
            Response.Write("<script>alert('The data deleting is failed')</script>");
        for (intDelete = 0; intDelete < 7; intDelete++)            // clean up the Faculty textbox array
        {
            FacultyTextBox[intDelete] = new TextBox();
            FacultyTextBox[intDelete].Text = string.Empty;
        }
    }
}
