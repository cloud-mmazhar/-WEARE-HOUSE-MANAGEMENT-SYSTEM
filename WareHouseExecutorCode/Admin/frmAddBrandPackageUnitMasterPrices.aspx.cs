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

public partial class Admin_frmBrandPackageUnitMasterPrices : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            if (!IsPostBack)
            {
                GetCompanyBrandId();
                GetStorageInstrId();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void GetCompanyBrandId()
    {
        try
        {
            ddlCompanyBrandId.Items.Clear();
            clsBrands objBrand = new clsBrands();
            DataSet ds = objBrand.GetAllCompanyBrandData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlCompanyBrandId.DataSource = ds.Tables[0];
                ddlCompanyBrandId.DataTextField = "CompanyBrandName";
                ddlCompanyBrandId.DataValueField = "CompanyBrandId";
                ddlCompanyBrandId.DataBind();
            }
            ddlCompanyBrandId.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void GetStorageInstrId()
    {
        try
        {
            ddlStorageinstId.Items.Clear();
            clsStorageInst objStorageInst = new clsStorageInst();
            DataSet ds = objStorageInst.GetAllStorageInstsData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlStorageinstId.DataSource = ds.Tables[0];
                ddlStorageinstId.DataTextField = "StorageInstName";
                ddlStorageinstId.DataValueField = "StorageInstId";
                ddlStorageinstId.DataBind();
            }
            ddlStorageinstId.Items.Insert(0, "--Select One--");
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
            clsBrands.intBrandId = Convert.ToInt32(ddlCompanyBrandId.SelectedValue);
            clsBrands.intPacakageId = Convert.ToInt32(ddlPackageId.SelectedValue);
            clsBrands.intUnitId = Convert.ToInt32(ddlUnitId.SelectedValue);
            clsBrands.UnitQty = Convert.ToInt32(txtUnitQty.Text);
            clsBrands.PriceofItemStorage = Convert.ToDecimal(txtPrice.Text);
            clsBrands.RegAmt = Convert.ToDecimal(txtRegAmt.Text);
            clsBrands.DisofUnitChargeRate = Convert.ToDecimal(txtUnitCharge.Text);
            clsBrands.intStorageInstantId = Convert.ToInt32(ddlStorageinstId.SelectedValue);
            int i = clsBrands.InsertBrandPackageUnitMasterPrices();
            if (i == 1)
            {
                ClearData();
                lblMsg.Text = "Record inserted.";
            }
            else
                lblMsg.Text = "Record not inserted.Try again.";
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
            txtPrice.Text = "";
            txtRegAmt.Text = "";
            txtUnitCharge.Text = "";
            txtUnitQty.Text = "";
            if (ddlCompanyBrandId.Items.Count != 0)
                ddlCompanyBrandId.SelectedIndex = 0;
            if (ddlPackageId.Items.Count != 0)
                ddlPackageId.SelectedIndex = 0;
            if (ddlStorageinstId.Items.Count != 0)
                ddlStorageinstId.SelectedIndex = 0;
            if (ddlUnitId.Items.Count != 0)
                ddlUnitId.SelectedIndex = 0;
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

    protected void ddlCompanyBrandId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPackageId.Items.Clear();
            if (ddlCompanyBrandId.SelectedIndex != 0)
            {
                int BrandId = Convert.ToInt32(ddlCompanyBrandId.SelectedValue);
                DataSet ds = clsPackageType.GetPackageIdforBrandPackageUnitMasterPricesByBrandId(BrandId);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlPackageId.DataSource = ds.Tables[0];
                    ddlPackageId.DataTextField = "PackageTypeName";
                    ddlPackageId.DataValueField = "PackageTypeId";
                    ddlPackageId.DataBind();
                }
                ddlPackageId.Items.Insert(0, "--Select One--");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlPackageId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlUnitId.Items.Clear();
            if (ddlPackageId.SelectedIndex != 0)
            {
                int BrandId = Convert.ToInt32(ddlCompanyBrandId.SelectedValue);
                int PackageId = Convert.ToInt32(ddlPackageId.SelectedValue);
                DataSet ds = clsPackageType.GetUnitIdforBrandPackageUnitMasterPricesByPackageId(BrandId,PackageId);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlUnitId .DataSource = ds.Tables[0];
                    ddlUnitId.DataTextField = "UnitName";
                    ddlUnitId.DataValueField = "UnitId";
                    ddlUnitId.DataBind();
                }
                ddlUnitId.Items.Insert(0, "--Select One--");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
