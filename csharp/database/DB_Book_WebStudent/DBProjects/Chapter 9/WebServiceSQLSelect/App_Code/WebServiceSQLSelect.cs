using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

[WebService(Namespace = "http://www.ieee.org/9780521712354/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceSQLSelect : System.Web.Services.WebService
{
    public WebServiceSQLSelect()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public SQLSelectResult GetSQLSelect(string FacultyName)
    {
        SqlConnection sqlConnection = new SqlConnection();
        SQLSelectResult SQLResult = new SQLSelectResult();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlReader;
        string cmdString = "SELECT faculty_id, office, phone, college, title, email FROM Faculty " + 
                           "WHERE faculty_name LIKE @facultyName";
        SQLResult.SQLRequestOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
           SQLResult.SQLRequestError = "Database connection is failed";
           ReportError(SQLResult);
           return null;
        }
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@facultyName", SqlDbType.Text).Value = FacultyName;
        sqlReader = sqlCommand.ExecuteReader();

        if (sqlReader.HasRows == true)
           FillFacultyReader(ref SQLResult, sqlReader);
        else
        {
           SQLResult.SQLRequestError = "No matched faculty found";
           ReportError(SQLResult);
        }
        sqlReader.Close();
        sqlConnection.Close();
        sqlCommand.Dispose();
        return SQLResult;
    }
    protected SqlConnection SQLConn()
    {
        string cmdString = ConfigurationManager.ConnectionStrings["sql_conn"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = cmdString;
        conn.Open();
        if (conn.State != System.Data.ConnectionState.Open)
        {
            MessageBox.Show("Database Open is failed");
            conn = null;
        }
        return conn;
    } 
    protected void FillFacultyReader(ref SQLSelectResult sResult, SqlDataReader sReader)
    {
      if (sReader.Read() == true)
      {
          sResult.FacultyID = Convert.ToString(sReader["faculty_id"]);
          sResult.FacultyOffice = Convert.ToString(sReader["office"]);
          sResult.FacultyPhone = Convert.ToString(sReader["phone"]);
          sResult.FacultyCollege = Convert.ToString(sReader["college"]);
          sResult.FacultyTitle = Convert.ToString(sReader["title"]);
          sResult.FacultyEmail = Convert.ToString(sReader["email"]);
      }
    }
    protected void ReportError(SQLSelectResult ErrSource)
    {
        ErrSource.SQLRequestOK = false;
        MessageBox.Show(ErrSource.SQLRequestError);
    }
    [WebMethod]
    public SQLSelectResult GetSQLSelectSP(string FacultyName)
    {
        SqlConnection sqlConnection = new SqlConnection();
        SQLSelectResult SQLResult = new SQLSelectResult();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlReader;
        string cmdString = "dbo.WebSelectFacultySP";
        SQLResult.SQLRequestOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
            SQLResult.SQLRequestError = "Database connection is failed";
            ReportError(SQLResult);
            return null;
        }
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@facultyName", SqlDbType.Text).Value = FacultyName;
        sqlReader = sqlCommand.ExecuteReader();

        if (sqlReader.HasRows == true)
            FillFacultyReader(ref SQLResult, sqlReader);
        else
        {
            SQLResult.SQLRequestError = "No matched faculty found";
            ReportError(SQLResult);
        }
        sqlReader.Close();
        sqlConnection.Close();
        sqlCommand.Dispose();
        return SQLResult;
    }
    [WebMethod]
    public DataSet GetSQLSelectDataSet(string FacultyName)
    {
        SqlConnection sqlConnection = new SqlConnection();
        SQLSelectResult SQLResult = new SQLSelectResult();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataAdapter FacultyAdapter = new SqlDataAdapter();
        DataSet dsFaculty = new DataSet();
        int intResult = 0;

        string cmdString = "SELECT faculty_id, office, phone, college, title, email FROM Faculty " +
                           "WHERE faculty_name LIKE @facultyName";
        SQLResult.SQLRequestOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
            SQLResult.SQLRequestError = "Database connection is failed";
            ReportError(SQLResult);
            return null;
        }
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@facultyName", SqlDbType.Text).Value = FacultyName;
        FacultyAdapter.SelectCommand = sqlCommand;
        intResult = FacultyAdapter.Fill(dsFaculty, "Faculty");

        if (intResult == 0)
        {
            SQLResult.SQLRequestError = "No matched faculty found";
            ReportError(SQLResult);
        }
        sqlConnection.Close();
        sqlCommand.Dispose();
        FacultyAdapter.Dispose();
        return dsFaculty;
    }
}
