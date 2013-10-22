using System;
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

public partial class _Default : System.Web.UI.Page 
{
    public OracleConnection oraConnection;     

    protected void Page_Load(object sender, EventArgs e)
    {
        string oraString = "Data Source=XE; User ID=CSE_DEPT; Password=reback";

        oraConnection = new OracleConnection(oraString);
        Application["oraConnection"] = oraConnection;	    //define a global connection object

        if (oraConnection.State == ConnectionState.Open)
            oraConnection.Close();

        oraConnection.Open();

        if (oraConnection.State != ConnectionState.Open)
            Response.Write("<script>alert('Database connection is Failed')</script>");
    }
    protected void cmdLogIn_Click(object sender, EventArgs e)
    {
        string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
        cmdString += "WHERE (user_name=:name) AND (pass_word=:word)";

        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraReader;

        oraCommand.Connection = oraConnection;
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("name", OracleType.Char).Value = txtUserName.Text;
        oraCommand.Parameters.Add("word", OracleType.Char, 8).Value = txtPassWord.Text;
        oraReader = oraCommand.ExecuteReader();
        if (oraReader.HasRows == true)
        {
            Response.Redirect("Selection.aspx");
        }
        else
            Response.Write("<script>alert('No matched username/password found!')</script>");
        oraCommand.Dispose();
        oraReader.Close();
    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        if (oraConnection.State == ConnectionState.Open)
            oraConnection.Close();
        Response.Write("<script>window.close()</script>");
    }
}
