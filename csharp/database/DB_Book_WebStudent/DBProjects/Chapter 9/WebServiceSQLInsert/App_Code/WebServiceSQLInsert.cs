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
public class WebServiceSQLInsert : System.Web.Services.WebService
{
    public WebServiceSQLInsert()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public SQLInsertBase SetSQLInsertSP(string FacultyName, string CourseID, string Course, string Schedule, 
                                        string Classroom, int Credit, int Enroll)
    {
       string cmdString = "dbo.InsertFacultyCourse";
       SqlConnection sqlConnection = new SqlConnection();
       SQLInsertBase SetSQLResult = new SQLInsertBase();
       SqlCommand sqlCommand = new SqlCommand();
       int intInsert = 0;

       SetSQLResult.SQLInsertOK = true;
       sqlConnection = SQLConn();
       if (sqlConnection == null)
       {
          SetSQLResult.SQLInsertError = "Database connection is failed";
          ReportError(SetSQLResult);
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
       intInsert = sqlCommand.ExecuteNonQuery();
       sqlConnection.Close();
       sqlCommand.Dispose();
       if (intInsert == 0)
       {
           SetSQLResult.SQLInsertError = "Data insertion is failed";
           ReportError(SetSQLResult);
       }
       return SetSQLResult;
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
 
    protected void ReportError(SQLInsertBase ErrSource)
    {
        ErrSource.SQLInsertOK = false;
        MessageBox.Show(ErrSource.SQLInsertError);
    }
    [WebMethod]
    public SQLInsertBase GetSQLInsert(string FacultyName)
    {
        string cmdString = "SELECT Course.course_id FROM Course JOIN Faculty " +
                           "ON (Course.faculty_id LIKE Faculty.faculty_id) AND (Faculty.faculty_name LIKE @name)";
        SqlConnection sqlConnection = new SqlConnection();
        SQLInsertBase GetSQLResult = new SQLInsertBase();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlReader;

        GetSQLResult.SQLInsertOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
            GetSQLResult.SQLInsertError = "Database connection is failed";
            ReportError(GetSQLResult);
            return null;
        }
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@name", SqlDbType.Text).Value = FacultyName;
        sqlReader = sqlCommand.ExecuteReader();
        if (sqlReader.HasRows == true)
            FillCourseReader(ref GetSQLResult, sqlReader);
        else
        {
            GetSQLResult.SQLInsertError = "No matched course found";
            ReportError(GetSQLResult);
        }
        sqlReader.Close();
        sqlConnection.Close();
        sqlCommand.Dispose();
        return GetSQLResult;
    }
    protected void FillCourseReader(ref SQLInsertBase sResult, SqlDataReader sReader)
    {
        int pos = 0;

        while (sReader.Read())
        {
            sResult.CourseID[pos] = Convert.ToString(sReader.GetSqlString(0));       //the 1st column is course_id
            pos++;
        }
    }
    [WebMethod]
    public SQLInsertBase GetSQLInsertCourse(string CourseID)
    {
        string cmdString = "dbo.WebSelectCourseSP";
        SqlConnection sqlConnection = new SqlConnection();
        SQLInsertBase GetSQLResult = new SQLInsertBase();
        SqlDataReader sqlReader;

        GetSQLResult.SQLInsertOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
            GetSQLResult.SQLInsertError = "Database connection is failed";
            ReportError(GetSQLResult);
            return null;
        }
        SqlCommand sqlCommand = new SqlCommand(cmdString, sqlConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.Add("@CourseID", SqlDbType.Text).Value = CourseID;
        sqlReader = sqlCommand.ExecuteReader();

        if (sqlReader.HasRows == true)
            FillCourseDetail(ref GetSQLResult, sqlReader);
        else
        {
            GetSQLResult.SQLInsertError = "No matched course found";
            ReportError(GetSQLResult);
        }
        sqlReader.Close();
        sqlConnection.Close();
        sqlCommand.Dispose();
        return GetSQLResult;
    }
    protected void FillCourseDetail(ref SQLInsertBase sResult, SqlDataReader sReader)
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
    public DataSet SQLInsertDataSet(string FacultyName, string CourseID, string Course, string Schedule, 
                                    string Classroom, int Credit, int Enroll)
    {
        string cmdString = "INSERT INTO Course VALUES  (@course_id, @course, @credit, @classroom, " + 
                                                       "@schedule, @enrollment, @faculty_id)";
        SqlConnection sqlConnection = new SqlConnection();
        SQLInsertBase SetSQLResult = new SQLInsertBase();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataAdapter CourseAdapter = new SqlDataAdapter();
        DataSet dsCourse = new DataSet();
        int intResult = 0;
        string FacultyID;

        SetSQLResult.SQLInsertOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
          SetSQLResult.SQLInsertError = "Database connection is failed";
          ReportError(SetSQLResult);
          return null;
        }
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = "SELECT faculty_id FROM Faculty WHERE faculty_name LIKE @Name";
        sqlCommand.Parameters.Add("@Name", SqlDbType.Text).Value = FacultyName;
        FacultyID = (string)sqlCommand.ExecuteScalar();

        sqlCommand.CommandText = cmdString;
        sqlCommand.Parameters.Add("@faculty_id", SqlDbType.Text).Value = FacultyID;
        sqlCommand.Parameters.Add("@course_id", SqlDbType.Char).Value = CourseID;
        sqlCommand.Parameters.Add("@course", SqlDbType.Text).Value = Course;
        sqlCommand.Parameters.Add("@schedule", SqlDbType.Char).Value = Schedule;
        sqlCommand.Parameters.Add("@classroom", SqlDbType.Text).Value = Classroom;
        sqlCommand.Parameters.Add("@credit", SqlDbType.Int).Value = Credit;
        sqlCommand.Parameters.Add("@enrollment", SqlDbType.Int).Value = Enroll;

        CourseAdapter.InsertCommand = sqlCommand;
        intResult = CourseAdapter.InsertCommand.ExecuteNonQuery();
        if (intResult == 0)
        {
            SetSQLResult.SQLInsertError = "No matched course found";
            ReportError(SetSQLResult);
        }
        sqlCommand.CommandText = "SELECT * FROM Course WHERE faculty_id LIKE @FacultyID";
        sqlCommand.Parameters.Add("@FacultyID", SqlDbType.Text).Value = FacultyID;
        CourseAdapter.SelectCommand = sqlCommand;
        CourseAdapter.Fill(dsCourse, "Course");
        CourseAdapter.Dispose();
        sqlConnection.Close();
        sqlCommand.Dispose();
        return dsCourse;
    }
}
