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
using System.Data.Common;
using System.IO;

public partial class UpdatePersonalDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        lblError.Text = "";
        lblMsg.Text = "";
    }
    
    private string _HeaderText;
    private string _strCon;
    private string _strConnection;
    
    public string HeaderText
    {
        get { return _HeaderText; }
        set { _HeaderText = value; }
    }

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
            this._strCon= ConfigurationManager.ConnectionStrings[_strConnection].ConnectionString;
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

    private int _intEmpId;

    public int EmpId
    {
        get { return _intEmpId; }
        set { _intEmpId = value; }
    }

    SqlCommand sqlCmd;
    SqlDataReader sqlDr;
    SqlConnection sqlCon;
    private void BindData()
    {
        try
        {
            ConvertToInt();
            string strCmdText = "select * from tbl_Emp_Master where EmpId=" + this.EmpId;
            sqlCon = new SqlConnection(GetCon());
            sqlCon.Open();
            sqlCmd = new SqlCommand(strCmdText, sqlCon);
            sqlDr = sqlCmd.ExecuteReader();
            if (sqlDr.HasRows)
            {
                sqlDr.Read();
               
                if (sqlDr["Emp_Photo"] != null)
                {
                    BrowseImage1.LaodImageByte = (byte[])sqlDr["Emp_Photo"];
                    BrowseImage1.LoadFileName = sqlDr["Emp_PhotoFileName"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
           
    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try 
        {
           // byte[] imageData;
            ConvertToInt();
            sqlCon = new SqlConnection(GetCon());
            sqlCon.Open();
            sqlCmd = new SqlCommand("spUpdateUserPersonalDetails",sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("EmpId", Convert.ToInt32(this.EmpId ));
           
           
            if (Session["Photo"] != null && Session["FileName"] != null)
            {
                sqlCmd.Parameters.AddWithValue("@UserPhoto",(byte[])Session["Photo"]);
                sqlCmd.Parameters.AddWithValue("@ImageFileName", Convert.ToString(Session["FileName"].ToString()));
            }
            int i = sqlCmd.ExecuteNonQuery();
            if (i == 1)
            {
                lblMsg.Text = "Your Personal Details Modified.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    
}
