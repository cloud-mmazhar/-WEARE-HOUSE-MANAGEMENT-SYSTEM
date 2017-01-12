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

public partial class Admin_frmWarehouseStorageInstMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindWarehouseIds();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    #region Data binding to dropdownlists methods are here..

    void BindWarehouseIds()
    {
        try
        {
            DataSet ds = clsWarehouseMaster.GetAllWarehouseMasterData();
            ddlWarehouseId.DataSource = ds.Tables[0];
            ddlWarehouseId.DataTextField = "WarehouseName";
            ddlWarehouseId.DataValueField = "WarehouseId";
            ddlWarehouseId.DataBind();
            ddlWarehouseId.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    #endregion

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try 
        {
            clsWarehouseMaster.intWareHouseId = Convert.ToInt32(ddlWarehouseId.SelectedValue);
            clsWarehouseMaster.intStorageInstantId = Convert.ToInt32(ddlStorageInstId.SelectedValue);
            clsWarehouseMaster.intStorageInstantTypeCapacity = Convert.ToInt32(txtStorageTypeCapacity.Text);
            int i = clsWarehouseMaster.InsertWareHouseStorageMasterData();
            if (i == 1)
            {
                ClearData();
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

    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
    }

    void ClearData()
    {
        try
        {
            if (ddlWarehouseId.Items.Count != 0)
                ddlWarehouseId.SelectedIndex = 0;
            if (ddlStorageInstId .Items.Count != 0)
                ddlStorageInstId.SelectedIndex = 0;
            txtStorageTypeCapacity.Text = "";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {

    }
    protected void ddlWarehouseId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlStorageInstId.Items.Clear();
            if (ddlWarehouseId.SelectedIndex != 0)
            {
                int WHId = Convert.ToInt32(ddlWarehouseId.SelectedValue);
                DataSet ds = clsWarehouseMaster.GetStorageInstantIdforWHSIMD(WHId);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlStorageInstId.DataSource = ds.Tables[0];
                    ddlStorageInstId.DataValueField = "StorageInstId";
                    ddlStorageInstId.DataTextField = "StorageInstName";
                    ddlStorageInstId.DataBind();
                }
            }
            ddlStorageInstId.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
