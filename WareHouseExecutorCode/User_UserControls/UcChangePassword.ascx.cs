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
using WarwhouseManagement;

public partial class UserControls_UcChangePassword : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void ClearFields()
    {
        txtOldPwd.Text = "";
        txtNewPwd.Text = "";
        txtConPwd.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            string strCmdText1 = "select * from tbl_Login where [password]='"+txtOldPwd.Text +"' and EmpId=" + Convert.ToInt32(Session["EmpId"]) + "";
            DataSet ds=SqlHelper.ExecuteDataset(Connection.con , CommandType.Text, strCmdText1);
            if (ds.Tables[0].Rows.Count !=0)
            {
                string strComText2 = "update tbl_Login set Password='" + txtConPwd.Text + "' where EmpId=" + Convert.ToInt32(Session["EmpId"]);
                int i = SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, strComText2);
                if (i == 1)
                {
                    lblMsg.Text = "Your password changed successfully..";
                    ClearFields();
                }
                else
                    lblMsg.Text = "Error Try again.";
            }
            else
                lblMsg.Text = "Password notmatched with oldpassword";
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error: Get asp.net Teamsupport";
        }
    }
}
