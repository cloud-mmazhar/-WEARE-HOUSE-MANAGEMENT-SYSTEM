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

public partial class Emp_frmProductStorageMasterDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTransactionId();
            BindPackages();
            BindUnitsData();
            ddlCompanyBrandId.Items.Insert(0, "--Select One--");
        }
    }

    private void BindPackages()
    {
        try
        {
            clsPackageType objPkg = new clsPackageType();
            DataSet ds = objPkg.GetAllPackageTypeMasterData();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlPackageId .DataSource = ds.Tables[0];
                ddlPackageId.DataTextField = "PackageTypeName";
                ddlPackageId.DataValueField = "PackageTypeId";
                ddlPackageId.DataBind();
            }
            ddlPackageId.Items.Insert(0, "--Select One--");
        }
        catch (Exception)
        {
            lblMsg.Text = "Run Time Exception";
        }
    }

    private void BindUnitsData()
    {
        try
        {
            clsUnits objUnit = new clsUnits();
            DataSet ds = objUnit.GetAllUnitsData ();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlUnitId.DataSource = ds.Tables[0];
                ddlUnitId.DataTextField = "UnitName";
                ddlUnitId.DataValueField = "UnitId";
                ddlUnitId.DataBind();
            }
            ddlUnitId.Items.Insert(0, "--Select One--");
        }
        catch (Exception)
        {
            lblMsg.Text = "Run Time Exception";
        }
    }
    private void BindTransactionId()
    {
        try 
        {
            DataSet ds = clsProducts.GetProductStorageTransactionId();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlTransactionId.DataSource = ds.Tables[0];
                ddlTransactionId.DataTextField = "StorageTransactionId";
                ddlTransactionId.DataValueField = "StorageTransactionId";
                ddlTransactionId.DataBind();
            }
            ddlTransactionId.Items.Insert(0, "--Select One--");
        }
        catch (Exception)
        {
            lblMsg.Text = "Run Time Exception";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try 
        {
            lblMsg.Text = "";
            clsProducts.intStorageTransId = Convert.ToInt32(ddlTransactionId.SelectedValue);
            clsProducts.intCompanyBrandId = Convert.ToInt32(ddlCompanyBrandId.SelectedValue);
            clsProducts.intPackageId = Convert.ToInt32(ddlPackageId.SelectedValue);
            clsProducts.intUnit = Convert.ToInt32(ddlUnitId.SelectedValue);
            clsProducts.intQtyRiseForStorage = Convert.ToInt32(txtQtyforStorage.Text);
            clsProducts.intExpectDays = Convert.ToInt32(txtExpectedDays.Text);
            clsProducts.decAmtForStorage = Convert.ToDecimal(txtAmtForStorage.Text);
            clsProducts.strInstrForStorage = txtStorageInstruction.Text;
            clsProducts.intStockAvail = Convert.ToInt32(txtStockAvail.Text);
            int i = clsProducts.InsertProductStorageMasterDetailsData();
            if (i == 1)
            {
                ClearData();
                lblMsg.Text = "Data inserted.";
            }
            else
                lblMsg.Text = "Data not inserted.";
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
            txtStockAvail.Text = "";
            txtStorageInstruction.Text = "";
            txtQtyforStorage.Text = "";
            txtExpectedDays.Text = "";
            txtAmtForStorage.Text = "";
            if (ddlCompanyBrandId.Items.Count != 0)
                ddlCompanyBrandId.SelectedIndex = 0;
            if (ddlPackageId.Items.Count != 0)
                ddlPackageId.SelectedIndex = 0;
            if (ddlTransactionId.Items.Count != 0)
                ddlTransactionId.SelectedIndex = 0;
            if (ddlUnitId.Items.Count != 0)
                ddlUnitId.SelectedIndex = 0;
        }
        catch (Exception)
        {
            lblMsg.Text = "Runtime Error.";
        }
    }
    
    protected void ddlTransactionId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            int Id = 0;

            if (ddlTransactionId.SelectedIndex !=0)
            {
                Id = Convert.ToInt32(ddlTransactionId.SelectedValue);
                DataSet ds = clsProducts.GetComBrandForStorageMasterDetaisByTranId(Id);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlCompanyBrandId.Items.Clear();
                    ddlCompanyBrandId.DataSource = ds.Tables[0];
                    ddlCompanyBrandId.DataValueField = "CompanyBrandId";
                    ddlCompanyBrandId.DataTextField = "CompanyBrandName";
                    ddlCompanyBrandId.DataBind();
                    ddlCompanyBrandId.Items.Insert(0, "--Select One--");
                }
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
    }
}
