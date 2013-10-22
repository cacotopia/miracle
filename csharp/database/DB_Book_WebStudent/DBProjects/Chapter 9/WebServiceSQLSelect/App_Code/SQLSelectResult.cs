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
/// Summary description for SQLSelectResult
/// </summary>
public class SQLSelectResult:SQLSelectBase
{
    public string FacultyID;
    public string FacultyOffice;
    public string FacultyPhone;
    public string FacultyCollege;
    public string FacultyTitle;
    public string FacultyEmail;

	public SQLSelectResult()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
