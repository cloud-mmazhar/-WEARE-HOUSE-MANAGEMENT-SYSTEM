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

public partial class Emp_frmProductDischargeMasterDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtQtyforDischarge.Enabled = false;
            BindTransactionId();
            BindPackages();
            BindUnitsData();
            ddlCompanyBrandId.Items.Insert(0, "--Select One--");
        }
    }

    private void BindPackages()
    {
        try
        {
            clsPackageType objPkg = new clsPackageType();
            DataSet ds = objPkg.GetAllPackageTypeMasterData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlPackageId.DataSource = ds.Tables[0];
                ddlPackageId.DataTextField = "PackageTypeName";
                ddlPackageId.DataValueField = "PackageTypeId";
                ddlPackageId.DataBind();
            }
            ddlPackageId.Items.Insert(0, "--Select One--");
        }
        catch (Exception)
        {
            lblMsg.Text = "Run Time Exception";
        }
    }

    private void BindUnitsData()
    {
        try
        {
            clsUnits objUnit = new clsUnits();
            DataSet ds = objUnit.GetAllUnitsData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlUnitId.DataSource = ds.Tables[0];
                ddlUnitId.DataTextField = "UnitName";
                ddlUnitId.DataValueField = "UnitId";
                ddlUnitId.DataBind();
            }
            ddlUnitId.Items.Insert(0, "--Select One--");
        }
        catch (Exception)
        {
            lblMsg.Text = "Run Time Exception";
        }
    }
    private void BindTransactionId()
    {
        try
        {
            DataSet ds = clsProducts.GetProductDischargeMasterTransactionId();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlTransactionId.DataSource = ds.Tables[0];
                ddlTransactionId.DataTextField = "DischargeTransactionId";
                ddlTransactionId.DataValueField = "DischargeTransactionId";
                ddlTransactionId.DataBind();
            }
            ddlTransactionId.Items.Insert(0, "--Select One--");
        }
        catch (Exception)
        {
            lblMsg.Text = "Run Time Exception";
        }
    }
    protected void ddlTransactionId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;

            if (ddlTransactionId .SelectedIndex != 0)
            {
                Id = Convert.ToInt32(ddlTransactionId.SelectedValue);
                DataSet ds = clsProducts.GetComBrandForDischargeMasterDetaisByTranId(Id);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlCompanyBrandId.Items.Clear();
                    ddlCompanyBrandId.DataSource = ds.Tables[0];
                    ddlCompanyBrandId.DataValueField = "CompanyBrandId";
                    ddlCompanyBrandId.DataTextField = "CompanyBrandName";
                    ddlCompanyBrandId.DataBind();
                    ddlCompanyBrandId.Items.Insert(0, "--Select One--");
                }
            }
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
            txtAvailStock.Text = "";
            txtQtyforDischarge.Text = "";
            if (ddlCompanyBrandId.Items.Count != 0)
                ddlCompanyBrandId.SelectedIndex = 0;
            if (ddlPackageId.Items.Count != 0)
                ddlPackageId.SelectedIndex = 0;
            if (ddlTransactionId   .Items.Count != 0)
                ddlTransactionId  .SelectedIndex = 0;
            if (ddlUnitId.Items.Count != 0)
                ddlUnitId.SelectedIndex = 0;
        }
        catch (Exception)
        {
            lblMsg.Text = "Runtime Error.";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            clsProducts.intDischargeTransactionId  = Convert.ToInt32(ddlTransactionId.SelectedValue);
            clsProducts.intCompanyBrandId = Convert.ToInt32(ddlCompanyBrandId.SelectedValue);
            clsProducts.intPackageId = Convert.ToInt32(ddlPackageId.SelectedValue);
            clsProducts.intUnit = Convert.ToInt32(ddlUnitId.SelectedValue);
            clsProducts.intQtyRiseForDischarge = Convert.ToInt32(txtQtyforDischarge.Text);
            clsProducts.intStockLeft = (Convert.ToInt32(txtAvailStock.Text)) - (Convert.ToInt32(txtQtyforDischarge.Text));
           // clsProducts.intStockLeft = Convert.ToInt32(txtStockLeft.Text);
            int i = clsProducts.InsertProductDischargeMasterDetailsData();
            if (i == 1)
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

    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
    }

    protected void ddlUnitId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtQtyforDischarge.Enabled = false;
            if (ddlCompanyBrandId.SelectedIndex != 0 && ddlPackageId.SelectedIndex != 0 && ddlUnitId.SelectedIndex != 0)
            {
                int CompanyBrandId = Convert.ToInt32(ddlCompanyBrandId.SelectedValue);
                int PackageId = Convert.ToInt32(ddlPackageId.SelectedValue);
                int UnitId = Convert.ToInt32(ddlUnitId.SelectedValue);

                int AvailStock = clsProducts.GetAvailableStockByBID_PID_UID(CompanyBrandId, PackageId, UnitId);
                if (AvailStock != 0)
                {
                    txtAvailStock.Text = AvailStock.ToString();
                    txtQtyforDischarge.Enabled = true;
                }
                else
                    txtAvailStock.Text = "No Items Found.";
            }
            else
            { 
            
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
