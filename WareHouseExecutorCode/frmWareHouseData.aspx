<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="frmWareHouseData.aspx.cs" Inherits="frmWareHouseData" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <b style="font-size: large; color: Black">All warehouse information available here.
    </b>
    <br />
    <br />
    <asp:GridView Font-Size="Small" ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="WareHouseName" HeaderText="WareHouse Name" SortExpression="WareHouseName" />
            <asp:BoundField DataField="WareHouseAddress" HeaderText="Address" SortExpression="WareHouseAddress" />
            <asp:BoundField DataField="WareHouseEmailId" HeaderText="EmailId" SortExpression="WareHouseEmailId" />
            <asp:BoundField DataField="WareHousePhoneNo" HeaderText="Phone No" SortExpression="WareHousePhoneNo" />
            <asp:BoundField DataField="WareHouseFaxNo" HeaderText="FaxNo" SortExpression="WareHouseFaxNo" />
            <asp:BoundField DataField="WareHouseDesc" HeaderText="About  Warehouse" SortExpression="WareHouseDesc" />
        </Columns>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WareHouseManagementConnectionString %>"
        SelectCommand="SELECT [WareHouseName], [WareHouseAddress], [WareHouseEmailId], [WareHousePhoneNo], [WareHouseFaxNo], [WareHouseDesc] FROM [tbl_WareHouseMaster]">
    </asp:SqlDataSource>
    <center>
    </center>
</asp:Content>
