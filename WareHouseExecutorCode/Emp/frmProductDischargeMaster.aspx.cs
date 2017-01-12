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


public partial class Emp_frmProductDischargeMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (!IsPostBack)
            {
                BindWarehouseIds();
                BindCompayId();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void BindWarehouseIds()
    {
        try
        {
            DataSet ds = clsWarehouseMaster.GetAllWarehouseMasterData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlWarehouseId.DataSource = ds.Tables[0];
                ddlWarehouseId.DataTextField = "WarehouseName";
                ddlWarehouseId.DataValueField = "WarehouseId";
                ddlWarehouseId.DataBind();
            }
            ddlWarehouseId.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void BindCompayId()
    {
        try
        {
            clsCompany objCom = new clsCompany();
            DataSet ds = objCom.GetAllCompanyData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlCompanyBrandId.DataSource = ds.Tables[0];
                ddlCompanyBrandId.DataTextField = "CompanyName";
                ddlCompanyBrandId.DataValueField = "CompanyId";
                ddlCompanyBrandId.DataBind();
            }
            ddlCompanyBrandId.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            clsProducts.intWarehouseId = Convert.ToInt32(ddlWarehouseId.SelectedValue);
            clsProducts.intCompanyId = Convert.ToInt32(ddlCompanyBrandId.SelectedValue);
            clsProducts.intEmpId = Convert.ToInt32(Session["EmpId"]);
            clsProducts.strPersonName = txtPersonName.Text;
            clsProducts.strVehicleNo = txtVehicleNo.Text;
            clsProducts.strDate = DateTime.Now.Date;
            
            int i = clsProducts.InsertProductDischargeMasterData ();
            if (i == 1)
            {
                ClearData();
                lblMsg.Text = "Record inserted";
            }
            else
                lblMsg.Text = "Record not inserted";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    void ClearData()
    {
        txtVehicleNo.Text = "";
        txtPersonName.Text = "";
        if (ddlWarehouseId.Items.Count != 0)
            ddlWarehouseId.SelectedIndex = 0;
        if (ddlCompanyBrandId.Items.Count != 0)
            ddlCompanyBrandId.SelectedIndex = 0;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}
