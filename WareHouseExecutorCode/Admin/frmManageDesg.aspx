<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmManageDesg.aspx.cs" Inherits="Admin_ManageEmp_frmManageDesg" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
            font-family: Verdana;
            font-weight: bold;
            color: #840000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<br />
    <span class="style3">Edit Designation Details</span><br />
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="DesignationId" DataSourceID="ObjectDataSource1" 
        ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="DesignationId" HeaderText="DesignationId"  
                Visible="False" ReadOnly="True" SortExpression="DesignationId" />
            <asp:BoundField DataField="Desg_Name" HeaderText="Designation" 
                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" 
                SortExpression="Desg_Name" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Abbreviation" HeaderText="Abbreviation" 
                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                SortExpression="Abbreviation" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Desg_Description" HeaderText="Description" 
                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                SortExpression="Desg_Description" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
        </Columns>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDesgData" 
        TypeName="DataSet1TableAdapters.tbl_DesignationMasterTableAdapter" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_DesignationId" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Desg_Name" Type="String" />
            <asp:Parameter Name="Abbreviation" Type="String" />
            <asp:Parameter Name="Desg_Description" Type="String" />
            <asp:Parameter Name="Original_DesignationId" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Desg_Name" Type="String" />
            <asp:Parameter Name="Abbreviation" Type="String" />
            <asp:Parameter Name="Desg_Description" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
<br />
<br />
<br />
<br /><br />
<br />
<br />

</center>
</asp:Content>

