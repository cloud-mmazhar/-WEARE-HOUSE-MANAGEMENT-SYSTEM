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

public partial class Admin_frmAddWarehouseMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetAllEmployeeIds();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
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
            clsWarehouseMaster.strWareHouseName = txtName.Text;
            clsWarehouseMaster.intWareHouseInchargeIdId = Convert.ToInt32(ddlEmpId.SelectedValue);
            clsWarehouseMaster.strWareHouseAddress = txtAddress.Text;
            clsWarehouseMaster.strWareHouseMailId = txtMail.Text;
            clsWarehouseMaster.strWareHousePhoneNo = txtPhoneNo.Text;
            clsWarehouseMaster.strWareHouseFaxNo = txtFaxNo.Text;
            clsWarehouseMaster.strWareHouseDesc = txtDesc.Text;
            int i = clsWarehouseMaster.InsertWareHouseMasterData();
            if (i == 1)
            {
                lblMsg.Text = "Record inserted";
                ClearData();
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

    void ClearData()
    {
        txtDesc.Text = "";
        txtAddress.Text = "";
        txtFaxNo.Text = "";
        txtMail.Text = "";
        txtPhoneNo.Text = "";
        txtName.Text = "";
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
            divData .Visible = false;
            if (btnShowAll .Text == "Show All")
            {
                DataSet ds = clsWarehouseMaster.GetAllWarehouseMasterData();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    grdWarehouse .DataSource = ds.Tables[0];
                    grdWarehouse .DataBind();
                }
                else
                {
                    grdWarehouse.EmptyDataText = "Record not found.";
                    grdWarehouse.DataBind();
                }
                btnShowAll.Text = "Close Grid";
                divData.Visible = true;
            }
            else if (btnShowAll .Text == "Close Grid")
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
