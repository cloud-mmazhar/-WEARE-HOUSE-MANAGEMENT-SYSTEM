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
/// Summary description for clsUnits
/// </summary>
/// 

interface IUnits
{
    int InsertUnitMasterData();
    int UpdateUnitMasterData();
    DataSet GetAllUnitsData();
    DataSet GetUnitsDataByUnitId(int UnitId);
}
public class clsUnits:Connection ,IUnits 
{
	public clsUnits()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int UnitId { get; set; }
    public string strUnitName { get; set; }
    public string strUnitAbbr { get; set; }
    public string strDesc { get; set; }

    public int InsertUnitMasterData()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@UnitName", strUnitName);
            p[1] = new SqlParameter("@UnitAbbr", strUnitAbbr);
            p[2] = new SqlParameter("@UnitDesc", strDesc);

            p[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[3].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertUnitMasterData", p);

            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public int UpdateUnitMasterData()
    {
        try
        {

            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@UnitName", strUnitName);
            p[1] = new SqlParameter("@UnitAbbr", strUnitAbbr);
            p[2] = new SqlParameter("@UnitDesc", strDesc);

            p[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 50);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@UnitId", UnitId);
            int i = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UpdateUnitMasterData", p);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetAllUnitsData()
    {
        try
        {
            string strText = "select * from tbl_UnitMaster";
            return SqlHelper.ExecuteDataset(con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetUnitsDataByUnitId(int UnitId)
    {
        try
        {
            string strText = "select * from tbl_UnitMaster where UnitId=" + UnitId;
            return SqlHelper.ExecuteDataset(con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
