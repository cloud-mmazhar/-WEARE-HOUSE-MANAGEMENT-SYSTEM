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

public partial class Admin_frmUpdateProductMasterData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetAllProdId();        
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    clsProducts objProd;
    private void GetAllProdId()
    {
        try 
        { 
            objProd=new clsProducts ();
            DataSet ds = objProd.GetAllProductsData();
            ddlProdMaster.DataSource = ds;
            ddlProdMaster.DataValueField = "ProductId";
            ddlProdMaster.DataTextField = "ProductName";
            ddlProdMaster.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


    protected void ddlProdMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            int ProdId =Convert.ToInt32( ddlProdMaster.SelectedValue);
            if (ProdId != 0)
            {
                DataSet dsData = objProd.GetProductDataByProId(ProdId);
                if (dsData.Tables[0].Rows.Count != 0)
                { 
                   txtAbbr.Text=dsData.Tables[0].Rows[0][2].ToString();
                   txtDesc.Text = dsData.Tables[0].Rows[0][3].ToString();
                   BrowseImage1.LoadFileName = dsData.Tables[0].Rows[0][4].ToString();
                   BrowseImage1.LaodImageByte =(byte[])dsData.Tables[0].Rows[0][5];
                   BrowseImage1.GetImage();
                }
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
            objProd = new clsProducts();
            objProd.ProductId = Convert.ToInt32(ddlProdMaster.SelectedValue);
            objProd.strProName = Convert.ToString(ddlProdMaster.SelectedItem.Text);
            objProd.strProAbbr = Convert.ToString(txtAbbr.Text);
            objProd.strDesc = Convert.ToString(txtDesc.Text);
            if (Session["FileName"] != null && Session["Photo"] != null)
            {
                objProd.strFileName = Convert.ToString(Session["FileName"]);
                objProd.imgFileData = (byte[])Session["Photo"];
            }
            else
            {
                objProd.strFileName = Convert.ToString("No File");
                objProd.imgFileData = null;
            }
           
            int i = objProd.UpdateProductMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Record has been Modified";
            }
            else
                lblMsg.Text = "Error in process";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
