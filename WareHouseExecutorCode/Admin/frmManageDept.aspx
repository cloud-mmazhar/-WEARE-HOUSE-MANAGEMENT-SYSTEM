<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="frmManageDept.aspx.cs" Inherits="Admin_ManageEmp_frmManageDept" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style3
        {
            font-family: Verdana;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <span class="style3">Edit Department Details</span><br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="DepartmentId" DataSourceID="ObjectDataSource1"
            ForeColor="#333333" GridLines="None" BorderStyle="Solid" BorderWidth="1px" PageSize="5">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="DepartmentId" Visible="false" HeaderText="DepartmentId"
                    InsertVisible="False" ReadOnly="True" SortExpression="DepartmentId" />
                <asp:BoundField DataField="DeptName" HeaderText="Dept Name" SortExpression="DeptName" />
                <asp:BoundField DataField="Abbreviation" HeaderText="Abbreviation" SortExpression="Abbreviation" />
                <asp:BoundField DataField="DeptLocation" HeaderText="Dept Location" SortExpression="DeptLocation" />
                <asp:BoundField DataField="DeptDescription" HeaderText="Description" SortExpression="DeptDescription" />
            </Columns>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDeptData"
            TypeName="DataSet1TableAdapters.tbl_Dept_MasterTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_DepartmentId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="DeptName" Type="String" />
                <asp:Parameter Name="Abbreviation" Type="String" />
                <asp:Parameter Name="DeptLocation" Type="String" />
                <asp:Parameter Name="DeptDescription" Type="String" />
                <asp:Parameter Name="Original_DepartmentId" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="DeptName" Type="String" />
                <asp:Parameter Name="Abbreviation" Type="String" />
                <asp:Parameter Name="DeptLocation" Type="String" />
                <asp:Parameter Name="DeptDescription" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <br /><br />
<br />
<br />
<br />
    </center>
</asp:Content>
