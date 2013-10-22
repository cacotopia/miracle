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
public class WebServiceOracleSelect : System.Web.Services.WebService
{
    public WebServiceOracleSelect()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public OracleSelectResult GetOracleSelect(string FacultyName)
    {
        OracleConnection oraConnection = new OracleConnection();
        OracleSelectResult OracleResult = new OracleSelectResult();
        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraReader;
        string cmdString = "SELECT faculty_id, office, phone, college, title, email FROM Faculty " + 
                           "WHERE faculty_name =: facultyName";
        OracleResult.OracleRequestOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
           OracleResult.OracleRequestError = "Database connection is failed";
           ReportError(OracleResult);
           return null;
        }
        oraCommand.Connection = oraConnection;
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("facultyName", OracleType.VarChar).Value = FacultyName;
        oraReader = oraCommand.ExecuteReader();

        if (oraReader.HasRows == true)
            FillFacultyReader(ref OracleResult, oraReader);
        else
        {
            OracleResult.OracleRequestError = "No matched faculty found";
            ReportError(OracleResult);
        }
        oraReader.Close();
        oraConnection.Close();
        oraCommand.Dispose();
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
    protected void FillFacultyReader(ref OracleSelectResult sResult, OracleDataReader sReader)
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
    protected void ReportError(OracleSelectResult ErrSource)
    {
        ErrSource.OracleRequestOK = false;
        MessageBox.Show(ErrSource.OracleRequestError);
    }
    [WebMethod]
    public OracleSelectResult GetOracleSelectSP(string FacultyName)
    {
        OracleConnection oraConnection = new OracleConnection();
        OracleSelectResult OracleResult = new OracleSelectResult();
        OracleCommand oraCommand = new OracleCommand();
        OracleDataReader oraReader;
        OracleParameter paramFacultyName = new OracleParameter();
        OracleParameter paramFacultyInfo = new OracleParameter();

        string cmdString = "WebSelectFaculty.SelectFaculty";
        OracleResult.OracleRequestOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
            OracleResult.OracleRequestError = "Database connection is failed";
            ReportError(OracleResult);
            return null;
        }
        paramFacultyName.ParameterName = "FacultyName";
        paramFacultyName.OracleType = OracleType.VarChar;
        paramFacultyName.Value = FacultyName;
        paramFacultyInfo.ParameterName = "FacultyInfo";
        paramFacultyInfo.OracleType = OracleType.Cursor;
        paramFacultyInfo.Direction = ParameterDirection.Output;        //this is very important

        oraCommand.Connection = oraConnection;
        oraCommand.CommandType = CommandType.StoredProcedure;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add(paramFacultyName);
        oraCommand.Parameters.Add(paramFacultyInfo);

        oraReader = oraCommand.ExecuteReader();

        if (oraReader.HasRows == true)
            FillFacultyReader(ref OracleResult, oraReader);
        else
        {
            OracleResult.OracleRequestError = "No matched faculty found";
            ReportError(OracleResult);
        }
        oraReader.Close();
        oraConnection.Close();
        oraCommand.Dispose();
        return OracleResult;
    }
    [WebMethod]
    public DataSet GetOracleSelectDataSet(string FacultyName)
    {
        OracleConnection oraConnection = new OracleConnection();
        OracleSelectResult OracleResult = new OracleSelectResult();
        OracleCommand oraCommand = new OracleCommand();
        OracleDataAdapter FacultyAdapter = new OracleDataAdapter();
        DataSet dsFaculty = new DataSet();
        int intResult = 0;

        string cmdString = "SELECT faculty_id, office, phone, college, title, email FROM Faculty " +
                           "WHERE faculty_name =: facultyName";
        OracleResult.OracleRequestOK = true;
        oraConnection = OracleConn();
        if (oraConnection == null)
        {
            OracleResult.OracleRequestError = "Database connection is failed";
            ReportError(OracleResult);
            return null;
        }
        oraCommand.Connection = oraConnection;
        oraCommand.CommandType = CommandType.Text;
        oraCommand.CommandText = cmdString;
        oraCommand.Parameters.Add("facultyName", OracleType.VarChar).Value = FacultyName;
        FacultyAdapter.SelectCommand = oraCommand;
        intResult = FacultyAdapter.Fill(dsFaculty, "Faculty");

        if (intResult == 0)
        {
            OracleResult.OracleRequestError = "No matched faculty found";
            ReportError(OracleResult);
        }
        oraConnection.Close();
        oraCommand.Dispose();
        FacultyAdapter.Dispose();
        return dsFaculty;
    }
}
