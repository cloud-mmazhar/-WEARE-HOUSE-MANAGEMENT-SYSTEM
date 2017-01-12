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
using System.Data.SqlClient;

public partial class UpdateContactDetailsControl : System.Web.UI.UserControl
{
    #region Region for PageLoad event

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!IsPostBack)
        {
         
            try
            {
                GetDataforAddress();
                GetDataforPhones();
                getAddAddressData();
                getAddPhoneData();
                ViewState["AddressOperationType"] = null;
                ViewState["PhoneOperationType"] = null;
                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        lblMsg.Text = "";
        lblMsg1.Text = "";
    }

    #endregion

    #region Region for public properties and private fields


    private string _strCon;
    private string _strConnection;
    private int _intEmpId;


    public string StrConnectionName
    {
        get { return _strConnection; }
        set { _strConnection = value; }
    }

    private string StrCon
    {
        get { return _strCon; }
        set { _strCon = value; }
    }

    public string GetCon()
    {
        string str;
        if (!String.IsNullOrEmpty(this._strConnection))
            this._strCon = ConfigurationManager.ConnectionStrings[_strConnection].ConnectionString;
        else
            this._strCon = "Connection not Established";
        str = _strCon;
        return str;
    }

    private string _strUserIdentifier;

    public string UserIdSession
    {
        get { return _strUserIdentifier; }
        set { _strUserIdentifier = value; }
    }

    void ConvertToInt()
    {
        try
        {
            string[] strS = this._strUserIdentifier.Split('"');
            string str = strS[1].ToString();
            string strSes = Session[str].ToString();
            this._intEmpId = Convert.ToInt32(strSes);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    private int EmpId
    {
        get { return _intEmpId; }
        set { _intEmpId = value; }
    }

    SqlCommand sqlCmd;
    SqlDataAdapter sqlDa;
    DataSet ds;
    SqlDataReader sqlDr;
    SqlConnection sqlCon;

    #endregion

    #region Region fro Praivate methods

    private void GetDataforAddress()
    {
        try
        {
            ConvertToInt();
            string strtext = "select * from tbl_Emp_Address where EmpId=" + this.EmpId  + "";
            sqlCon = new SqlConnection(GetCon());
            sqlCon.Open();
            sqlDa = new SqlDataAdapter(strtext, sqlCon);
            ds = new DataSet();
            sqlDa.Fill(ds);
            grdAddressdetails.DataSource = ds.Tables[0];
            grdAddressdetails.DataBind();
            DataRow dRow = ds.Tables[0].Select("EmpId=" + this.EmpId)[0];
            ViewState["AddressId"] = dRow["Emp_AddressId"].ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            sqlCon.Close();
        }
    }

    private void GetDataforPhones()
    {
        try
        {
            ConvertToInt();
            string strtext = "select * from tbl_Emp_Phone where EmpId=" + this.EmpId + "";
            sqlCon = new SqlConnection(GetCon());
            sqlCon.Open();
            sqlDa = new SqlDataAdapter(strtext, sqlCon);
            ds = new DataSet();
            sqlDa.Fill(ds);
            grdPhoneDetails.DataSource = ds.Tables[0];
            grdPhoneDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            sqlCon.Close();
        }
    }

    private void ClearTextboxforAddress()
    {
        txtCity.Text = "";
        txtCountry.Text = "";
        txtHno.Text = "";
        txtpin.Text = "";
        txtState.Text = "";
        txtStreet.Text = "";
    }

    private void ClearTextboxforPhone()
    {
        txtphoneno.Text = "";
    }

    private void getAddAddressData()
    {
        string str = "";
        Label lbltype;
        int i = 0;
        lnkAddAddress1.Text = "";
        lnkAddAddress2.Text = "";
        lblAddAddressMsg1.Text = "";
        lblAddAddressMsg1.Visible = false;
        foreach (GridViewRow dRow in grdAddressdetails.Rows)
        {
            lbltype = (Label)dRow.FindControl("lblAddType");
            if (i == 0)
                str = lbltype.Text;
            else
                str += "," + lbltype.Text;
            i = i + 1;
        }
        if (i == 1)
        {
            if (str.ToUpper() == "HOME")
            {
                lblAddAddressMsg1.Text = "You can add Two more address types.To Add click the link.";
                lnkAddAddress1.Text = "Office";
                lnkAddAddress2.Text = "Other";
                lnkAddAddress1.CommandArgument = "Office";
                lnkAddAddress2.CommandArgument = "Other";
                lnkAddAddress1.Visible = true;
                lnkAddAddress2.Visible = true;
            }
            if (str.ToUpper() == "OFFICE")
            {
                lblAddAddressMsg1.Text = "You can add Two more address types..To Add click the link.";
                lnkAddAddress1.Text = "Home";
                lnkAddAddress2.Text = "Other";
                lnkAddAddress1.CommandArgument = "Home";
                lnkAddAddress2.CommandArgument = "Other";
                lnkAddAddress1.Visible = true;
                lnkAddAddress2.Visible = true;
            }
            if (str.ToUpper () == "OTHER")
            {
                lblAddAddressMsg1.Text = "You can add Two more address types.To Add click the link.";
                lnkAddAddress1.Text = "Home";
                lnkAddAddress2.Text = "Office";
                lnkAddAddress1.CommandArgument = "Home";
                lnkAddAddress2.CommandArgument = "Office";
                lnkAddAddress1.Visible = true;
                lnkAddAddress2.Visible = true;
            }
            lblAddAddressMsg1.Visible = true;
        }
        if (i == 2)
        {
            if (!str.ToUpper().Contains("HOME"))
            {
                lblAddAddressMsg1.Text = "You can add Home address type.To Add click the link.";
                lnkAddAddress1.Text = "Home";
                lnkAddAddress1.CommandArgument = "Home";
                lnkAddAddress1.Visible = true;
            }
            if (!str.ToUpper().Contains("OFFICE"))
            {
                lblAddAddressMsg1.Text = "You can add Office address type.To Add click the link.";
                lnkAddAddress1.Text = "Office";
                lnkAddAddress1.CommandArgument = "Office";
                lnkAddAddress1.Visible = true;
            }
            if (!str.ToUpper().Contains("OTHER"))
            {
                lblAddAddressMsg1.Text = "You can add Other address type.To Add click the link.";
                lnkAddAddress1.Text = "Other";
                lnkAddAddress1.CommandArgument = "Other";
                lnkAddAddress1.Visible = true;
            }
            lblAddAddressMsg1.Visible = true;
        }
    }

    private void getAddPhoneData()
    {
        string str = "";
        Label lbltype;
        int i = 0;
        lnkAddPhone1.Text = "";
        lnkAddPhone2.Text = "";
        lblAddPhoneMsg.Text = "";
        lblAddPhoneMsg.Visible = false;
        foreach (GridViewRow dRow in grdPhoneDetails.Rows)
        {
            lbltype = (Label)dRow.FindControl("lblPhoneType");
            if (i == 0)
                str = lbltype.Text.ToUpper();
            else
                str += "," + lbltype.Text.ToUpper();
            i = i + 1;
        }
       
        if (i == 1)
        {
            if (str == "HOME")
            {
                lblAddPhoneMsg.Text = "You can add Two more Phone types.To Add click the link.";
                lnkAddPhone1.Text = "Office";
                lnkAddPhone2.Text = "Other";
                lnkAddPhone1.CommandArgument = "Office";
                lnkAddPhone2.CommandArgument = "Other";
                lnkAddPhone1.Visible = true;
                lnkAddPhone2.Visible = true;
            }
            if (str == "OFFICE")
            {
                lblAddPhoneMsg.Text = "You can add Two more Phone types.To Add click the link.";
                lnkAddPhone1.Text = "Home";
                lnkAddPhone2.Text = "Other";
                lnkAddPhone1.CommandArgument = "Home";
                lnkAddAddress2.CommandArgument = "Other";
                lnkAddPhone1.Visible = true;
                lnkAddPhone2.Visible = true;
            }
            if (str == "OTHER")
            {
                lblAddPhoneMsg.Text = "You can add Two more Phone types.To Add click the link.";
                lnkAddPhone1.Text = "Home";
                lnkAddPhone2.Text = "Office";
                lnkAddPhone1.CommandArgument = "Home";
                lnkAddPhone2.CommandArgument = "Office";
                lnkAddPhone1.Visible = true;
                lnkAddPhone2.Visible = true;
            }
            lblAddPhoneMsg.Visible = true;
        }
        if (i == 2)
        {
            if (!str.Contains("HOME"))
            {
                lblAddPhoneMsg.Text = "You can add Home Phonetype.To Add click the link.";
                lnkAddPhone1.Text = "Home";
                lnkAddPhone1.CommandArgument = "Home";
                lnkAddPhone1.Visible = true;
            }
            if (!str.Contains("OFFICE"))
            {
                lblAddPhoneMsg.Text = "You can add Office Phonetype.To Add click the link.";
                lnkAddPhone1.Text = "Office";
                lnkAddPhone1.CommandArgument = "Office";
                lnkAddPhone1.Visible = true;
            }
            if (!str.Contains("OTHER"))
            {
                lblAddPhoneMsg.Text = "You can add Other Phonetype.To Add click the link.";
                lnkAddPhone1.Text = "Other";
                lnkAddPhone1.CommandArgument = "Other";
                lnkAddPhone1.Visible = true;
            }
            lblAddPhoneMsg.Visible = true;
        }
    }

    #endregion

    #region Region For gridview rowcommand events 

    protected void grdAddressdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ModifyAddress")
            {
                int i = Convert.ToInt32(e.CommandArgument);
                HiddenField hdnfield = new HiddenField();
                Label lblUserAddId, lblAddType1, lblHno, lblStreet, lblPin, lblCity, lblState, lblCountry;
                //find the data from grid view
                lblAddType1 = (Label)grdAddressdetails.Rows[i].FindControl("lblAddType");
                lblUserAddId = (Label)grdAddressdetails.Rows[i].FindControl("lblUseraddId");
                //ViewState["AddressID"] = lblUserAddId.Text;
                lblHno = (Label)grdAddressdetails.Rows[i].FindControl("lblHno");
                lblStreet = (Label)grdAddressdetails.Rows[i].FindControl("lblStreet");
                lblCity = (Label)grdAddressdetails.Rows[i].FindControl("lblCity");
                lblState = (Label)grdAddressdetails.Rows[i].FindControl("lblState");
                lblCountry = (Label)grdAddressdetails.Rows[i].FindControl("lblCountry");
                lblPin = (Label)grdAddressdetails.Rows[i].FindControl("lblPinCode");
                //assigning the data to textbox controls.
                lblAddType.Text = lblAddType1.Text;
                txtHno.Text = lblHno.Text;
                txtStreet.Text = lblStreet.Text;
                txtCity.Text = lblCity.Text;
                txtpin.Text = lblPin.Text;
                txtState.Text = lblState.Text;
                txtCountry.Text = lblCountry.Text;
                pnlAddress.Visible = true;
                ViewState["AddressOperationType"] = 0;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void grdPhoneDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ModifyPhones")
            {
                int i = Convert.ToInt32(e.CommandArgument);
                Label lblPhoneNo, lblPhoneType;
                //find the data from grid view
                lblPhoneType = (Label)grdPhoneDetails.Rows[i].FindControl("lblPhoneType");
                //ViewState["UseraddId"] = (Label)grdAddressdetails.Rows[i].FindControl("lblUseraddId");
                lblPhoneNo = (Label)grdPhoneDetails.Rows[i].FindControl("lblPhoneNo");
                //assigning the data to textbox controls.
                lblPhone.Text = lblPhoneType.Text;
                txtphoneno.Text = lblPhoneNo.Text;
                pnlPhone.Visible = true;
                ViewState["PhoneOperationType"] = 0;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    #endregion

    #region Region fro button controls events

    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        lblError.Text = "";
        try
        {
            ConvertToInt();
            sqlCon = new SqlConnection(GetCon());
            sqlCon.Open();
            if (ViewState["AddressOperationType"] != null && Convert.ToInt32(ViewState["AddressOperationType"]) == 1)
                sqlCmd = new SqlCommand("sp_InsertEmpOneAddressData", sqlCon);
            else
                sqlCmd = new SqlCommand("sp_UpdateEmpAddressDetails", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@EmpId", this.EmpId);

            if (ViewState["AddressOperationType"] != null && Convert.ToInt32(ViewState["AddressOperationType"]) == 1)
                sqlCmd.Parameters.AddWithValue("@EmpAddressId", Convert.ToString(ViewState["AddressId"]));

            sqlCmd.Parameters.AddWithValue("@EmpAddressType", Convert.ToString(lblAddType.Text.Trim()));
            sqlCmd.Parameters.AddWithValue("@Hno", Convert.ToString(txtHno.Text));
            sqlCmd.Parameters.AddWithValue("@Street", Convert.ToString(txtStreet.Text));
            sqlCmd.Parameters.AddWithValue("@City", Convert.ToString(txtCity.Text));
            sqlCmd.Parameters.AddWithValue("@State", Convert.ToString(txtState.Text));
            sqlCmd.Parameters.AddWithValue("@Country", Convert.ToString(txtCountry.Text));
            sqlCmd.Parameters.AddWithValue("@pincode", Convert.ToString(txtpin.Text));
            sqlCmd.Parameters.Add("@Msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            int i = sqlCmd.ExecuteNonQuery();
            if (i == 1)
            {
                if (ViewState["AddressOperationType"] != null && Convert.ToInt32(ViewState["AddressOperationType"]) == 1)
                    lblMsg.Text = sqlCmd.Parameters["@Msg"].Value.ToString();
                else
                    lblMsg.Text = "Your " + lblAddType.Text + " Address Details Modified.";
                ClearTextboxforAddress();
                pnlAddress.Visible = false;
                ViewState["AddressOperationType"] = null;
            }
            else
                lblMsg.Text = "Error While inserting Data.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally
        {
            GetDataforAddress();
            getAddAddressData();
        }
    }

    protected void imgbtnphoneSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ConvertToInt();
            sqlCon = new SqlConnection(GetCon());
            sqlCon.Open();

            if (ViewState["PhoneOperationType"] != null && Convert.ToInt32(ViewState["PhoneOperationType"]) == 1)
                sqlCmd = new SqlCommand("sp_InsertEmpOnePhoneDetails", sqlCon);
            else
                sqlCmd = new SqlCommand("sp_UpdateEmpPhoneDetails", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EmpId", this.EmpId);
            sqlCmd.Parameters.AddWithValue("@PhoneType", lblPhone.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PhoneNumber", txtphoneno.Text.Trim());
            sqlCmd.Parameters.Add("@Msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            int i = sqlCmd.ExecuteNonQuery();
            if (i == 1)
            {
                lblMsg1.Text = "Your " + lblPhone.Text + " Phone Details Modified.";
                if (ViewState["PhoneOperationType"] != null && Convert.ToInt32(ViewState["PhoneOperationType"]) == 1)
                    lblMsg1.Text = sqlCmd.Parameters["@Msg"].Value.ToString();
                ClearTextboxforPhone();
                pnlPhone.Visible = false;
                ViewState["PhoneOperationType"] = null;
            }
            else
            {
                lblMsg1.Text = sqlCmd.Parameters["@Msg"].Value.ToString();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally
        {
            GetDataforPhones();
            getAddPhoneData();
        }
    }

    protected void imgbtnClose_Click(object sender, ImageClickEventArgs e)
    {
        pnlAddress.Visible = false;
        lblMsg.Text = "";
    }

    protected void imgbtnPhoneClose_Click(object sender, ImageClickEventArgs e)
    {
        pnlPhone.Visible = false;
        lblMsg1.Text = "";
    }

    #endregion 

    #region Region for linkbutton command events

    protected void lnkAddAddress1_Command(object sender, CommandEventArgs e)
    {
        pnlAddress.Visible = true;
        lblAddType.Text = e.CommandArgument.ToString();
        ClearTextboxforAddress();
        lblMsg.Text = "";
        ViewState["AddressOperationType"] = 1;
    }

    protected void lnkAddAddress2_Command(object sender, CommandEventArgs e)
    {
        pnlAddress.Visible = true;
        lblAddType.Text = e.CommandArgument.ToString();
        ClearTextboxforAddress();
        lblMsg.Text = "";
        ViewState["AddressOperationType"] = 1;
    }

    protected void lnkAddPhone1_Command(object sender, CommandEventArgs e)
    {
        pnlPhone.Visible = true;
        lblPhone.Text = e.CommandArgument.ToString();
        ClearTextboxforPhone();
        lblMsg1.Text = "";
        ViewState["PhoneOperationType"] = 1;
    }

    protected void lnkAddPhone2_Command(object sender, CommandEventArgs e)
    {
        pnlPhone.Visible = true;
        lblPhone.Text = e.CommandArgument.ToString();
        ClearTextboxforPhone();
        lblMsg1.Text = "";
        ViewState["PhoneOperationType"] = 1;
    }

    #endregion

}
