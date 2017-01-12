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

public partial class Admin_frmAddCompanyMaster : System.Web.UI.Page
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
    clsCompany objCompany;
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            objCompany = new clsCompany();
            objCompany.strCompanyName = Convert.ToString(txtName .Text);
            objCompany.strCompanyAbbr  = Convert.ToString(txtAbbr.Text);
            objCompany.strDesc = Convert.ToString(txtDesc.Text);
            int i = objCompany.InsertCompanyMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Record inserted";
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
            if (btnShowAll.Text == "Show All")
            {
                objCompany = new clsCompany();
                DataSet ds = objCompany.GetAllCompanyData();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    grdCompany.DataSource = ds.Tables[0];
                    grdCompany.DataBind();
                }
                else
                {
                    grdCompany.EmptyDataText = "No Records Found to display.";
                    grdCompany.DataBind();
                }
                divCompany.Visible = true;
                btnShowAll.Text = "Close";
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
