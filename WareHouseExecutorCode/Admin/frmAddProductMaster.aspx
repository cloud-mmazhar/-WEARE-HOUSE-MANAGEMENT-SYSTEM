<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="frmAddProductMaster.aspx.cs" Inherits="Admin_frmAddProductMaster" Title="Untitled Page" %>

<%@ Register Src="~/User_UserControls/BrowseImage.ascx" TagName="BrowseImage" TagPrefix="Uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style5
        {
            width: 120px;
        }
        .style6
        {
            height: 138px;
            text-align: left;
        }
        .style7
        {
            width: 136px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <div style="width: 426px">
            <b style="font-size: x-large">Add New Product </b>
        </div>
        <br />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <br />
        <table style="border: medium solid #9C3031; width: 428px">
            <tr>
                <td style="text-align: left" class="style7">
                    &nbsp;
                </td>
                <td style="text-align: left" class="style5">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="2">
                    (* Mandetary)
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left" class="style7">
                    Product Name
                </td>
                <td style="text-align: left" class="style5">
                    <asp:TextBox ID="txtProName" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtProName"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="text-align: left" class="style7">
                    Abbrevation
                </td>
                <td style="text-align: left" class="style5">
                    <asp:TextBox ID="txtAbbr" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtAbbr"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="text-align: left" class="style7">
                    Description
                </td>
                <td style="text-align: left" class="style5">
                    <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="2">
                    Browse Image
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4" class="style6">
                    <Uc1:BrowseImage ID="BrowseImage1" runat="server" DefaultImageUrl="~/Images/NoImage.jpg" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Height="26px" OnClick="btnAdd_Click"
                        Width="97px" Style="font-weight: 700" />&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Button ID="btnShowAll" runat="server" Text="Show All" CausesValidation="false"
                        OnClick="btnShowAll_Click" Style="font-weight: 700; width: 150px" Height="26px"
                        Width="97px" />
                </td>
            </tr>
        </table>
        <div style="overflow: auto" runat="server" id="divProducts" width="400px" height="400px"
            visible="false">
            <asp:GridView ID="grdProducts" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="ProductId" CellPadding="4" ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False"
                        ReadOnly="True" SortExpression="ProductId" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="ProductAbbr" HeaderText="ProductAbbr" SortExpression="ProductAbbr" />
                    <asp:BoundField DataField="ProductDesc" HeaderText="ProductDesc" SortExpression="ProductDesc" />
                    <asp:BoundField DataField="ProductImgFileName" HeaderText="ProductImgFileName" SortExpression="ProductImgFileName" />
                </Columns>
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
    </center>
</asp:Content>
