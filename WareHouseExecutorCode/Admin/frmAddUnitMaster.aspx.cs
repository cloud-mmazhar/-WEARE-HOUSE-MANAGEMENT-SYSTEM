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

public partial class Admin_frmAddUnitMaster : System.Web.UI.Page
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
    clsUnits ObjUnit;
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUnit = new clsUnits();
            ObjUnit.strUnitName = Convert.ToString(txtName.Text);
            ObjUnit.strUnitAbbr = Convert.ToString(txtAbbr.Text);
            ObjUnit.strDesc = Convert.ToString(txtDesc.Text);
            int i = ObjUnit.InsertUnitMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Record inserted";
                txtAbbr.Text = "";
                txtDesc.Text = "";
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
            if (btnShowAll.Text == "Show All")
            {
                ObjUnit = new clsUnits();
                DataSet ds = ObjUnit.GetAllUnitsData();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    grdUnit.DataSource = ds.Tables[0];
                    grdUnit.DataBind();
                }
                else
                {
                    grdUnit.EmptyDataText = "No Records Found to display.";
                    grdUnit.DataBind();
                }
                divUnit.Visible = true;
                btnShowAll.Text = "Close";
            }
            else if (btnShowAll.Text == "Close")
            {
                divUnit.Visible = false;
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
        txtAbbr.Text = "";
        txtDesc.Text = "";
        txtName.Text = "";
    }
}
