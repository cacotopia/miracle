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

public partial class _Default : System.Web.UI.Page 
{
    public SqlConnection sqlConnection;     

    protected void Page_Load(object sender, EventArgs e)
    {
        string sqlString = "Server=localhost;Data Source=.\\SQLEXPRESS;" +
                           "Database=C:\\database\\SQLServer\\CSE_DEPT.mdf;Integrated Security=SSPI";

        sqlConnection = new SqlConnection(sqlString);
        Application["sqlConnection"] = sqlConnection;	    //define a global connection object

        if (sqlConnection.State == ConnectionState.Open)
            sqlConnection.Close();

        sqlConnection.Open();

        if (sqlConnection.State != ConnectionState.Open)
            Response.Write("<script>alert('Database connection is Failed')</script>");
    }
    protected void cmdLogIn_Click(object sender, EventArgs e)
    {
        string cmdString = "SELECT user_name, pass_word, faculty_id, student_id FROM LogIn ";
        cmdString += "WHERE (user_name=@name) AND (pass_word=@word)";

        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlReader;

        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@name", SqlDbType.Char).Value = txtUserName.Text;
        sqlCommand.Parameters.Add("@word", SqlDbType.Char, 8).Value = txtPassWord.Text;
        sqlReader = sqlCommand.ExecuteReader();
        if (sqlReader.HasRows == true)
        {
            Response.Redirect("Selection.aspx");
        }
        else
            Response.Write("<script>alert('No matched username/password found!')</script>");
        sqlCommand.Dispose();
        sqlReader.Close();
    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        if (sqlConnection.State == ConnectionState.Open)
            sqlConnection.Close();
        Response.Write("<script>window.close()</script>");
    }
}
