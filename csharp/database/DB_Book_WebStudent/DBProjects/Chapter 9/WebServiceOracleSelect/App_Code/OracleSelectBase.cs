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
public class OracleSelectBase
{
    public bool OracleRequestOK;
    public string OracleRequestError;

    public OracleSelectBase()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
