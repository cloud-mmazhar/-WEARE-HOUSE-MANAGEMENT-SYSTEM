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
using System.Data.SqlClient;
using WarwhouseManagement;

/// <summary>
/// Summary description for clsEmployee
/// </summary>
/// 


public class clsEmployee
{

	public clsEmployee()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataSet GetAllEmployeeIds()
    {
        try
        {
            string strText = "sp_GetEmployeeIds";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

}
