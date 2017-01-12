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

public partial class Admin_frmAddStorageInstMaster : System.Web.UI.Page
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

    clsStorageInst  ObjStorageInst;

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ObjStorageInst = new clsStorageInst();
            ObjStorageInst.strStorageInstName = Convert.ToString(txtName.Text);
           
            ObjStorageInst.strDesc = Convert.ToString(txtDesc.Text);
            int i = ObjStorageInst.InsertStorageInstMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Record inserted";
               
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
                ObjStorageInst = new clsStorageInst ();
                DataSet ds = ObjStorageInst.GetAllStorageInstsData();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    grdStorageInst.DataSource = ds.Tables[0];
                    grdStorageInst.DataBind();
                }
                else
                {
                    grdStorageInst.EmptyDataText = "No Records Found to display.";
                    grdStorageInst.DataBind();
                }
                divStorageInst.Visible = true;
                btnShowAll.Text = "Close";
            }
            else if (btnShowAll.Text == "Close")
            {
                divStorageInst.Visible = false;
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
        txtDesc.Text = "";
        txtName.Text = "";
    }
}
