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
using System.Data.SqlClient;
/// <summary>
/// Summary description for clsCompany
/// </summary>
/// 
//interface ICompany
//{
//    int InsertCompanyMasterData();
//    int UpdateCompanyMasterData();
//    DataSet GetAllCompanyData();
//    DataSet GetCompanyDataByCompanyId(int CompanyId);
//}
public class clsCompany:AllInterfaces 
{
	public clsCompany()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int CompanyId { get; set; }
    public string strCompanyName { get; set; }
    public string strCompanyAbbr { get; set; }
    public string strDesc { get; set; }

    public int InsertCompanyMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@CompanyName", strCompanyName );
            p[1] = new SqlParameter("@CompanyAbbr", strCompanyAbbr );
            p[2] = new SqlParameter("@CompanyDesc", strDesc);
           
            p[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[3].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(Connection.con , CommandType.StoredProcedure, "sp_InsertCompanyMasterData", p);
            
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int UpdateCompanyMasterData()
    {
        try
        {

            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@CompanyName", strCompanyName );
            p[1] = new SqlParameter("@CompanyAbbr", strCompanyAbbr );
            p[2] = new SqlParameter("@CompanyDesc", strDesc);
            
            p[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@CompanyId", CompanyId);
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_UpdateCompanyMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetAllCompanyData()
    {
        try
        {
            string strText = "select * from tbl_CompanyMaster";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetCompanyDataByCompanyId(int ComanyId)
    {
        try
        {
            string strText = "select * from tbl_CompanyMaster where Companyid=" + ComanyId;
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
