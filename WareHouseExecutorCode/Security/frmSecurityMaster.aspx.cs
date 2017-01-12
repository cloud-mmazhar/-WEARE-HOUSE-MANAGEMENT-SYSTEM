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

public partial class Security_frmSecurityMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        { 
         GetAllGatePassData();
        }
    }

    private void GetAllGatePassData()
    {
        try
        {
            DataSet ds = clsSecurity.GetWarehouseGatepassData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "GatepassId";
                DropDownList1.DataValueField = "GatepassId";
                DropDownList1.DataBind();
            }
            DropDownList1.Items.Insert(0, "--Select One--");
        }
        catch (Exception)
        {
            lblMsg.Text = "Runtime Error..";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            clsSecurity.CheckInDateTime = System.DateTime.Now;
            clsSecurity.DriverName = txtDriverName.Text;
            clsSecurity.DriverLicenseNo = txtLicenceNo.Text;
            clsSecurity.NoOfPeople = Convert.ToInt32(txtNoOfPeople.Text);
            clsSecurity.VehicleNo = txtVehicleNo.Text;
            clsSecurity.VehicleRcNo = txtVehicleRcNo.Text;
            clsSecurity.GatepassId = Convert.ToInt32(DropDownList1.SelectedValue);
            clsSecurity.EmpId = Convert.ToInt32(Session["EmpId"]);
            int j = clsSecurity.InsertSecurityMaster();
            if (j != 0)
            {
                ClearData();
                lblMsg.Text = "Data inserted.";
            }
            else
                lblMsg.Text = "Data not inserted.";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


    void ClearData()
    {
        lblMsg.Text = "";
        txtVehicleRcNo.Text = "";
        txtVehicleNo.Text = "";
        txtNoOfPeople.Text = "";
        txtLicenceNo.Text = "";
        txtDriverName.Text = "";
        if (DropDownList1.Items.Count != 0)
            DropDownList1.SelectedIndex = 0;
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}
