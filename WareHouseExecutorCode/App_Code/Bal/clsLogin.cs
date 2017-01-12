using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using WarwhouseManagement;
/// <summary>
/// Summary description for clsLogin
/// </summary>
public class clsLogin
{
    public clsLogin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public string GetUserLogin()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("@UserName", UserName);
            p[0].SqlDbType = SqlDbType.VarChar;

            p[1] = new SqlParameter("@Password", Password);
            p[1].SqlDbType = SqlDbType.VarChar;

            p[2] = new SqlParameter("@Role", SqlDbType.VarChar, 20);
            p[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(Connection.con, CommandType.StoredProcedure, "sp_EmpLoginChecking", p);

            return this.Role = Convert.ToString(p[2].Value.ToString());
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    SqlConnection cn;
    SqlCommand cmd;

    public int GetUserId()
    {
        try
        {
            cn = new SqlConnection(Connection.con);
            cn.Open();
            cmd = new SqlCommand("select max(UserId) from tbl_UserMaster", cn);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public object GetUserIdByLoginDetails(string str1, string p)
    {
        try
        {
            cn = new SqlConnection(Connection.con);
            cn.Open();
            cmd = new SqlCommand("select EmpId from tbl_Login where LoginName='" + str1 + "' and [Password]='" + p + "'", cn);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
