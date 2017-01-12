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

public partial class Admin_ManageEmp_frmAddDept : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            int i = clsDept.insertDept(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
            if (i == 1)
            {
                lblMsg.Text = "Department Data Submitted..";
                ClearData();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    void ClearData()
    {
        TextBox4.Text = "";
        TextBox3.Text = "";
        TextBox2.Text = "";
        TextBox1.Text = "";
    }
}
