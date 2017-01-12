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

public partial class Admin_frmModifyProductMaster : System.Web.UI.Page
{
    clsProducts objProd = new clsProducts();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            GetProducts();
        }
    }
    void GetProducts()
    {
        DataSet ds = objProd.GetAllProductsData();
        if (ds.Tables[0].Rows.Count != 0)
        {
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "ProductName";
            DropDownList1.DataValueField = "ProductId";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "--Select One--");
        }
    }
   

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
           
            objProd.ProductId = Convert.ToInt32(DropDownList1.SelectedValue);
            objProd.strProName = TextBox1.Text;
            objProd.strProAbbr = txtAbbr.Text;
            objProd.strDesc = txtDesc.Text;
            objProd.strFileName = Convert.ToString(Session["FileName"]);
            objProd.imgFileData = (byte[])Session["Photo"];
            int i = objProd.UpdateProductMasterData();
            if (i == 1)
            {
                ClearData();
                lblMsg.Text = "Product Data Modified.";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    void ClearData()
    {
        txtDesc.Text = "";
        txtAbbr.Text = "";
        TextBox1.Text = "";
        if (DropDownList1.Items.Count != 0)
            DropDownList1.SelectedIndex = 0;
        BrowseImage1.GetDefaultImage();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                int intProdId = Convert.ToInt32(DropDownList1.SelectedValue);
                DataSet ds = clsProducts.GetProductDataByProductId(intProdId);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    TextBox1.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtAbbr.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtDesc.Text = ds.Tables[0].Rows[0][3].ToString();
                    BrowseImage1.LoadFileName = ds.Tables[0].Rows[0][4].ToString();
                    BrowseImage1.LaodImageByte = (byte[])ds.Tables[0].Rows[0][5];
                    BrowseImage1.GetImage();
                }
            }
            else
            {
                ClearData();
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
