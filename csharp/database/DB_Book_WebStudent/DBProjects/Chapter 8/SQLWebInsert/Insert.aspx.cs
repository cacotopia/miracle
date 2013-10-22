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

public partial class Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((SqlConnection)Application["sqlConnection"]).State != ConnectionState.Open)
            ((SqlConnection)Application["sqlConnection"]).Open();
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Faculty.aspx");
    }
    protected void cmdInsert_Click(object sender, EventArgs e)
    {
        string cmdString = "INSERT INTO Faculty (faculty_id, faculty_name, office, phone, college, title, email) " +
                           "VALUES (@faculty_id,@faculty_name,@office,@phone,@college,@title,@email)";
        SqlCommand sqlCommand = new SqlCommand();
        string FacultyImage;
        int intInsert = 0;

        FacultyImage = txtPhoto.Text;                	 //reserve the new inserted faculty photo location
        if (FacultyImage == string.Empty)
            FacultyImage = "Default.jpg";
      
        Application["FacultyImage"] = FacultyImage;      //reserve faculty image for validation
        PhotoBox.ImageUrl = FacultyImage;                 	 
        Application["FacultyName"] = txtName.Text;	     //reserve faculty name for validation
        sqlCommand.Connection = (SqlConnection)Application["sqlConnection"];
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        InsertParameters(sqlCommand);
        intInsert = sqlCommand.ExecuteNonQuery();
        sqlCommand.Dispose();
        if (intInsert == 0)
            Response.Write("<script>alert('The data insertion is failed')</script>");
        cmdInsert.Enabled = false;                      //disable the Insert button
    }
    private void InsertParameters(SqlCommand cmd)
    {
        cmd.Parameters.Add("@faculty_id", SqlDbType.Char).Value = txtID.Text;
        cmd.Parameters.Add("@faculty_name", SqlDbType.Char).Value = txtName.Text;
        cmd.Parameters.Add("@office", SqlDbType.Char).Value = txtOffice.Text;
        cmd.Parameters.Add("@phone", SqlDbType.Char).Value = txtPhone.Text;
        cmd.Parameters.Add("@college", SqlDbType.Char).Value = txtCollege.Text;
        cmd.Parameters.Add("@title", SqlDbType.Char).Value = txtTitle.Text;
        cmd.Parameters.Add("@email", SqlDbType.Char).Value = txtEmail.Text;
    }
}
