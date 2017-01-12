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
/// Summary description for clsStorageInst
/// </summary>
/// 

interface IStorageInst
{
    int InsertStorageInstMasterData();
    int UpdateStorageInstMasterData();
    DataSet GetAllStorageInstsData();
    DataSet GetStorageInstsDataByStorageInstId(int StorageInstId);
}
public class clsStorageInst:Connection ,IStorageInst
{
	public clsStorageInst()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int StorageInstId { get; set; }
    public string strStorageInstName { get; set; }
    public string strDesc { get; set; }

    public int InsertStorageInstMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@StorageInstName", strStorageInstName);

            p[1] = new SqlParameter("@StorageInstDesc", strDesc);

            p[2] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[2].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertStorageInstMasterData", p);

            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int UpdateStorageInstMasterData()
    {
        try
        {

            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@StorageInstName", strStorageInstName);

            p[1] = new SqlParameter("@StorageInstDesc", strDesc);

            p[2] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[2].Direction = ParameterDirection.Output;
            p[3] = new SqlParameter("@StorageInstId", StorageInstId);
            int i = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UpdateStorageInstMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetAllStorageInstsData()
    {
        try
        {
            string strText = "select * from tbl_StorageInstMaster";
            return SqlHelper.ExecuteDataset(con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetStorageInstsDataByStorageInstId(int StorageInstId)
    {
        try
        {
            string strText = "select * from tbl_StorageInstMaster where StorageInstId=" + StorageInstId;
            return SqlHelper.ExecuteDataset(con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

}
