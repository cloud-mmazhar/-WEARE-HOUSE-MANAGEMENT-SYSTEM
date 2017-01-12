<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmModifyUnitMaster.aspx.cs" Inherits="Admin_frmModifyUnitMaster" Title="Untitled Page" %>

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
     All Unit Details. Here you can Modify Unit Data.
     </div>
     <div style="width:600px;height:301px; overflow:auto">
         
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
             AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
             DataKeyNames="UnitId" DataSourceID="SqlDataSource1" ForeColor="#333333" 
             GridLines="None">
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <RowStyle BackColor="#EFF3FB" />
             <Columns>
                 <asp:CommandField ShowEditButton="True" />
                 <asp:BoundField DataField="UnitId" HeaderText="S.No" InsertVisible="False" 
                     ReadOnly="True" SortExpression="UnitId" />
                 <asp:BoundField DataField="UnitName" HeaderText="Unit Name" 
                     SortExpression="UnitName" />
                 <asp:BoundField DataField="UnitAbbr" HeaderText="Abbrevation" 
                     SortExpression="UnitAbbr" />
                 <asp:BoundField DataField="UnitDesc" HeaderText="Description" 
                     SortExpression="UnitDesc" />
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
             DeleteCommand="DELETE FROM [tbl_UnitMaster] WHERE [UnitId] = @original_UnitId AND [UnitName] = @original_UnitName AND [UnitAbbr] = @original_UnitAbbr AND [UnitDesc] = @original_UnitDesc" 
             InsertCommand="INSERT INTO [tbl_UnitMaster] ([UnitName], [UnitAbbr], [UnitDesc]) VALUES (@UnitName, @UnitAbbr, @UnitDesc)" 
             OldValuesParameterFormatString="original_{0}" 
             SelectCommand="SELECT * FROM [tbl_UnitMaster]" 
             UpdateCommand="UPDATE [tbl_UnitMaster] SET [UnitName] = @UnitName, [UnitAbbr] = @UnitAbbr, [UnitDesc] = @UnitDesc WHERE [UnitId] = @original_UnitId AND [UnitName] = @original_UnitName AND [UnitAbbr] = @original_UnitAbbr AND [UnitDesc] = @original_UnitDesc">
             <DeleteParameters>
                 <asp:Parameter Name="original_UnitId" Type="Int32" />
                 <asp:Parameter Name="original_UnitName" Type="String" />
                 <asp:Parameter Name="original_UnitAbbr" Type="String" />
                 <asp:Parameter Name="original_UnitDesc" Type="String" />
             </DeleteParameters>
             <UpdateParameters>
                 <asp:Parameter Name="UnitName" Type="String" />
                 <asp:Parameter Name="UnitAbbr" Type="String" />
                 <asp:Parameter Name="UnitDesc" Type="String" />
                 <asp:Parameter Name="original_UnitId" Type="Int32" />
                 <asp:Parameter Name="original_UnitName" Type="String" />
                 <asp:Parameter Name="original_UnitAbbr" Type="String" />
                 <asp:Parameter Name="original_UnitDesc" Type="String" />
             </UpdateParameters>
             <InsertParameters>
                 <asp:Parameter Name="UnitName" Type="String" />
                 <asp:Parameter Name="UnitAbbr" Type="String" />
                 <asp:Parameter Name="UnitDesc" Type="String" />
             </InsertParameters>
         </asp:SqlDataSource>
         
        </div>
    </center>
</asp:Content>

