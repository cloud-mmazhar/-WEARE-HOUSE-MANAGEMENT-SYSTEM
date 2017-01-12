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
using WarwhouseManagement;

/// <summary>
/// Summary description for Connection
/// </summary>
/// 

public class Connection
{
    public Connection()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string con = ConfigurationManager.ConnectionStrings["WareHouseManagementConnectionString"].ConnectionString;

}
