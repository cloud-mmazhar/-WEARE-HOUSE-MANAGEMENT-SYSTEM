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
/// Summary description for clsSecurity
/// </summary>
public class clsSecurity
{
	public clsSecurity()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static int GatepassId { get; set; }
    public static DateTime GatepassDT { get; set; }
    public static int DischargeTransactionId { get; set; }
    public static int EmpId { get; set; }
    public static string Instructionforsecurity { get; set; }
    public static int SecurityId { get; set; }
    public static DateTime  CheckInDateTime { get; set; }
    public static DateTime CheckOutDateTime { get; set; }
    public static string DriverName { get; set; }
    public static string DriverLicenseNo { get; set; }
    public static int NoOfPeople { get; set; }
    public static string VehicleNo { get; set; }
    public static string VehicleRcNo { get; set; }

    public static int InsertWarehouseGatepassData(out int TransactionId)
    {
        try 
        {
            string steCmdText1 = "insert into tbl_WarehouseDischargeGatepass (gatepassdate,EmpId,InstructionForSecurity) values('" + GatepassDT + "'," + EmpId + ",'" + Instructionforsecurity + "')";
            int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, steCmdText1);
            int j = 0;
            if (i == 1)
            {
                string strCmdText2 = "select ident_current('tbl_WarehouseDischargeGatepass')";
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

    public static int InsertSecurityMaster()
    {
        try
        {
            string strText = "insert into tbl_SecurityMaster(VehicleCheckIN,DriverName,DriverLicenseNo,NoOfPeople,VehicleNo,VehicleRcNo,Gatepassid,EmpId) values ('" + CheckInDateTime + "','" + DriverName + "','" + DriverLicenseNo + "','" + NoOfPeople + "','" + VehicleNo + "','" + VehicleRcNo + "','" + GatepassId + "','" + EmpId + "')";
            return SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetWarehouseGatepassData()
    {
        try
        {
            string strText = "select * from tbl_warehouseDischargeGatepass where DischargeTransactionId=0";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
