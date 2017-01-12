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
/// Summary description for clsProducts
/// </summary>
/// 
//interface IProducts
//{
//    int InsertProductMasterData();
//    int UpdateProductMasterData();
//    DataSet GetAllProductsData();
//    DataSet GetProductDataByProId(int ProductId);
//}

public class clsProducts:AllInterfaces 
{
	public clsProducts()
	{
		//
		// TODO: Add constructor logic here
		//
	
    }

    public int ProductId { get; set; }
    public string  strProName { get; set; }
    public string  strProAbbr  { get; set; }
    public string strDesc { get; set; }
    public string strFileName { get; set; }
    public byte[]   imgFileData { get; set; }

    public  int InsertProductMasterData()
    {       
        try
        {
           
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@ProName", strProName);
            p[1] = new SqlParameter("@ProAbbr", strProAbbr);
            p[2] = new SqlParameter("@ProDesc", strDesc);
            p[3] = new SqlParameter("@FileName", strFileName);
            p[4] = new SqlParameter("@FileData", imgFileData);
            p[5] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[5].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertProductMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int UpdateProductMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@ProName", strProName);
            p[1] = new SqlParameter("@ProAbbr", strProAbbr);
            p[2] = new SqlParameter("@ProDesc", strDesc);
            p[3] = new SqlParameter("@FileName", strFileName);
            p[4] = new SqlParameter("@FileData", imgFileData);
            
            p[5] = new SqlParameter("@ProId", ProductId);
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_UpdateProductMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetAllProductsData()
    {
        try
        {
            string strText = "select * from tbl_ProductMaster";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetProductDataByProId(int ProductId)
    {
        try
        {
            string strText = "select * from tbl_ProductMaster where productid=" + ProductId;
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    /// <summary>
    /// //Product storage master members starts From here................
    /// </summary>
 
    public static int intWarehouseId { get; set; }
    public static int intCompanyId { get; set; }
    public static int intEmpId { get; set; }
    public static string  strPersonName { get; set; }
    public static string strVehicleNo { get; set; }
    public static DateTime strDate { get; set; }

    public static int InsertProductStorageMasterData(out int TransactionId)
    {
        int i;
        try
        {
            string strCmdText1 = "insert into tbl_ProductStorageMaster values('" + strDate + "'," + intWarehouseId + "," + intCompanyId + "," + intEmpId + ",'" + strPersonName + "','" + strVehicleNo + "')";
            i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, strCmdText1);
            int j = 0;
            if (i == 1)
            {
                string strCmdText2 = "select ident_current('tbl_ProductStorageMaster')";
                j = Convert.ToInt32(SqlHelper.ExecuteScalar(Connection.con, CommandType.Text, strCmdText2));
            }
            TransactionId = j;
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static int InsertProductDischargeMasterData()
    {
        try
        {
            string strCmdText1 = "insert into tbl_ProductDischargedMaster values('" + strDate + "'," + intWarehouseId + "," + intCompanyId + ",'" + strPersonName + "'," + intEmpId + ",'" + strVehicleNo + "')";
            return SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, strCmdText1);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetProductStorageMasterData()
    {
        try
        {
            string strText = "select * from tbl_ProductStorageMaster";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetProductStorageMasterDataByTranId(int TranId)
    {
        try
        {
          string strText = "select * from tbl_ProductMaster where productid=" + ProductId;
           return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetProductStorageTransactionId()
    {
        try 
        {
            string strText = "select * from tbl_ProductStorageMaster";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }


    public static DataSet GetProductDischargeMasterTransactionId()
    {
        try
        {
            string strText = "select * from tbl_ProductDischargedMaster";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetComBrandForStorageMasterDetaisByTranId(int Id)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@TransactionId", Id);
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, "sp_GetComBrandForStorageMasterDetaisByTranId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    
    /// <summary>
    /// //  Product storage master details members starts From here................
    /// </summary>
    /// 

    public static int intStorageTransId { get; set; }
    public static int intDischargeTransactionId { get; set; }
    public static int intCompanyBrandId { get; set; }
    public static int intPackageId { get; set; }
    public static int intUnit { get; set; }
    public static int intQtyRiseForStorage { get; set; }
    public static int intExpectDays { get; set; }
    public static decimal decAmtForStorage { get; set; }
    public static string strInstrForStorage { get; set; }
    public static int intStockAvail { get; set; }
    public static int intQtyRiseForDischarge { get; set; }
    public static int intStockLeft { get; set; }

    public static int InsertProductStorageMasterDetailsData()
    {
        try
        {
            string strCmdText1 = "insert into tbl_ProductStorageDetails values(" + intStorageTransId + "," + intCompanyBrandId + "," + intPackageId + "," + intUnit + "," + intQtyRiseForStorage + "," + intExpectDays + "," + decAmtForStorage + ",'" + strInstrForStorage + "'," + intStockAvail + ")";
            return SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, strCmdText1);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetComBrandForDischargeMasterDetaisByTranId(int Id)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@TransactionId", Id);
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.StoredProcedure, "sp_GetComBrandForDischargeMasterDetailsByTranId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static int InsertProductDischargeMasterDetailsData()
    {
        try
        {
            //SqlTransaction s = new SqlTransaction();
            string strCmdText1 = "insert into tbl_ProductDischargeMasterDetails values(" + intDischargeTransactionId + "," + intCompanyBrandId + "," + intPackageId + "," + intUnit + "," + intQtyRiseForDischarge + "," + intStockLeft + ")";
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, strCmdText1);
            if (i == 1)
            {
                string strCmdText2 = "update tbl_ProductStorageDetails set QuantityRaisedforstorage=" + intStockLeft + " where CompanyBrandId=" + intCompanyBrandId + " and PackageId=" + intPackageId + " and UnitId=" + intUnit + "";
                int j=SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, strCmdText2);
                //if (i == 1 && j == 1)
                //    s.Commit();
                //else
                //    s.Rollback();
            }
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static int GetAvailableStockByBID_PID_UID(int CompanyBrandId, int PackageId, int UnitId)
    {
        try
        {
            string strCmdText1 = "select QuantityRaisedForStorage from tbl_ProductStorageDetails where CompanyBrandId=" + CompanyBrandId + " and PackageId="+PackageId+" and UnitId="+UnitId+" ";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(Connection.con, CommandType.Text, strCmdText1));
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetProductDataByProductId(int intProdId)
    {
        try
        {
            string strCmdText1 = "select * from tbl_ProductMaster where ProductId=" + intProdId;
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strCmdText1);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
