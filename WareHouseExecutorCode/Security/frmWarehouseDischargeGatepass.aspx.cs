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

public partial class Security_frmWarehouseDischargeGatepass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int j = 0;
            clsSecurity.GatepassDT = DateTime.Now.Date;
            clsSecurity.EmpId = Convert.ToInt32(Session["EmpId"]);
            clsSecurity.Instructionforsecurity = txtInstruction.Text;
            int i = clsSecurity.InsertWarehouseGatepassData(out j);
            if (i != 0 && j != 0)
            {
               // Server.Transfer("~/Security/frmSecurityMaster.aspx?TID=" + j);
                lblMsg.Text = "Gatepass Id Number is : " + j.ToString();
            }
            else
                lblMsg.Text = "Gatepass not generated tryagain.";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
