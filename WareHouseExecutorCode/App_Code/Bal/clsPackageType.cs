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
/// Summary description for clsPackageType
/// </summary>
/// 

//interface IPackageType
//{
//    int InsertPackageTypeMasterData();
//    int UpdatePackageTypeMasterData();
//    DataSet GetAllPackageTypeMasterData();
//    DataSet GetPackageTypeMasterDataByPackageTypeId(int PackageTypeId);
//}

public class clsPackageType 
{

	public clsPackageType()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int PackageTypeId { get; set; }
    
    public string strPackageTypeName { get; set; }
    
    public string strPackageTypeAbbr { get; set; }
   
    public string strDesc { get; set; }

    public int InsertPackageTypeMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@PackageTypeName", strPackageTypeName);
            p[1] = new SqlParameter("@PackageTypeAbbr", strPackageTypeAbbr);
            p[2] = new SqlParameter("@PackageTypeDesc", strDesc);
            p[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[3].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertPackageTypeMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int UpdatePackageTypeMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@PackageTypeName", strPackageTypeName);
            p[1] = new SqlParameter("@PackageTypeAbbr", strPackageTypeAbbr);
            p[2] = new SqlParameter("@PackageTypeDesc", strDesc);

            p[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@PackageTypeId", PackageTypeId);
            int i = SqlHelper.ExecuteNonQuery(Connection.con , CommandType.StoredProcedure, "sp_UpdatePackageTypeMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetAllPackageTypeMasterData()
    {
        try
        {
            string strText = "select * from tbl_PackageTypeMaster";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetPackageTypeMasterDataByPackageTypeId(int PackageTypeId)
    {
        try
        {
            string strText = "select * from tbl_PackageTypeMaster where PackageTypeid=" + PackageTypeId;
            return SqlHelper.ExecuteDataset(Connection.con , CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetPackageIdforBrandPackageUnitMasterPricesByBrandId(int BrandId)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@BrandId", BrandId);
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, "sp_GetPackageIdforBrandPackageUnitMasterPricesByBrandId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetUnitIdforBrandPackageUnitMasterPricesByPackageId(int BrandId,int PackageId)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@BrandId", BrandId);
            p[1] = new SqlParameter("@PackageId", PackageId);
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, "sp_GetUnitIdforBrandPackageUnitMasterPricesByPIdBId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}

