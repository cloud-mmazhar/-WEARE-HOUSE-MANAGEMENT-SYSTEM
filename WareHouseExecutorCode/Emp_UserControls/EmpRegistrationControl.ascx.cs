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

public partial class EmpRegistrationControl : System.Web.UI.UserControl
{
    #region private variables
    private string _HeaderText;
    byte[] imageData = null;
    private string _strTableName;
    private string _strConnection;
    string _strCon;




    SqlCommand cmd;
    SqlConnection cn;
    SqlDataReader dr;
    SqlParameter p;
    int i;
    private string _strColName;
    #endregion

    #region Public properties


    public string GetCon()
    {
        if (!String.IsNullOrEmpty(this._strConnection))
            _strCon  = ConfigurationManager.ConnectionStrings[_strConnection].ConnectionString;
        else
            _strCon  = "Connection Not Established";
        return _strCon ;
    }
   
    public string ConnectionName
    {
        get { return _strConnection; }
        set { _strConnection = value; }
    }
    public string HeaderText
    {
        get { return _HeaderText; }
        set { _HeaderText = value; }
    }
        
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                GetDepartments();
                GetDesignation();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    #region for address

    private int _addCount = 0;

    protected void imgBtnAddAddress_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            _addCount = Convert.ToInt32(ViewState["AddressCount"]) + 1;
            ViewState["AddressCount"] = _addCount;
            string strText = Convert.ToString(ddlAddType.SelectedItem.Text.Trim())
                    + "^" + Convert.ToString(txtDNO.Text.Trim()) + "^" + Convert.ToString(txtStreet.Text.Trim())
                     + "^" + Convert.ToString(txtCity.Text.Trim()) + "^" + Convert.ToString(txtPin.Text.Trim())
                     + "^" + Convert.ToString(txtState.Text.Trim()) + "^" + Convert.ToString(txtCountry.Text.Trim());

            if (_addCount == 1)
            {
                ViewState["Address1"] = strText;
                lblAddressMsg.Text = "Your " + ddlAddType.SelectedItem.Text + " Address Added. To add another select AddressType and Enter Address fields then click Add.";
                ddlAddType.Focus();
            }
            else if (_addCount == 2)
            {
                ViewState["Address2"] = strText;
                lblAddressMsg.Text = "Your " + ddlAddType.SelectedItem.Text + " Address also Added.";
                ddlAddType.Focus();
            }
            else if (_addCount == 3)
            {
                ViewState["Address3"] = strText;
                lblAddressMsg.Text = "Thanks for giving three types of address.";
                imgBtnAddAddress.Enabled = false;
                ddlPhonetype.Focus();
            }
            ddlAddType.Items.RemoveAt(ddlAddType.SelectedIndex);
            ClearAddressTextFields();
            if (_addCount != 0)
                imgbtnAddPhoneNo.Enabled = true;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    void ClearAddressTextFields()
    {
        txtDNO.Text = ""; txtCity.Text = ""; txtState.Text = "";
        txtStreet.Text = ""; txtPin.Text = ""; txtCountry.Text = "";
    }
    #endregion

    void clearSessions()
    {
        ViewState["AddressCount"] = null;
        ViewState["Address1"] = null;
        ViewState["Address2"] = null;
        ViewState["Address3"] = null;

        ViewState["PhoneCount"] = null;
        ViewState["Phone1"] = null;
        ViewState["Phone2"] = null;
        ViewState["Phone3"] = null;
        ViewState["NewQualification"] = null;
    }

    #region  for phone numbers

