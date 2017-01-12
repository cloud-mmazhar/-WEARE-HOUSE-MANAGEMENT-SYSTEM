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
/// Summary description for clsBrands
/// </summary>
/// 
interface IBrands
{
    int InsertCompanyBrandMasterData();
    int UpdateCompanyBrandMasterData();
    DataSet GetAllCompanyBrandMasterData();
    DataSet GetCompanyBrandMasterDataByCBId(int CBId);
}
public class clsBrands
{
	public clsBrands()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int intCompanyBrandId { get; set; }
    public string strCompanyBrandName { get; set; }
    public string strCompanyBrandAbbr { get; set; }
    public string strDesc { get; set; }
    public int intProductId { get; set; }
    public int intStorageInstId { get; set; }
    public int intCompanyId { get; set; }

    public int InsertCompanyBrandMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@CompanyBrandName", strCompanyBrandName);
            p[1] = new SqlParameter("@CompanyBrandAbbr", strCompanyBrandAbbr);
            p[2] = new SqlParameter("@CompanyBrandDesc", strDesc);
            p[3] = new SqlParameter("@ProductId", intProductId);
            p[4] = new SqlParameter("@StorageInstId", intStorageInstId);
            p[5] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@CompanyId", intCompanyId);
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertCompanyBrandMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public int UpdateCompanyBrandMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@CompanyBrandName", strCompanyBrandName);
            p[1] = new SqlParameter("@CompanyBrandAbbr", strCompanyBrandAbbr);
            p[2] = new SqlParameter("@CompanyBrandDesc", strDesc);
            p[3] = new SqlParameter("@ProductId", intProductId);
            p[4] = new SqlParameter("@StorageInstId", intStorageInstId);
            p[5] = new SqlParameter("@CompanyBrandId", intCompanyBrandId);
            p[6] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[6].Direction = ParameterDirection.Output;

            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_UpdateCompanyBrandMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetAllCompanyBrandData()
    {
        try
        {
            string strText = "sp_GetCompanyBrandMasterData";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetCompanyBrandDataByCBId(int CBId)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CompanyBrandId", CBId);
            string strText = "sp_GetCompanyBrandMasterDataByCBID";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, strText, p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static int intPacakageId { get; set; }
    public static int intUnitId { get; set; }
    public static int UnitQty { get; set; }
    public static decimal PriceofItemStorage { get; set; }
    public static decimal RegAmt { get; set; }
    public static decimal DisofUnitChargeRate { get; set; }
    public static int intStorageInstantId { get; set; }
    public static int intBrandId { get; set; }
   

    public static int InsertBrandPackageUnitMasterPrices()
    {
        try 
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@BrandId", intBrandId);
            p[1] = new SqlParameter("@PackageId", intPacakageId);
            p[2] = new SqlParameter("@UnitId", intUnitId);
            p[3] = new SqlParameter("@UnitQty", UnitQty);
            p[4] = new SqlParameter("@PriceofItemStorage", PriceofItemStorage);
            p[5] = new SqlParameter("@RegAmt", RegAmt);
            p[6] = new SqlParameter("@DisofUnitChargeRate", DisofUnitChargeRate);
            p[7] = new SqlParameter("@intStorageInstId", intStorageInstantId);
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertBrandPackageUnitMasterPrices", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
