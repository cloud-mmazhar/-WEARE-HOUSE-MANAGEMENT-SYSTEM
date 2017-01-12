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

public partial class Admin_frmModifyCompanyBrandMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetAllCompanyBrandIds();
                GetAllProductIds();
                GetAllStorageInstIds();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    private void GetAllCompanyBrandIds()
    {
        try
        {
            clsBrands objBrand = new clsBrands();
            DataSet dsCBData = objBrand.GetAllCompanyBrandData();
            if (dsCBData.Tables[0].Rows.Count != 0)
            {
                ddlCBIds.DataSource = dsCBData.Tables[0];
                ddlCBIds.DataTextField = "CompanyBrandName";
                ddlCBIds.DataValueField = "CompanyBrandId";
                ddlCBIds.DataBind();
                ddlCBIds.Items.Insert(0, "--Select One--");
            }
            else
            {
                ddlProducts.Items.Insert(0, "--Select One--");
                ddlProducts.Items.Insert(1, "No Data");
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
            DataSet dsProdData = objProd.GetAllProductsData();
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

    private void ClearData()
    {
        try
        {
            lblMsg.Text = "";
            txtDesc.Text = "";
            txtAbbr.Text = "";
            txtName.Text = "";

            if (ddlCBIds.Items.Count != 0)
                ddlCBIds.SelectedIndex = 0;
            if (ddlStorageInst.Items.Count != 0)
                ddlStorageInst.SelectedIndex = 0;
            if (ddlProducts.Items.Count != 0)
                ddlProducts.SelectedIndex = 0;
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            clsBrands objBrand = new clsBrands();
            objBrand.strCompanyBrandName = Convert.ToString(txtName.Text);
            objBrand.strCompanyBrandAbbr = Convert.ToString(txtAbbr.Text);
            objBrand.strDesc = Convert.ToString(txtDesc.Text);
            objBrand.intProductId = Convert.ToInt32(ddlProducts.SelectedValue);
            objBrand.intStorageInstId = Convert.ToInt32(ddlStorageInst.SelectedValue);
            objBrand.intCompanyBrandId = Convert.ToInt32(ddlCBIds.SelectedValue);
            int i = objBrand.UpdateCompanyBrandMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Record Modified.";
                ClearData();
            }
            else
            {
                lblMsg.Text = "Record not Modified";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlCBIds_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            lblMsg.Text = "";
            if (ddlCBIds.SelectedIndex != 0)
            {
                int CBId = 0;
                CBId = Convert.ToInt32(ddlCBIds.SelectedValue);
                if (CBId != 0)
                {
                    clsBrands objBrand = new clsBrands();
                    DataSet dsCBData = objBrand.GetCompanyBrandDataByCBId(CBId);
                    if (dsCBData.Tables[0].Rows.Count != 0)
                    {
                        txtName.Text = dsCBData.Tables[0].Rows[0][1].ToString();
                        txtDesc.Text = dsCBData.Tables[0].Rows[0][3].ToString();
                        txtAbbr.Text = dsCBData.Tables[0].Rows[0][2].ToString();
                        string ProdName = dsCBData.Tables[0].Rows[0][5].ToString();
                        string StorageInst = dsCBData.Tables[0].Rows[0][7].ToString();
                        for (int i = 0; i <= ddlProducts.Items.Count - 1; i++)
                        {
                            if (ddlProducts.Items[i].Text == ProdName)
                                ddlProducts.Items[i].Selected = true;
                            else
                                ddlProducts.Items[i].Selected = false;
                        }
                        for (int i = 0; i <= ddlStorageInst.Items.Count - 1; i++)
                        {
                            if (ddlStorageInst.Items[i].Text == StorageInst)
                                ddlStorageInst.Items[i].Selected = true;
                            else
                                ddlStorageInst.Items[i].Selected = false;
                        }
                    }
                    else
                        lblMsg.Text = "";
                }
                else
                    lblMsg.Text = "Company Brand not yet selected.";
            }
            else
                ClearData();
                
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
