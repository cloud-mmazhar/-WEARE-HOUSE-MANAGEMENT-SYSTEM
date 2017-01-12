<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="frmModifyPackageTypeMaster.aspx.cs" Inherits="Admin_frmModifyPackageTypeMaster"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: large;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
     <div style="height: 19px; width: 602px" class="style1">
     All Package Types Details. Here you can Modify Package Types.
     </div>
     <div style="width:600px;height:301px; overflow:auto">
        <asp:GridView ID="grdPackageType" runat="server" AllowPaging="True" 
             AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
             DataKeyNames="PackageTypeId" DataSourceID="SqlDataSource1" ForeColor="#333333" 
             GridLines="None" Height="140px" Width="390px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="PackageTypeId" HeaderText="S.No" 
                    InsertVisible="False" ReadOnly="True" SortExpression="PackageTypeId" />
                <asp:BoundField DataField="PackageTypeName" HeaderText="Name" 
                    SortExpression="PackageTypeName" />
                <asp:BoundField DataField="PackageTypeAbbr" HeaderText="Abbrevation" 
                    SortExpression="PackageTypeAbbr" />
                <asp:BoundField DataField="PackageTypeDesc" HeaderText="Description" 
                    SortExpression="PackageTypeDesc" />
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
             DeleteCommand="DELETE FROM [tbl_PackageTypeMaster] WHERE [PackageTypeId] = @original_PackageTypeId AND [PackageTypeName] = @original_PackageTypeName AND [PackageTypeAbbr] = @original_PackageTypeAbbr AND [PackageTypeDesc] = @original_PackageTypeDesc" 
             InsertCommand="INSERT INTO [tbl_PackageTypeMaster] ([PackageTypeName], [PackageTypeAbbr], [PackageTypeDesc]) VALUES (@PackageTypeName, @PackageTypeAbbr, @PackageTypeDesc)" 
             OldValuesParameterFormatString="original_{0}" 
             SelectCommand="SELECT * FROM [tbl_PackageTypeMaster]" 
             UpdateCommand="UPDATE [tbl_PackageTypeMaster] SET [PackageTypeName] = @PackageTypeName, [PackageTypeAbbr] = @PackageTypeAbbr, [PackageTypeDesc] = @PackageTypeDesc WHERE [PackageTypeId] = @original_PackageTypeId AND [PackageTypeName] = @original_PackageTypeName AND [PackageTypeAbbr] = @original_PackageTypeAbbr AND [PackageTypeDesc] = @original_PackageTypeDesc">
             <DeleteParameters>
                 <asp:Parameter Name="original_PackageTypeId" Type="Int32" />
                 <asp:Parameter Name="original_PackageTypeName" Type="String" />
                 <asp:Parameter Name="original_PackageTypeAbbr" Type="String" />
                 <asp:Parameter Name="original_PackageTypeDesc" Type="String" />
             </DeleteParameters>
             <UpdateParameters>
                 <asp:Parameter Name="PackageTypeName" Type="String" />
                 <asp:Parameter Name="PackageTypeAbbr" Type="String" />
                 <asp:Parameter Name="PackageTypeDesc" Type="String" />
                 <asp:Parameter Name="original_PackageTypeId" Type="Int32" />
                 <asp:Parameter Name="original_PackageTypeName" Type="String" />
                 <asp:Parameter Name="original_PackageTypeAbbr" Type="String" />
                 <asp:Parameter Name="original_PackageTypeDesc" Type="String" />
             </UpdateParameters>
             <InsertParameters>
                 <asp:Parameter Name="PackageTypeName" Type="String" />
                 <asp:Parameter Name="PackageTypeAbbr" Type="String" />
                 <asp:Parameter Name="PackageTypeDesc" Type="String" />
             </InsertParameters>
         </asp:SqlDataSource>
        </div>
    </center>
</asp:Content>
