using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for SQLSelectBase
/// </summary>
public class OracleInsertBase
{
    public bool OracleInsertOK;
    public string OracleInsertError;

    public string FacultyID;
    public string[] CourseID = new string[10];
    public string Course;
    public string Schedule;
    public string Classroom;
    public int Credit;
    public int Enrollment;

    public OracleInsertBase()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