    private int _PhoneCount = 0;
    protected void imgbtnAddPhoneNo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            _PhoneCount = Convert.ToInt32(ViewState["PhoneCount"]) + 1;
            ViewState["PhoneCount"] = _PhoneCount;
            string strText = Convert.ToString(ddlPhonetype.SelectedItem.Text.Trim())
                              + "^" + Convert.ToString(txtPhoneNo.Text.Trim());
            if (_PhoneCount == 1)
            {
                ViewState["Phone1"] = strText;
                lblPhonetype.Text = "Your " + ddlPhonetype.SelectedItem.Text + " Phone No Added. Add to anther Select 'PhoneType' and enter 'Phone Number' add click add button.";
                ddlPhonetype.Focus();
            }
            else if (_PhoneCount == 2)
            {
                ViewState["Phone2"] = strText;
                lblPhonetype.Text = "Your " + ddlPhonetype.SelectedItem.Text + " Phone No also Added.";
                ddlPhonetype.Focus();
            }
            else if (_PhoneCount == 3)
            {
                ViewState["Phone3"] = strText;
                lblPhonetype.Text = " Thanks for giving three types of phone numbers.";
                imgbtnAddPhoneNo.Enabled = false;
                txtUserName.Focus();
            }
            ddlPhonetype.Items.RemoveAt(ddlPhonetype.SelectedIndex);
            txtPhoneNo.Text = "";
            if (_PhoneCount != 0)
                btnSubmit.Enabled = true;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    #endregion

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUserName.Text == "")
                lblAvail.Text = "Enter Desired LoginName To Check";
            else
            {
                        int j = GetAvailability();
                        if (j == 1)
                        {
                            lblAvail.Text = "Already In Use";
                        }
                        else
                        {
                            lblAvail.Text = "You can Use This";
                        }
            }
        }
        catch (Exception ex)
        {
            lblAvail.Text = "Error In Code";
        }
    }

    public int GetAvailability()
    {
        try
        {
            string strText = "select LoginName from tbl_Login where LoginName='" + txtUserName.Text.Trim() + "'";
            cn = new SqlConnection(GetCon());
            cn.Open();
            cmd = new SqlCommand(strText, cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.HasRows)
                {
                    i = 1;
                }
            }
            else
            {
                i = 0;
            }
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            cn.Close();
        }
    }

    #region insert registration Data into Database

    private void InsertUserDetails()
    {
        try
        {
            cn = new SqlConnection(GetCon());
            cn.Open();
            cmd = new SqlCommand("sp_InsertEmpDetails", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", Convert.ToString(txtFName.Text.Trim()));
            cmd.Parameters.AddWithValue("@MiddleName", Convert.ToString(txtMidName.Text.Trim()));
            cmd.Parameters.AddWithValue("@LastName", Convert.ToString(txtLastName.Text.Trim()));
           
            cmd.Parameters.AddWithValue("@EmpDob", Convert.ToString(txtDob.Text));
            cmd.Parameters.AddWithValue("@EmpDoj", Convert.ToDateTime(System.DateTime.Now.ToShortDateString()));

            cmd.Parameters.AddWithValue("@Gender", Convert.ToString(ddlGender.SelectedValue.Trim()));
            cmd.Parameters.AddWithValue("@MaritalStatus", Convert.ToString(ddlMarStat.SelectedValue.Trim()));

            if (Session["Photo"] != null && Session["FileName"] != null)
            {
                cmd.Parameters.AddWithValue("@UserPhoto", (byte[])Session["Photo"]);
                cmd.Parameters.AddWithValue("@ImageFileName", Convert.ToString(Session["FileName"].ToString()));
            }
            cmd.Parameters.AddWithValue("@UserLoginId", Convert.ToString(txtUserName.Text.Trim()));
            cmd.Parameters.AddWithValue("@Password", Convert.ToString(txtConfirm.Text.Trim()));
            cmd.Parameters.AddWithValue("@HintQuestion", Convert.ToString(ddlSecQues.SelectedItem.Text.Trim()));
            cmd.Parameters.AddWithValue("@HintAnswer", Convert.ToString(txtSecAns.Text.Trim()));

            cmd.Parameters.AddWithValue("@EmpDeptId", Convert.ToInt32(ddlDept.SelectedValue.Trim()));
            
            cmd.Parameters.AddWithValue("@EmpDesigId", Convert.ToInt32(ddlDesg.SelectedValue.Trim()));
            cmd.Parameters.AddWithValue("@Role", Convert.ToString(ddlRole.SelectedValue));
            cmd.Parameters.AddWithValue("@QualiName", Convert.ToString(ddlQualification.SelectedItem.Text.Trim()));
               
            cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PhoneFlag", SqlDbType.VarChar,250).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AddressFlag", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpId1", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@AddressCount", Convert.ToString(ViewState["AddressCount"]));
            cmd.Parameters.AddWithValue("@Address1", Convert.ToString(ViewState["Address1"]));
            cmd.Parameters.AddWithValue("@Address2", Convert.ToString(ViewState["Address2"]));
            cmd.Parameters.AddWithValue("@Address3", Convert.ToString(ViewState["Address3"]));

            cmd.Parameters.AddWithValue("@PhoneCount", Convert.ToString(ViewState["PhoneCount"]));
            cmd.Parameters.AddWithValue("@PhoneString1", Convert.ToString(ViewState["Phone1"]));
            cmd.Parameters.AddWithValue("@PhoneString2", Convert.ToString(ViewState["Phone2"]));
            cmd.Parameters.AddWithValue("@PhoneString3", Convert.ToString(ViewState["Phone3"]));

            cmd.ExecuteNonQuery();
            int j = Convert.ToInt32(cmd.Parameters["@Flag"].Value);
            string strAddressError = Convert.ToString(cmd.Parameters["@AddressFlag"].Value);
            string strPhoneError = Convert.ToString(cmd.Parameters["@PhoneFlag"].Value);

            if (j == 1)
            {
                Session["FileName"] = null;
                Session["Photo"] = null;
                clearSessions();
                lblError.Text = "You Registration Completed Successfully.Thanks For Registration";
                _addCount = 0;
                _PhoneCount = 0;
            }
            else
            {
                lblError.Text = "Error :" + Convert.ToString(strAddressError) + Convert.ToString(strPhoneError);
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            cn.Close();
        }
    }

    #endregion

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try 
        {
            InsertUserDetails();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
      
       
       
    }
   

    #region binding data on pageload
    clsDept objDept;

    private void GetDepartments()
    {
        objDept = new clsDept();
        DataSet ds = objDept.GetDeptID();
        ddlDept.DataSource = ds.Tables[0];
        ddlDept.DataTextField = "DeptName";
        ddlDept.DataValueField = "DepartmentId";
        ddlDept.DataBind();
        ddlDept.Items.Insert(0, "--Select One--");
    }
    
    private void GetDesignation()
    {
        objDept = new clsDept();
        DataSet ds = objDept.GetDesignation();
        Cache["DesgData"] = ds;
        ddlDesg.DataSource = ds.Tables[0];
        ddlDesg.DataTextField = "Desg_Name";
        ddlDesg.DataValueField = "DesignationId";
        ddlDesg.DataBind();
        ddlDesg.Items.Insert(0, "--Select One--");
    }
    
    
    #endregion

    protected void ddlDesg_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
}
