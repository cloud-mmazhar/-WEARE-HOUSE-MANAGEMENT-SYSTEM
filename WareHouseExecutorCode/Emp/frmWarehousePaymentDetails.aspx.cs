using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Emp_frmWarehousePaymentDetails : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPayTrasactionId();
        }
    }

    private void BindPayTrasactionId()
    {
        try
        {
            DataSet ds = clsPayments.GetPayTrasactionID();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlPayTID.DataSource = ds.Tables[0];
                ddlPayTID.DataTextField = "PayTransactionId";
                ddlPayTID.DataValueField = "PayTransactionId";
                ddlPayTID.DataBind();
            }
            ddlPayTID.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try 
        {
            clsPayments.PayTransactionId = Convert.ToInt32(ddlPayTID.SelectedValue);
            clsPayments.ActualPayDate = Convert.ToDateTime(txtActualPayDate.Text);
            clsPayments.AmountPaid = Convert.ToDecimal(txtAmtPaid.Text);
            clsPayments.AmountDue = Convert.ToDecimal(txtDueAmt.Text);
            clsPayments.NextDueDate = Convert.ToDateTime(txtNextDueDate.Text);
            clsPayments.Chq_DD_No = txtChkDDNo.Text;
            clsPayments.Chq_DD_Date = txtChkDDDate.Text;
            clsPayments.Chq_DD_Amt = Convert.ToDecimal(txtChkqDDAmt.Text);
            clsPayments.Chq_DD_Bank = txtBankName.Text;
            clsPayments.PayStatus = txtPayStatus.Text;
            clsPayments.EmpId = Convert.ToInt32(Session["EmpId"]);
            int j = clsPayments.InsertPaymentDetails();
            if (j == 1)
            {
                ClearData();
                lblMsg.Text = "Data added to the table";
            }
            else
                lblMsg.Text = "Data not added to the table. Try again.";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void ClearData()
    {
        try
        {
            lblMsg.Text = "";
            txtActualPayDate.Text = "";
            txtAmtPaid.Text = "";
            txtBankName.Text = "";
            txtChkDDDate.Text = "";
            txtChkDDNo.Text = "";
            txtChkqDDAmt.Text = "";
            txtDueAmt.Text = "";
            txtNextDueDate.Text = "";
            txtPayStatus.Text = "";
            if (ddlPayTID.Items.Count != 0)
                ddlPayTID.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}
