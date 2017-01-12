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
/// Summary description for clsWarehouseMaster
/// </summary>
public class clsWarehouseMaster
{
	public clsWarehouseMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static int intWareHouseId { get; set; }
    public static int intWareHouseInchargeIdId { get; set; }
    public static string strWareHouseName { get; set; }
    public static string strWareHouseAddress { get; set; }
    public static string strWareHouseMailId { get; set; }
    public static string strWareHousePhoneNo { get; set; }
    public static string strWareHouseFaxNo { get; set; }
    public static string strWareHouseDesc { get; set; }


    public static int InsertWareHouseMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@WareHouseName", strWareHouseName);
            p[1] = new SqlParameter("@WareHouseAddress", strWareHouseAddress);
            p[2] = new SqlParameter("@WareHouseMailId", strWareHouseMailId);
            p[3] = new SqlParameter("@WareHousePhoneNo", strWareHousePhoneNo);
            p[4] = new SqlParameter("@WareHouseFaxNo", strWareHouseFaxNo);
            p[5] = new SqlParameter("@WareHouseDesc", strWareHouseDesc);
            p[6] = new SqlParameter("@WareHouseInchargeID", intWareHouseInchargeIdId);
            p[7] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[7].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertWareHouseMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static int UpdateWareHouseMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@WareHouseName", strWareHouseName);
            p[1] = new SqlParameter("@WareHouseAddress", strWareHouseAddress);
            p[2] = new SqlParameter("@WareHouseMailId", strWareHouseMailId);
            p[3] = new SqlParameter("@WareHousePhoneNo", strWareHousePhoneNo);
            p[4] = new SqlParameter("@WareHouseFaxNo", strWareHouseFaxNo);
            p[5] = new SqlParameter("@WareHouseDesc", strWareHouseDesc);
            p[6] = new SqlParameter("@WareHouseInchargeID", intWareHouseInchargeIdId);
            p[7] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[7].Direction = ParameterDirection.Output;
            p[8] = new SqlParameter("@WareHouseId", intWareHouseId);
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_UpdateWareHouseMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetAllWarehouseMasterData()
    {
        try
        {
            string strText = "select * from tbl_WarehouseMaster";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public static DataSet GetWarehouseMasterDataByWarehouseId(int intWareHouseId)
    {
        try
        {
            string strText = "select * from tbl_WarehouseMaster where WarehouseId=" + intWareHouseId;
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }


    //Warehouse company brands master data class details starts from here ..

    public static int intCompanyBrandId { get; set; }
    public static DateTime BrandStorageAccptedDate { get; set; }
    public static DateTime BrandStorageEndDate { get; set; }
    public static string BrandStorageStatus { get; set; }

    public static int BrandStorageCapacityReq { get; set; }
    public static decimal RegistrationAmtPaid { get; set; }

    public static int InsertWareHouseCompanyBrandsMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[9];

            p[0] = new SqlParameter("@WareHouseId", intWareHouseId);
            p[1] = new SqlParameter("@CompanyBrandId", intCompanyBrandId);
            p[2] = new SqlParameter("@BrandStorageAccptedDate", BrandStorageAccptedDate);
            p[3] = new SqlParameter("@BrandStorageEndDate", BrandStorageEndDate);
            p[4] = new SqlParameter("@BrandStorageStatus", BrandStorageStatus);
            p[5] = new SqlParameter("@BrandStorageCapacityReq", BrandStorageCapacityReq);
            p[6] = new SqlParameter("@RegistrationAmtPaid", RegistrationAmtPaid);
            p[7] = new SqlParameter("@WareHouseInchargeID", intWareHouseInchargeIdId);
            p[8] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[8].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertWarehouseCompanyBrandsMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetCompanyBrandsForWHCBM(int WarehouseId)
    {
        try 
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@WareHouseId", WarehouseId);
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, "sp_GetCompanyBrandsForWHCBM",p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static int intStorageInstantId { get; set; }
    public static int intStorageInstantTypeCapacity { get; set; }

    public static int InsertWareHouseStorageMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("@WareHouseId", intWareHouseId);
            p[1] = new SqlParameter("@StorageInstrId", intStorageInstantId);
            p[2] = new SqlParameter("@StorageInstantTypeCapacity", intStorageInstantTypeCapacity);
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertWarehouseStorageMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetStorageInstantIdforWHSIMD(int WHId)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@WareHouseId", WHId);
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, "sp_GetStorageInstantIdsForWHSM", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
