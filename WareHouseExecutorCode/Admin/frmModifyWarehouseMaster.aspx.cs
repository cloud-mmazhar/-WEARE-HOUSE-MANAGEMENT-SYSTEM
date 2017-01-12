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

public partial class Admin_frmModifyWarehouseMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (!IsPostBack)
            {
                BindWarehouseIds();
                GetAllEmployeeIds();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlWarehouseId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (ddlWarehouseId.SelectedIndex != 0)
            {
                DataSet ds = clsWarehouseMaster.GetWarehouseMasterDataByWarehouseId(Convert.ToInt32(ddlWarehouseId.SelectedValue));
                if (ds.Tables[0].Rows.Count != 0)
                {
                    BindRecord(ds);
                }
                else
                    lblMsg.Text = "No Data found for this record";
            }
            else
                ClearData();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void BindRecord(DataSet  dataset)
    {
        try
        {
            txtName.Text = dataset.Tables[0].Rows[0][1].ToString();
            int EmpId = Convert.ToInt32(dataset.Tables[0].Rows[0][2]);
            for (int i = 0; i <= ddlEmpId.Items.Count - 1; i++)
            {
                if (i != 0)
                {
                    if (Convert.ToInt32(ddlEmpId.Items[i].Value) == EmpId)
                        ddlEmpId.Items[i].Selected = true;
                    else
                        ddlEmpId.Items[i].Selected = false;
                }
                else
                    ddlEmpId.Items[i].Selected = false;
            }
            txtAddress.Text = dataset.Tables[0].Rows[0][3].ToString();
            txtMail.Text = dataset.Tables[0].Rows[0][4].ToString();
            txtPhoneNo.Text = dataset.Tables[0].Rows[0][5].ToString();
            txtFaxNo.Text = dataset.Tables[0].Rows[0][6].ToString();
            txtDesc.Text = dataset.Tables[0].Rows[0][7].ToString();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error :" + ex.Message;
        }
    }

    void BindWarehouseIds()
    {
        DataSet ds = clsWarehouseMaster.GetAllWarehouseMasterData();
        ddlWarehouseId.DataSource = ds.Tables[0];
        ddlWarehouseId.DataTextField = "WarehouseName";
        ddlWarehouseId.DataValueField = "WarehouseId";
        ddlWarehouseId.DataBind();
        ddlWarehouseId.Items.Insert(0, "--Select One--");
    }
    void GetAllEmployeeIds()
    {
        DataSet ds = clsEmployee.GetAllEmployeeIds();
        ddlEmpId.DataSource = ds.Tables[0];
        ddlEmpId.DataTextField = "EmpName";
        ddlEmpId.DataValueField = "EmpId";
        ddlEmpId.DataBind();
        ddlEmpId.Items.Insert(0, "--Select One--");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            clsWarehouseMaster.intWareHouseId = Convert.ToInt32(ddlWarehouseId.SelectedValue);
            clsWarehouseMaster.strWareHouseName = txtName.Text;
            clsWarehouseMaster.intWareHouseInchargeIdId = Convert.ToInt32(ddlEmpId.SelectedValue);
            clsWarehouseMaster.strWareHouseAddress = txtAddress.Text;
            clsWarehouseMaster.strWareHouseMailId = txtMail.Text;
            clsWarehouseMaster.strWareHousePhoneNo = txtPhoneNo.Text;
            clsWarehouseMaster.strWareHouseFaxNo = txtFaxNo.Text;
            clsWarehouseMaster.strWareHouseDesc = txtDesc.Text;
            int i = clsWarehouseMaster.UpdateWareHouseMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Record Modyfied.";
                ClearData();
                BindWarehouseIds();
            }
            else
            {
                lblMsg.Text = "Record not Modyfied";
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
        txtAddress.Text = "";
        txtFaxNo.Text = "";
        txtMail.Text = "";
        txtPhoneNo.Text = "";
        txtName.Text = "";
        if (ddlWarehouseId.Items.Count != 0)
            ddlWarehouseId.SelectedIndex = 0;
        if (ddlEmpId.Items.Count != 0)
            ddlEmpId.SelectedIndex = 0;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            divData.Visible = false;
            if (btnShowAll.Text == "Show All")
            {
                DataSet ds = clsWarehouseMaster.GetAllWarehouseMasterData();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    grdWarehouse.DataSource = ds.Tables[0];
                    grdWarehouse.DataBind();
                }
                else
                {
                    grdWarehouse.EmptyDataText = "Record not found.";
                    grdWarehouse.DataBind();
                }
                btnShowAll.Text = "Close Grid";
                divData.Visible = true;
            }
            else if (btnShowAll.Text == "Close Grid")
            {
                btnShowAll.Text = "Show All";
                divData.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    
}
