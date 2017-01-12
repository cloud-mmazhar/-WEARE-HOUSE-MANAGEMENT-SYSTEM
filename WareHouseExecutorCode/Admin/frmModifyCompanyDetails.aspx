<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmModifyCompanyDetails.aspx.cs" Inherits="Admin_frmModifyCompanyDetails" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css" >
 .style9
        {
            font-size: x-large;
            font-weight: bold;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <div style="width: 434px" class="style9">
          
    
    Modify Company Details
   
        </div>
    
<br />
<br />
    <asp:GridView ID="grdCompanyMaster" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CompanyId" 
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            AllowSorting="True">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="CompanyId" HeaderText="S.No" 
                InsertVisible="False" ReadOnly="True" SortExpression="CompanyId" />
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                SortExpression="CompanyName" />
            <asp:BoundField DataField="CompanyAbbr" HeaderText="CompanyAbbr" 
                SortExpression="CompanyAbbr" />
            <asp:BoundField DataField="CompanyDesc" HeaderText="CompanyDesc" 
                SortExpression="CompanyDesc" />
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
       
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:WareHouseManagementConnectionString %>" 
        DeleteCommand="DELETE FROM [tbl_CompanyMaster] WHERE [CompanyId] = @original_CompanyId AND [CompanyName] = @original_CompanyName AND [CompanyAbbr] = @original_CompanyAbbr AND [CompanyDesc] = @original_CompanyDesc" 
        InsertCommand="INSERT INTO [tbl_CompanyMaster] ([CompanyName], [CompanyAbbr], [CompanyDesc]) VALUES (@CompanyName, @CompanyAbbr, @CompanyDesc)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [tbl_CompanyMaster]" 
        UpdateCommand="UPDATE [tbl_CompanyMaster] SET [CompanyName] = @CompanyName, [CompanyAbbr] = @CompanyAbbr, [CompanyDesc] = @CompanyDesc WHERE [CompanyId] = @original_CompanyId AND [CompanyName] = @original_CompanyName AND [CompanyAbbr] = @original_CompanyAbbr AND [CompanyDesc] = @original_CompanyDesc">
        <DeleteParameters>
            <asp:Parameter Name="original_CompanyId" Type="Int32" />
            <asp:Parameter Name="original_CompanyName" Type="String" />
            <asp:Parameter Name="original_CompanyAbbr" Type="String" />
            <asp:Parameter Name="original_CompanyDesc" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="CompanyAbbr" Type="String" />
            <asp:Parameter Name="CompanyDesc" Type="String" />
            <asp:Parameter Name="original_CompanyId" Type="Int32" />
            <asp:Parameter Name="original_CompanyName" Type="String" />
            <asp:Parameter Name="original_CompanyAbbr" Type="String" />
            <asp:Parameter Name="original_CompanyDesc" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="CompanyAbbr" Type="String" />
            <asp:Parameter Name="CompanyDesc" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br />
</center>
</asp:Content>

