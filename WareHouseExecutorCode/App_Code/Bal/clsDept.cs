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
using WarwhouseManagement;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsDept
/// </summary>
public class clsDept:Connection 
{
    public static DataSet ds;
	public clsDept()
	{
		
	}


    string _Name, _Abbr, _Desc, _Loc;

    public string Loc
    {
        get { return _Loc; }
        set { _Loc = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string Abbrevation
    {
        get { return _Abbr; }
        set { _Abbr = value; }
    }
    public string Description
    {
        get { return _Desc; }
        set { _Desc = value; }
    }


    private int _DepartmentId;

    public int DepartmentId
    {
        get { return _DepartmentId; }
        set { _DepartmentId = value; }
    }
   
    public int InsertDepartment()
    {

        SqlParameter[] p = new SqlParameter[4];
        p[0] = new SqlParameter("@DeptName", this._Name);
        p[0].DbType = DbType.String;

        p[1] = new SqlParameter("@Abbreviation", this._Abbr);
        p[1].DbType = DbType.String;

        p[2] = new SqlParameter("@DeptLocation", this._Loc);
        p[2].DbType = DbType.String;

        p[3] = new SqlParameter("@DeptDescription", this._Desc);
        p[3].DbType = DbType.String;


        int Result = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_InsertDeptMaster", p);
        return Result;
    }

    public int ModifyDepartmentDetails()
    {
        SqlParameter[] p = new SqlParameter[5];

        p[0] = new SqlParameter("@DeptId", this.DepartmentId);
        p[0].DbType = DbType.Int32;

        p[1] = new SqlParameter("@DeptName", this._Name);
        p[1].DbType = DbType.String;

        p[2] = new SqlParameter("@Abbreviation", this._Abbr);
        p[2].DbType = DbType.String;

        p[3] = new SqlParameter("@DeptLocation", this._Loc);
        p[3].DbType = DbType.String;

        p[4] = new SqlParameter("@DeptDesc", this._Desc);
        p[4].DbType = DbType.String;

        int Result = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UpdateDeptMaster", p);
        return Result;
    }


    public DataSet ShowDepartment()
    {
        ds = new DataSet();
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Sp_Show_Department");
        return ds;
    }
    public static DataSet GetDeptDataByDeptId(int DeptId)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@DeptId", DeptId);

            return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetDeptDataByDeptId", p);

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetDeptID()
    {
        try
        {
            string strText = "select * from tbl_Dept_Master";
            DataSet ds = SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText, null);
            return ds;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetDesignation()
    {
        try
        {
            string strText = "select * from tbl_DesignationMaster";
            DataSet ds = SqlHelper.ExecuteDataset(Connection.con, CommandType.Text, strText, null);
            return ds;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetEmpIDsByDeptId(int p)
    {
        throw new NotImplementedException();
    }

    public static int insertDept(string p, string p_2, string p_3, string p_4)
    {
        try
        {
            string str = "insert into tbl_Dept_Master(DeptName,Abbreviation,DeptLocation,DeptDescription) values('" + p + "','" + p_2 + "','" + p_3 + "','" + p_4 + "')";
            return SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);   
        }
    }

    public static int insertDesg(string p, string p_2, string p_3)
    {
        try
        {
            string str = "insert into tbl_DesignationMaster(Desg_Name,Abbreviation,Desg_Description) values('" + p + "','" + p_2 + "','" + p_3 + "')";
            return SqlHelper.ExecuteNonQuery(Connection.con, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}