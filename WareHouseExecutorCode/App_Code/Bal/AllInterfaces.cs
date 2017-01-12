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

/// <summary>
/// Summary description for AllInterfaces
/// </summary>
public class AllInterfaces
{
	public AllInterfaces()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    interface ICompany
    {
        int InsertCompanyMasterData();
        int UpdateCompanyMasterData();
        DataSet GetAllCompanyData();
        DataSet GetCompanyDataByCompanyId(int CompanyId);
    }

    interface IPackageType
    {
        int InsertPackageTypeMasterData();
        int UpdatePackageTypeMasterData();
        DataSet GetAllPackageTypeMasterData();
        DataSet GetPackageTypeMasterDataByPackageTypeId(int PackageTypeId);
    }
    interface IProducts
    {
        int InsertProductMasterData();
        int UpdateProductMasterData();
        DataSet GetAllProductsData();
        DataSet GetProductDataByProId(int ProductId);
    }
    
}
