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

public partial class Admin_frmCompanyBrandMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (!IsPostBack)
            {
                GetAllCompanyIds();
                GetAllProductIds();
                GetAllStorageInstIds();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void GetAllProductIds()
    {
        try
        {
            clsProducts objProd = new clsProducts();
            DataSet dsProdData=objProd.GetAllProductsData();
            if (dsProdData.Tables[0].Rows.Count != 0)
            {
                ddlProducts.DataSource = dsProdData.Tables[0];
                ddlProducts.DataTextField = "ProductName";
                ddlProducts.DataValueField = "ProductId";
                ddlProducts.DataBind();
                ddlProducts.Items.Insert(0, "--Select One--");
            }
            else
            {
                ddlProducts.Items.Insert(0, "--Select One--");
                ddlProducts.Items.Insert(1, "No Products");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void GetAllCompanyIds()
    {
        try
        {
            clsCompany objCom = new clsCompany();
            DataSet dsComData = objCom.GetAllCompanyData();
            if (dsComData.Tables[0].Rows.Count != 0)
            {
                ddlCompanyId.DataSource = dsComData.Tables[0];
                ddlCompanyId.DataTextField = "CompanyName";
                ddlCompanyId.DataValueField = "CompanyId";
                ddlCompanyId.DataBind();
                ddlCompanyId.Items.Insert(0, "--Select One--");
            }
            else
            {
                ddlCompanyId.Items.Insert(0, "--Select One--");
                ddlCompanyId.Items.Insert(1, "No Products");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


    private void GetAllStorageInstIds()
    {
        try
        {
            clsStorageInst objStor = new clsStorageInst();
            DataSet dsSStorData = objStor.GetAllStorageInstsData();
            if (dsSStorData.Tables[0].Rows.Count != 0)
            {
                ddlStorageInst.DataSource = dsSStorData.Tables[0];
                ddlStorageInst.DataTextField = "StorageInstName";
                ddlStorageInst.DataValueField = "StorageInstId";
                ddlStorageInst.DataBind();
                ddlStorageInst.Items.Insert(0, "--Select One--");
            }
            else
            {
                ddlStorageInst.Items.Insert(0, "--Select One--");
                ddlStorageInst.Items.Insert(1, "No Products");
            }
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
            objBrand = new clsBrands();
            objBrand.strCompanyBrandName  = Convert.ToString(txtName.Text);
            objBrand.strCompanyBrandAbbr  = Convert.ToString(txtAbbr.Text);
            objBrand.strDesc = Convert.ToString(txtDesc.Text);
            objBrand.intProductId = Convert.ToInt32(ddlProducts.SelectedValue);
            objBrand.intStorageInstId = Convert.ToInt32(ddlStorageInst.SelectedValue);
            objBrand.intCompanyId = Convert.ToInt32(ddlCompanyId.SelectedValue);
            int i = objBrand.InsertCompanyBrandMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Record inserted";
                ClearData();
            }
            else
            {
                lblMsg.Text = "Record not inserted";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void ClearData()
    {
        lblMsg.Text = "";
        txtDesc.Text = "";
        txtAbbr.Text = "";
        txtName.Text = "";
        if (ddlStorageInst.Items.Count != 0)
            ddlStorageInst.SelectedIndex = 0;
        if (ddlProducts.Items.Count != 0)
            ddlProducts.SelectedIndex = 0;
    }
    clsBrands objBrand;
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (btnShowAll .Text == "Show All")
            {
                objBrand = new clsBrands();
                DataSet ds = objBrand.GetAllCompanyBrandData ();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    grdCompanyBrand .DataSource = ds.Tables[0];
                    grdCompanyBrand .DataBind();
                }
                else
                {
                    grdCompanyBrand .EmptyDataText = "Record not found.";
                    grdCompanyBrand .DataBind();
                }
                btnShowAll .Text = "Close Grid";
                divData .Visible = true;
            }
            else if (btnShowAll.Text == "Close Grid")
            {
                btnShowAll .Text = "Show All";
                divData .Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            ClearData();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
