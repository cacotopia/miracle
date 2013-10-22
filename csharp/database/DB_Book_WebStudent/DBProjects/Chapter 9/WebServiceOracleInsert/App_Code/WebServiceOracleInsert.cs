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
public class WebServiceOracleInsert : System.Web.Services.WebService
{
    public WebServiceOracleInsert()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public OracleInsertBase SetOracleInsertSP(string FacultyName, string CourseID, string Course, string Schedule, 
                                              string Classroom, int Credit, int Enroll)
    {
       string cmdString = "InsertFacultyCourse";
       OracleConnection oraConnection = new OracleConnection();
       OracleInsertBase SetOracleResult = new OracleInsertBase();
       OracleCommand oraCommand = new OracleCommand();
       int intInsert = 0;

       SetOracleResult.OracleInsertOK = true;
       oraConnection = OracleConn();
       if (oraConnection == null)
       {
          SetOracleResult.OracleInsertError = "Database connection is failed";
          ReportError(SetOracleResult);
          return null;
       }
       oraCommand.Connection = oraConnection;
       oraCommand.CommandType = CommandType.StoredProcedure;
       oraCommand.CommandText = cmdString;
       oraCommand.Parameters.Add("FacultyName", OracleType.VarChar).Value = FacultyName;
       oraCommand.Parameters.Add("CourseID", OracleType.VarChar).Value = CourseID;
       oraCommand.Parameters.Add("Course", OracleType.VarChar).Value = Course;
       oraCommand.Parameters.Add("Schedule", OracleType.VarChar).Value = Schedule;
       oraCommand.Parameters.Add("Classroom", OracleType.VarChar).Value = Classroom;
       oraCommand.Parameters.Add("Credit", OracleType.Int32).Value = Credit;
       oraCommand.Parameters.Add("Enroll", OracleType.Int32).Value = Enroll;
       intInsert = oraCommand.ExecuteNonQuery();
       oraConnection.Close();
       oraCommand.Dispose();
       if (intInsert == 0)
       {
           SetOracleResult.OracleInsertError = "Data insertion is failed";
           ReportError(SetOracleResult);
       }
       return SetOracleResult;
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

    protected void ReportError(OracleInsertBase ErrSource)
    {
        ErrSource.OracleInsertOK = false;
        MessageBox.Show(ErrSource.OracleInsertError);
    }
    [WebMethod]
    public OracleInsertBase GetOracleInsert(string FacultyName)
    {
        string cmdString = "SELECT Course.course_id FROM Course, Faculty " +
                           "WHERE (Course.faculty_id = Faculty.faculty_id) AND (Faculty.faculty_name =: fname)";
        OracleConnection oraConnection = new OracleConnection();
        OracleInsertBase GetOracleResult = new OracleInsertBase();
        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraReader;

        GetOracleResult.OracleInsertOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
            GetOracleResult.OracleInsertError = "Database connection is failed";
            ReportError(GetOracleResult);
            return null;
        }
        oraCommand.Connection = oraConnection;
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("fname", OracleType.VarChar).Value = FacultyName;
        oraReader = oraCommand.ExecuteReader();
        if (oraReader.HasRows == true)
            FillCourseReader(ref GetOracleResult, oraReader);
        else
        {
            GetOracleResult.OracleInsertError = "No matched course found";
            ReportError(GetOracleResult);
        }
        oraReader.Close();
        oraConnection.Close();
        oraCommand.Dispose();
        return GetOracleResult;
    }
    protected void FillCourseReader(ref OracleInsertBase sResult, OracleDataReader sReader)
    {
        int pos = 0;

        while (sReader.Read())
        {
            sResult.CourseID[pos] = Convert.ToString(sReader.GetOracleString(0));       //the 1st column is course_id
            pos++;
        }
    }
    [WebMethod]
    public OracleInsertBase GetOracleInsertCourse(string CourseID)
    {
        string cmdString = "WebSelectCourseSP.SelectCourse";
        OracleConnection oraConnection = new OracleConnection();
        OracleInsertBase GetOracleResult = new OracleInsertBase();
        OracleDataReader oraReader;
        OracleParameter paramCourseID = new OracleParameter();
        OracleParameter paramCourseInfo = new OracleParameter();

        GetOracleResult.OracleInsertOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
            GetOracleResult.OracleInsertError = "Database connection is failed";
            ReportError(GetOracleResult);
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
            FillCourseDetail(ref GetOracleResult, oraReader);
        else
        {
            GetOracleResult.OracleInsertError = "No matched course found";
            ReportError(GetOracleResult);
        }
        oraReader.Close();
        oraConnection.Close();
        oraCommand.Dispose();
        return GetOracleResult;
    }
    protected void FillCourseDetail(ref OracleInsertBase sResult, OracleDataReader sReader)
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
    public DataSet OracleInsertDataSet(string FacultyName, string CourseID, string Course, string Schedule, 
                                       string Classroom, int Credit, int Enroll)
    {
        string cmdString = "INSERT INTO Course VALUES  (:course_id, :course, :credit, :classroom, " + 
                                                       ":schedule, :enrollment, :faculty_id)";
        OracleConnection oraConnection = new OracleConnection();
        OracleInsertBase SetOracleResult = new OracleInsertBase();
        OracleCommand oraCommand = new OracleCommand();
        OracleDataAdapter CourseAdapter = new OracleDataAdapter();
        DataSet dsCourse = new DataSet();
        int intResult = 0;
        string FacultyID;

        SetOracleResult.OracleInsertOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
          SetOracleResult.OracleInsertError = "Database connection is failed";
          ReportError(SetOracleResult);
          return null;
        }
        oraCommand.Connection = oraConnection;
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = "SELECT faculty_id FROM Faculty WHERE faculty_name =: Name";
        oraCommand.Parameters.Add("Name", OracleType.VarChar).Value = FacultyName;
        FacultyID = (string)oraCommand.ExecuteScalar();
        oraCommand.Parameters.Clear();
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("faculty_id", OracleType.VarChar).Value = FacultyID;
        oraCommand.Parameters.Add("course_id", OracleType.Char).Value = CourseID;
        oraCommand.Parameters.Add("course", OracleType.VarChar).Value = Course;
        oraCommand.Parameters.Add("schedule", OracleType.Char).Value = Schedule;
        oraCommand.Parameters.Add("classroom", OracleType.VarChar).Value = Classroom;
        oraCommand.Parameters.Add("credit", OracleType.Int32).Value = Credit;
        oraCommand.Parameters.Add("enrollment", OracleType.Int32).Value = Enroll;

        CourseAdapter.InsertCommand = oraCommand;
        intResult = CourseAdapter.InsertCommand.ExecuteNonQuery();
        if (intResult == 0)
        {
            SetOracleResult.OracleInsertError = "No matched course found";
            ReportError(SetOracleResult);
        }
        oraCommand.Parameters.Clear();
        oraCommand.CommandText = "SELECT * FROM Course WHERE faculty_id =: FacultyID";
        oraCommand.Parameters.Add("FacultyID", OracleType.VarChar).Value = FacultyID;
        CourseAdapter.SelectCommand = oraCommand;
        CourseAdapter.Fill(dsCourse, "Course");
        CourseAdapter.Dispose();
        oraConnection.Close();
        oraCommand.Dispose();
        return dsCourse;
    }
}
