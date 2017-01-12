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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblLogoutMsg.Text = "";
        lblmsg.Text = "";
        lblLogoutMsg.Visible = false;
        if (!IsPostBack)
        {
            if (Session["EmpId"] != null )
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
            }
        }
    }

    clsLogin objLogin = new clsLogin();
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblLogoutMsg.Text = "";
        lblmsg.Text = "";
        lblLogoutMsg.Visible = false;
        string str1 = null;
        string[] UserName = null;
        try
        {
            if (txtUname.Text.Contains("@"))
            {
                string str = txtUname .Text;
                UserName = str.Split('@');
                objLogin.UserName = UserName[0].ToString();
                str1 = UserName[0].ToString();
            }
            else
            {
                objLogin.UserName = txtUname.Text.Trim();
                str1 = txtUname .Text.Trim();
            }
            objLogin.Password = txtPassword.Text.Trim();
            string Role = objLogin.GetUserLogin();
            if (Role.ToUpper() == "NOUSER")
                lblmsg.Text = "Incorrect LoginId and Password. Try again.";
            else
            {
                Session["EmpId"] = objLogin.GetUserIdByLoginDetails(str1, txtPassword.Text.Trim());
                if (Role.ToUpper() == "ADMIN")
                {
                    Session["UserName"] = str1;
                    Session["pwd"] = txtPassword.Text.Trim();
                    FormsAuthentication.RedirectFromLoginPage("Admin", false);
                }
                else if (Role.ToUpper() == "EMP")
                {
                    Session["UserName"] = str1;
                    FormsAuthentication.RedirectFromLoginPage("Emp", false);
                }
                else if (Role.ToUpper() == "SECURITY")
                {
                    Session["UserName"] = str1;
                    FormsAuthentication.RedirectFromLoginPage("Security", false);
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
}
