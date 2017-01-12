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

public partial class Admin_frmAddWarehouseCompanyBrandsMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
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


    #region Data binding to dropdownlists methods are here..

    void BindWarehouseIds()
    {
        try
        {
            DataSet ds = clsWarehouseMaster.GetAllWarehouseMasterData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlWarehouseId.DataSource = ds.Tables[0];
                ddlWarehouseId.DataTextField = "WarehouseName";
                ddlWarehouseId.DataValueField = "WarehouseId";
                ddlWarehouseId.DataBind();
            }
            ddlWarehouseId.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    void GetAllEmployeeIds()
    {
        try
        {
            DataSet ds = clsEmployee.GetAllEmployeeIds();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlEmpId.DataSource = ds.Tables[0];
                ddlEmpId.DataTextField = "EmpName";
                ddlEmpId.DataValueField = "EmpId";
                ddlEmpId.DataBind();
            }
            ddlEmpId.Items.Insert(0, "--Select One--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

#endregion 

    #region  button events starts from here...
    /// <summary>
    /// Button events starts from here.
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>


    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            clsWarehouseMaster.intWareHouseId = Convert.ToInt32(ddlWarehouseId.SelectedValue);
            clsWarehouseMaster.intCompanyBrandId = Convert.ToInt32(ddlCompanyBrandId.SelectedValue);
            clsWarehouseMaster.intWareHouseInchargeIdId = Convert.ToInt32(ddlEmpId.SelectedValue);
            clsWarehouseMaster.BrandStorageAccptedDate = Convert.ToDateTime(txtAcceptedDate.Text);
            clsWarehouseMaster.BrandStorageStatus = ddlActiveState.SelectedItem.Text;
            clsWarehouseMaster.BrandStorageCapacityReq = Convert.ToInt32(txtRequested.Text);
            clsWarehouseMaster.RegistrationAmtPaid = Convert.ToDecimal(txtAmount.Text);
            clsWarehouseMaster.BrandStorageEndDate = Convert.ToDateTime(txtEndDate.Text);
            int i = clsWarehouseMaster.InsertWareHouseCompanyBrandsMasterData();
            
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


    private void ClearData()
    {
        try
        {
            lblMsg.Text = "";
            txtAcceptedDate.Text = "";
            txtRequested.Text = "";
            txtAmount.Text = "";
            txtEndDate.Text = "";
            if (ddlActiveState.Items.Count != 0)
                ddlActiveState.SelectedIndex = 0;
            if (ddlCompanyBrandId.Items.Count != 0)
                ddlCompanyBrandId.SelectedIndex = 0;
            if (ddlWarehouseId.Items.Count != 0)
                ddlWarehouseId.SelectedIndex = 0;
            if (ddlEmpId.Items.Count != 0)
                ddlEmpId.SelectedIndex = 0;
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
    protected void btnShowAll_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region Dropdownlist selected indexchanged events..

    protected void ddlWarehouseId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlWarehouseId.SelectedIndex != 0)
            {
                ddlCompanyBrandId.Items.Clear();
                int WarehouseId = Convert.ToInt32(ddlWarehouseId.SelectedValue);
                DataSet ds = clsWarehouseMaster.GetCompanyBrandsForWHCBM(WarehouseId);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlCompanyBrandId.DataSource = ds.Tables[0];
                    ddlCompanyBrandId.DataTextField = "CompanyBrandName";
                    ddlCompanyBrandId.DataValueField = "CompanyBrandId";
                    ddlCompanyBrandId.DataBind();
                }
                ddlCompanyBrandId.Items.Insert(0, "--Select One--");    
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    #endregion
}
