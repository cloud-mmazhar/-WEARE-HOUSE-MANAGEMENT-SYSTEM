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
/// Summary description for clsPayments
/// </summary>
public class clsPayments
{

	public clsPayments()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public static int PayTransactionId { get; set; }
    public static DateTime  PayTranDate { get; set; }
    public static string PayTypeReason { get; set; }
    public static int EmpId { get; set; }
    public static decimal Amount { get; set; }
    public static DateTime DueDate { get; set; }
    public static string PayType { get; set; }
    public static int StorageTransactionId { get; set; }

    public static int InsertPaymentsMaster()
    {
        try 
        {
            string strCmdText = "insert into tbl_warehousepaymentmaster(PayTransactionDate,PayTypereason,paygeneratedEmpId,PayAmount,PayDueDate,PayType,StorageTransactionId) values('" + PayTranDate + "','" + PayTypeReason + "','" + EmpId + "','" + Amount + "','" + DueDate + "','" + PayType + "','" + StorageTransactionId + "')";
            return SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, strCmdText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);       
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>

     // members for payment details...........

    public static DateTime ActualPayDate { get; set; }
    public static decimal AmountPaid { get; set; }
    public static decimal AmountDue { get; set; }
    public static DateTime NextDueDate { get; set; }
    public static string Chq_DD_No { get; set; }
    public static string Chq_DD_Date { get; set; }
    public static decimal Chq_DD_Amt { get; set; }
    public static string Chq_DD_Bank { get; set; }
    public static string PayStatus { get; set; }


    public static int InsertPaymentDetails()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@PayTransactionId", PayTransactionId);
            p[1] = new SqlParameter("@ActualPayDate", ActualPayDate);
            p[2] = new SqlParameter("@Amountpaid", AmountPaid);
            p[3] = new SqlParameter("@AmountDue", AmountDue);
            p[4] = new SqlParameter("@NextDueDate", NextDueDate);
            p[5] = new SqlParameter("@Chq_DD_No", Chq_DD_No);
            p[6] = new SqlParameter("@Chq_DD_Date", Chq_DD_Date);
            p[7] = new SqlParameter("@Chq_DD_Amt", Chq_DD_Amt);
            p[8] = new SqlParameter("@Chq_DD_Bank", Chq_DD_Bank);
            p[9] = new SqlParameter("@PayStatus", PayStatus);
            p[10] = new SqlParameter("@EmpId", EmpId);

            return SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_InsertPaymentDetails", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetPayTrasactionID()
    {
        try
        {
            string strCmdText = "select * from tbl_WarehousePaymentMaster";
            return SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strCmdText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static DataSet GetDataForReport()
    {
        try
        {
            string strCmdText = "sp_ReportDischargeDetails";
            return SqlHelper.ExecuteDataset(Connection.con , CommandType.StoredProcedure, strCmdText);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
