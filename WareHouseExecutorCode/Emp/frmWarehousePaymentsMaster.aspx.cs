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

public partial class Emp_frmWarehousePaymentsMaster : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }

    private void BindData()
    {
        clsProducts objProd = new clsProducts();
        DataSet ds = objProd.GetProductStorageMasterData();
        if (ds.Tables[0].Rows.Count != 0)
        {
            ddlTransactionId.DataSource = ds.Tables[0];
            ddlTransactionId.DataTextField = "StorageTransactionId";
            ddlTransactionId.DataValueField = "StorageTransactionId";
            ddlTransactionId.DataBind();
        }
        ddlTransactionId.Items.Insert(0, "--Select One--");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            clsPayments.PayTranDate = System.DateTime.Now.Date;
            clsPayments.PayTypeReason = ddlPaymentType.SelectedItem.Text;
            clsPayments.EmpId = Convert.ToInt32(Session["EmpId"]);
            clsPayments.Amount = Convert.ToDecimal(txtPayAmt.Text);
            clsPayments.DueDate = Convert.ToDateTime(txtDueDate.Text);
            clsPayments.PayType = ddlPaymentType.SelectedItem.Text;
            clsPayments.StorageTransactionId = Convert.ToInt32(ddlTransactionId.SelectedValue);
            int i = clsPayments.InsertPaymentsMaster();
            if (i != 0)
            {
                ClearData();
                lblMsg.Text = "Data inserted.";
            }
            else
                lblMsg.Text = "Data not added to table. Try again.";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void ClearData()
    {
        lblMsg.Text = "";
        txtDueDate.Text = "";
        txtPayAmt.Text = "";
        
        if (ddlPaymentType.Items.Count != 0)
            ddlPaymentType.SelectedIndex = 0;
        if (ddlPayType.Items.Count != 0)
            ddlPayType.SelectedIndex = 0;
        if (ddlTransactionId.Items.Count != 0)
            ddlTransactionId.SelectedIndex = 0;

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ClearData();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
