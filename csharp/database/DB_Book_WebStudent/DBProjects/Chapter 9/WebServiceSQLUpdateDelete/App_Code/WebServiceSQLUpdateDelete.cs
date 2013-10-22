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
public class WebServiceSQLUpdateDelete : System.Web.Services.WebService
{
    public WebServiceSQLUpdateDelete()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public SQLBase SQLUpdateSP(string FacultyName, string CourseID, string Course, string Schedule, 
                               string Classroom, int Credit, int Enroll)
    {
        string cmdString = "dbo.WebUpdateCourseSP";
       SqlConnection sqlConnection = new SqlConnection();
       SQLBase SQLResult = new SQLBase();
       SqlCommand sqlCommand = new SqlCommand();
       int intUpdate = 0;

       SQLResult.SQLOK = true;
       sqlConnection = SQLConn();
       if (sqlConnection == null)
       {
          SQLResult.SQLError = "Database connection is failed";
          ReportError(SQLResult);
          return null;
       }
       sqlCommand.Connection = sqlConnection;
       sqlCommand.CommandType = CommandType.StoredProcedure;
       sqlCommand.CommandText = cmdString;
       sqlCommand.Parameters.Add("@FacultyName", SqlDbType.Text).Value = FacultyName;
       sqlCommand.Parameters.Add("@CourseID", SqlDbType.Char).Value = CourseID;
       sqlCommand.Parameters.Add("@Course", SqlDbType.Text).Value = Course;
       sqlCommand.Parameters.Add("@Schedule", SqlDbType.Char).Value = Schedule;
       sqlCommand.Parameters.Add("@Classroom", SqlDbType.Text).Value = Classroom;
       sqlCommand.Parameters.Add("@Credit", SqlDbType.Int).Value = Credit;
       sqlCommand.Parameters.Add("@Enroll", SqlDbType.Int).Value = Enroll;
       intUpdate = sqlCommand.ExecuteNonQuery();
       sqlConnection.Close();
       sqlCommand.Dispose();
       if (intUpdate == 0)
       {
           SQLResult.SQLError = "Data updating is failed";
           ReportError(SQLResult);
       }
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
 
    protected void ReportError(SQLBase ErrSource)
    {
        ErrSource.SQLOK = false;
        MessageBox.Show(ErrSource.SQLError);
    }
    [WebMethod]
    public SQLBase GetSQLCourse(string FacultyName)
    {
        string cmdString = "SELECT Course.course_id FROM Course JOIN Faculty " +
                           "ON (Course.faculty_id LIKE Faculty.faculty_id) AND (Faculty.faculty_name LIKE @name)";
        SqlConnection sqlConnection = new SqlConnection();
        SQLBase SQLResult = new SQLBase();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlReader;

        SQLResult.SQLOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
            SQLResult.SQLError = "Database connection is failed";
            ReportError(SQLResult);
            return null;
        }
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@name", SqlDbType.Text).Value = FacultyName;
        sqlReader = sqlCommand.ExecuteReader();
        if (sqlReader.HasRows == true)
            FillCourseReader(ref SQLResult, sqlReader);
        else
        {
            SQLResult.SQLError = "No matched course found";
            ReportError(SQLResult);
        }
        sqlReader.Close();
        sqlConnection.Close();
        sqlCommand.Dispose();
        return SQLResult;
    }
    protected void FillCourseReader(ref SQLBase sResult, SqlDataReader sReader)
    {
        int pos = 0;

        while (sReader.Read())
        {
            sResult.CourseID[pos] = Convert.ToString(sReader.GetSqlString(0));       //the 1st column is course_id
            pos++;
        }
    }
    [WebMethod]
    public SQLBase GetSQLCourseDetail(string CourseID)
    {
        string cmdString = "dbo.WebSelectCourseSP";
        SqlConnection sqlConnection = new SqlConnection();
        SQLBase SQLResult = new SQLBase();
        SqlDataReader sqlReader;

        SQLResult.SQLOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
            SQLResult.SQLError = "Database connection is failed";
            ReportError(SQLResult);
            return null;
        }
        SqlCommand sqlCommand = new SqlCommand(cmdString, sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CourseID", SqlDbType.Text).Value = CourseID;
        sqlReader = sqlCommand.ExecuteReader();

        if (sqlReader.HasRows == true)
            FillCourseDetail(ref SQLResult, sqlReader);
        else
        {
            SQLResult.SQLError = "No matched course found";
            ReportError(SQLResult);
        }
        sqlReader.Close();
        sqlConnection.Close();
        sqlCommand.Dispose();
        return SQLResult;
    }
    protected void FillCourseDetail(ref SQLBase sResult, SqlDataReader sReader)
    {
        sReader.Read();
        sResult.FacultyID = Convert.ToString(sReader["faculty_id"]);
        sResult.Course = Convert.ToString(sReader["course"]);
        sResult.Schedule = Convert.ToString(sReader["schedule"]);
        sResult.Classroom = Convert.ToString(sReader["classroom"]);
        sResult.Credit = Convert.ToInt32(sReader["credit"]);
        sResult.Enrollment = Convert.ToInt32(sReader["enrollment"]);
    }
    [WebMethod]
    public SQLBase SQLDeleteSP(string CourseID)
    {
        string cmdString = "dbo.WebDeleteCourseSP";
        SqlConnection sqlConnection = new SqlConnection();
        SQLBase SQLResult = new SQLBase();
        int intDelete = 0;

        SQLResult.SQLOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
            SQLResult.SQLError = "Database connection is failed";
            ReportError(SQLResult);
            return null;
        }
        SqlCommand sqlCommand = new SqlCommand(cmdString, sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CourseID", SqlDbType.Text).Value = CourseID;
        intDelete = sqlCommand.ExecuteNonQuery();

        if (intDelete == 0)
        {
            SQLResult.SQLError = "Data deleting is failed";
            ReportError(SQLResult);
        }
        sqlConnection.Close();
        sqlCommand.Dispose();
        return SQLResult;
    }
}
