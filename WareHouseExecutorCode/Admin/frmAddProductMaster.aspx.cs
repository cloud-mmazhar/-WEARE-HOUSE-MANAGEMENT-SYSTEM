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

public partial class Admin_frmAddProductMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try 
        {
            if (!IsPostBack)
            { 
            
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    clsProducts objPro;
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            objPro = new clsProducts();
            objPro.strProName = Convert.ToString(txtProName.Text);
            objPro.strProAbbr = Convert.ToString(txtAbbr.Text);
            objPro.strDesc = Convert.ToString(txtDesc.Text);
            if (Session["FileName"] != null && Session["Photo"] != null)
            {
                objPro.strFileName = Convert.ToString(Session["FileName"]);
                objPro.imgFileData = (byte[])Session["Photo"];
            }
            else
            {
                objPro.strFileName = Convert.ToString("No File");
                objPro.imgFileData = null;
            }
           
            int i = objPro.InsertProductMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Recird inserted";
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
    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            txtAbbr.Text = "";
            txtDesc.Text = "";
            txtProName.Text = "";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try 
        {
            divProducts.Visible = false;
            if (btnShowAll.Text == "Show All")
            {
                objPro = new clsProducts();
                DataSet ds = objPro.GetAllProductsData();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    grdProducts.DataSource = ds.Tables[0];
                    grdProducts.DataBind();
                }
                else
                {
                    grdProducts.EmptyDataText = "Record not found.";
                    grdProducts.DataBind();
                }
                btnShowAll.Text = "Close Grid";
                divProducts.Visible = true;
            }
            else if (btnShowAll.Text == "Close Grid")
            {
                btnShowAll.Text = "Show All";
                divProducts.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
