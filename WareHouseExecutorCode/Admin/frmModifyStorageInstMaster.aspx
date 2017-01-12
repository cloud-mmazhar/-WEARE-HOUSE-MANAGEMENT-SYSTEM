<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmModifyStorageInstMaster.aspx.cs" Inherits="Admin_frmModifyStorageInstMaster" Title="Untitled Page" %>

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
     All Storage Instant Details. Here you can Modify existing Data.
     </div>
     <div style="width:600px;height:301px; overflow:auto">
         
         <br />
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
             AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
             DataKeyNames="StorageInstId" DataSourceID="SqlDataSource1" ForeColor="#333333" 
             GridLines="None" style="font-weight: 700">
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
                 <asp:CommandField ShowEditButton="True" />
                 <asp:BoundField DataField="StorageInstId" HeaderText="S.No" 
                     InsertVisible="False" ReadOnly="True" SortExpression="StorageInstId" />
                 <asp:BoundField DataField="StorageInstName" HeaderText="Name" 
                     SortExpression="StorageInstName" />
                 <asp:BoundField DataField="StorageInstDesc" HeaderText="Description" 
                     SortExpression="StorageInstDesc" />
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
             DeleteCommand="DELETE FROM [tbl_StorageInstMaster] WHERE [StorageInstId] = @original_StorageInstId AND [StorageInstName] = @original_StorageInstName AND [StorageInstDesc] = @original_StorageInstDesc" 
             InsertCommand="INSERT INTO [tbl_StorageInstMaster] ([StorageInstName], [StorageInstDesc]) VALUES (@StorageInstName, @StorageInstDesc)" 
             OldValuesParameterFormatString="original_{0}" 
             SelectCommand="SELECT * FROM [tbl_StorageInstMaster]" 
             UpdateCommand="UPDATE [tbl_StorageInstMaster] SET [StorageInstName] = @StorageInstName, [StorageInstDesc] = @StorageInstDesc WHERE [StorageInstId] = @original_StorageInstId AND [StorageInstName] = @original_StorageInstName AND [StorageInstDesc] = @original_StorageInstDesc">
             <DeleteParameters>
                 <asp:Parameter Name="original_StorageInstId" Type="Int32" />
                 <asp:Parameter Name="original_StorageInstName" Type="String" />
                 <asp:Parameter Name="original_StorageInstDesc" Type="String" />
             </DeleteParameters>
             <UpdateParameters>
                 <asp:Parameter Name="StorageInstName" Type="String" />
                 <asp:Parameter Name="StorageInstDesc" Type="String" />
                 <asp:Parameter Name="original_StorageInstId" Type="Int32" />
                 <asp:Parameter Name="original_StorageInstName" Type="String" />
                 <asp:Parameter Name="original_StorageInstDesc" Type="String" />
             </UpdateParameters>
             <InsertParameters>
                 <asp:Parameter Name="StorageInstName" Type="String" />
                 <asp:Parameter Name="StorageInstDesc" Type="String" />
             </InsertParameters>
         </asp:SqlDataSource>
         
        </div>
    </center>
</asp:Content>

