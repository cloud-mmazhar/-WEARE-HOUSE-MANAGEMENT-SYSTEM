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

public partial class Admin_frmAddPackageTypeMaster : System.Web.UI.Page
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
    clsPackageType objPack;
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            objPack = new clsPackageType();
            objPack.strPackageTypeName  = Convert.ToString(txtName.Text);
            objPack.strPackageTypeAbbr  = Convert.ToString(txtAbbr.Text);
            objPack.strDesc = Convert.ToString(txtDesc.Text);
            int i = objPack.InsertPackageTypeMasterData ();
            if (i == 1)
            {
                lblMsg.Text = "Record inserted";
                txtDesc.Text = "";
                txtAbbr.Text = "";
                txtName.Text = "";
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
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnShowAll .Text == "Show All")
            {
                objPack = new clsPackageType ();
                DataSet ds = objPack.GetAllPackageTypeMasterData ();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    grdPackage.DataSource = ds.Tables[0];
                    grdPackage.DataBind();
                }
                else
                {
                    grdPackage.EmptyDataText = "No Records Found to display.";
                    grdPackage.DataBind();
                }
                divCompany.Visible = true;
                btnShowAll .Text = "Close";
            }
            else if (btnShowAll.Text == "Close")
            {
                divCompany.Visible = false;
                btnShowAll.Text = "Show All";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
}
