<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="ReportWHProductsDischarge.aspx.cs" Inherits="Admin_ReportDischargeData" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language="javascript" type="text/javascript">
 
    function callPrint(elementId)
    {
       var prtContent = document.getElementById(elementId);                
       var WinPrint = window.open('','', 'left=0,top=0,width=1000,height=600,toolbar=2,scrollbars=2,status=0');
       var docColor="Black";
       var strInnerHTML=prtContent.innerHTML;
       var strModifiedInnerHTMl=strInnerHTML.replace(/white/g,docColor);
       WinPrint.document.write(strModifiedInnerHTMl);
       WinPrint.document.close();
       WinPrint.focus();
       WinPrint.print();
       WinPrint.close();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <br />
        <br />
        <asp:Button ID="btnGetReport" OnClientClick="callPrint('divReport')" runat="server"
            Text="Print Report" />
        <br />
        <br />
        <div id="divReport">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="TransactionId" DataSourceID="SqlDataSource1" 
                ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" 
                        InsertVisible="False" ReadOnly="True" SortExpression="TransactionId" />
                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" 
                        SortExpression="Date" />
                    <asp:BoundField DataField="EmpName" HeaderText="EmpName" ReadOnly="True" 
                        SortExpression="EmpName" />
                    <asp:BoundField DataField="PersonName" HeaderText="PersonName" 
                        SortExpression="PersonName" />
                    <asp:BoundField DataField="VehicleNo" HeaderText="VehicleNo" 
                        SortExpression="VehicleNo" />
                    <asp:BoundField DataField="WareHouse" HeaderText="WareHouse" ReadOnly="True" 
                        SortExpression="WareHouse" />
                    <asp:BoundField DataField="Company Name" HeaderText="Company Name" 
                        ReadOnly="True" SortExpression="Company Name" />
                    <asp:BoundField DataField="Brand" HeaderText="Brand" ReadOnly="True" 
                        SortExpression="Brand" />
                    <asp:BoundField DataField="Package" HeaderText="Package" ReadOnly="True" 
                        SortExpression="Package" />
                    <asp:BoundField DataField="UnitName" HeaderText="UnitName" ReadOnly="True" 
                        SortExpression="UnitName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                        SortExpression="Quantity" />
                    <asp:BoundField DataField="AvailableStock" HeaderText="AvailableStock" 
                        SortExpression="AvailableStock" />
                </Columns>
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:WareHouseManagementConnectionString %>" 
                SelectCommand="SELECT pdm.DischargeTransactionId AS TransactionId, CONVERT (varchar(20), pdm.DisTransactionDate, 103) AS Date, (SELECT Emp_FirstName FROM tbl_Emp_Master AS em WHERE (EmpId = pdm.EmpId)) AS EmpName, pdm.PersonName, pdm.VehicleNo, (SELECT WareHouseName FROM tbl_WareHouseMaster AS wm WHERE (WareHouseId = pdm.WarehouseId)) AS WareHouse, (SELECT CompanyName FROM tbl_CompanyMaster AS cm WHERE (CompanyId = pdm.CompanyId)) AS [Company Name], (SELECT CompanyBrandName FROM tbl_CompanyBrandsMaster AS cbm WHERE (CompanyBrandId = pdd.CompanyBrandId)) AS Brand, (SELECT PackageTypeName FROM tbl_PackageTypeMaster AS ptm WHERE (PackageTypeId = pdd.PackageId)) AS Package, (SELECT UnitName FROM tbl_UnitMaster AS um WHERE (UnitId = pdd.UnitId)) AS UnitName, pdd.QtyRaisedForDischarge AS Quantity, pdd.CurrentStockLeft AS AvailableStock FROM tbl_ProductDischargedMaster AS pdm INNER JOIN tbl_ProductDischargeMasterDetails AS pdd ON pdm.DischargeTransactionId = pdd.DischargeTransactionId">
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="lblMsg" runat="server" ></asp:Label>
        </div>
        <br />
        <br />
    </center>
</asp:Content>
