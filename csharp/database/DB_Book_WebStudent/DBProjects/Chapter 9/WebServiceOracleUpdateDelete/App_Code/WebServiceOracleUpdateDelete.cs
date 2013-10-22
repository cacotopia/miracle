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
using System.Data.OracleClient;

[WebService(Namespace = "http://www.ieee.org/9780521712354/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceOracleUpdateDelete : System.Web.Services.WebService
{
    public WebServiceOracleUpdateDelete()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public OracleBase OracleUpdateSP(string FacultyName, string CourseID, string Course, string Schedule, 
                                     string Classroom, int Credit, int Enroll)
    {
       string cmdString = "UpdateCourse_SP";
       OracleConnection oraConnection = new OracleConnection();
       OracleBase OracleResult = new OracleBase();
       OracleCommand oraCommand = new OracleCommand();
       int intUpdate = 0;

       OracleResult.OracleOK = true;
       oraConnection = OracleConn();
       if (oraConnection == null)
       {
          OracleResult.OracleError = "Database connection is failed";
          ReportError(OracleResult);
          return null;
       }
       oraCommand.Connection = oraConnection;
       oraCommand.CommandType = CommandType.StoredProcedure;
       oraCommand.CommandText = cmdString;
       oraCommand.Parameters.Add("FacultyName", OracleType.VarChar).Value = FacultyName;
       oraCommand.Parameters.Add("inCourseID", OracleType.Char).Value = CourseID;
       oraCommand.Parameters.Add("inCourse", OracleType.VarChar).Value = Course;
       oraCommand.Parameters.Add("inSchedule", OracleType.Char).Value = Schedule;
       oraCommand.Parameters.Add("inClassroom", OracleType.VarChar).Value = Classroom;
       oraCommand.Parameters.Add("inCredit", OracleType.Int32).Value = Credit;
       oraCommand.Parameters.Add("inEnroll", OracleType.Int32).Value = Enroll;
       intUpdate = oraCommand.ExecuteNonQuery();
       oraConnection.Close();
       oraCommand.Dispose();
       if (intUpdate == 0)
       {
           OracleResult.OracleError = "Data updating is failed";
           ReportError(OracleResult);
       }
       return OracleResult;
    }
    protected OracleConnection OracleConn()
    {
        string cmdString = ConfigurationManager.ConnectionStrings["ora_conn"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = cmdString;
        conn.Open();
        if (conn.State != System.Data.ConnectionState.Open)
        {
            MessageBox.Show("Database Open is failed");
            conn = null;
        }
        return conn;
    }

    protected void ReportError(OracleBase ErrSource)
    {
        ErrSource.OracleOK = false;
        MessageBox.Show(ErrSource.OracleError);
    }
    [WebMethod]
    public OracleBase GetOracleCourse(string FacultyName)
    {
        string cmdString = "SELECT Course.course_id FROM Course, Faculty " + 
                           "WHERE (Course.faculty_id = Faculty.faculty_id) AND (Faculty.faculty_name =: fname)";
        OracleConnection oraConnection = new OracleConnection();
        OracleBase OracleResult = new OracleBase();
        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraReader;

        OracleResult.OracleOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
            OracleResult.OracleError = "Database connection is failed";
            ReportError(OracleResult);
            return null;
        }
        oraCommand.Connection = oraConnection;
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("fname", OracleType.VarChar).Value = FacultyName;
        oraReader = oraCommand.ExecuteReader();
        if (oraReader.HasRows == true)
            FillCourseReader(ref OracleResult, oraReader);
        else
        {
            OracleResult.OracleError = "No matched course found";
            ReportError(OracleResult);
        }
        oraReader.Close();
        oraConnection.Close();
        oraCommand.Dispose();
        return OracleResult;
    }
    protected void FillCourseReader(ref OracleBase sResult, OracleDataReader sReader)
    {
        int pos = 0;

        while (sReader.Read())
        {
            sResult.CourseID[pos] = Convert.ToString(sReader.GetOracleString(0));       //the 1st column is course_id
            pos++;
        }
    }
    [WebMethod]
    public OracleBase GetOracleCourseDetail(string CourseID)
    {
        string cmdString = "WebSelectCourseSP.SelectCourse";
        OracleConnection oraConnection = new OracleConnection();
        OracleBase OracleResult = new OracleBase();
        OracleDataReader oraReader;
        OracleParameter paramCourseID = new OracleParameter();
        OracleParameter paramCourseInfo = new OracleParameter();

        OracleResult.OracleOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
            OracleResult.OracleError = "Database connection is failed";
            ReportError(OracleResult);
            return null;
        }
        paramCourseID.ParameterName = "CourseID";
        paramCourseID.OracleType = OracleType.VarChar;
        paramCourseID.Value = CourseID;
        paramCourseInfo.ParameterName = "CourseInfo";
        paramCourseInfo.OracleType = OracleType.Cursor;
        paramCourseInfo.Direction = ParameterDirection.Output;        //this is very important

        OracleCommand oraCommand = new OracleCommand(cmdString, oraConnection);
        oraCommand.CommandType = CommandType.StoredProcedure;
        oraCommand.Parameters.Add(paramCourseID);
        oraCommand.Parameters.Add(paramCourseInfo);        

        oraReader = oraCommand.ExecuteReader();
        if (oraReader.HasRows == true)
            FillCourseDetail(ref OracleResult, oraReader);
        else
        {
            OracleResult.OracleError = "No matched course found";
            ReportError(OracleResult);
        }
        oraReader.Close();
        oraConnection.Close();
        oraCommand.Dispose();
        return OracleResult;
    }
    protected void FillCourseDetail(ref OracleBase sResult, OracleDataReader sReader)
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
    public OracleBase OracleDeleteSP(string CourseID)
    {
        string cmdString = "WebDeleteCourseSP";
        OracleConnection oraConnection = new OracleConnection();
        OracleBase OracleResult = new OracleBase();
        int intDelete = 0;

        OracleResult.OracleOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
            OracleResult.OracleError = "Database connection is failed";
            ReportError(OracleResult);
            return null;
        }
        OracleCommand oraCommand = new OracleCommand(cmdString, oraConnection);
        oraCommand.CommandType = CommandType.StoredProcedure;
        oraCommand.Parameters.Add("CourseID", OracleType.VarChar).Value = CourseID;
        intDelete = oraCommand.ExecuteNonQuery();

        if (intDelete == 0)
        {
            OracleResult.OracleError = "Data deleting is failed";
            ReportError(OracleResult);
        }
        oraConnection.Close();
        oraCommand.Dispose();
        return OracleResult;
    }
}
