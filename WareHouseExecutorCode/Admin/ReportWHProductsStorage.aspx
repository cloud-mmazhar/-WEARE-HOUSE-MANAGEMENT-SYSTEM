<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ReportWHProductsStorage.aspx.cs" Inherits="Admin_ReportProducts" Title="Untitled Page" %>
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
        <asp:Button ID="btnGetReport" OnClientClick="callPrint('divReport')" runat="server" Text="Print Report" />
        <br />
        <br />
        <div id="divReport">
            <asp:GridView ID="grdProducts" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None"
                Style="font-weight: 700; font-family: Verdana; font-size: x-small" 
                Width="365px" AutoGenerateColumns="False" DataKeyNames="StorageTransactionId" 
                DataSourceID="SqlDataSource1">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="StorageTransactionId" 
                        HeaderText="TransactionId" InsertVisible="False" ReadOnly="True" 
                        SortExpression="StorageTransactionId" />
                    <asp:BoundField DataField="StorageDate" HeaderText="StorageDate" 
                        ReadOnly="True" SortExpression="StorageDate" />
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
                    <asp:BoundField DataField="ExpectedDays" HeaderText="ExpectedDays" 
                        SortExpression="ExpectedDays" />
                    <asp:BoundField DataField="AmountForStorage" HeaderText="AmountForStorage" 
                        SortExpression="AmountForStorage" />
                   
                    <asp:BoundField DataField="AvailableStock" HeaderText="AvailableStock" 
                        SortExpression="AvailableStock" />
                </Columns>
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:WareHouseManagementConnectionString %>" 
                SelectCommand="sp_ReportStorageProductDetails" 
                SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
        <br />
        <br />
    </center>
</asp:Content>

