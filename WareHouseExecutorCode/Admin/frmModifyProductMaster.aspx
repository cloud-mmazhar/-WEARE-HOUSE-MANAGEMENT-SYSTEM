<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmModifyProductMaster.aspx.cs" Inherits="Admin_frmModifyProductMaster" Title="Untitled Page" %>

<%@ Register Src="~/User_UserControls/BrowseImage.ascx" TagName="BrowseImage" TagPrefix="Uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <br />
        <div style="width: 426px">
            <b style="font-size: x-large">Modify Product Details </b>
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
                    Select Product
                </td>
                <td style="text-align: left" class="style5">
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                         Height="16px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="122px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="DropDownList1" InitialValue="--Select One--"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="text-align: left" class="style7">
                    Product Name</td>
                <td style="text-align: left" class="style5">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
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
                    <asp:Button ID="btnAdd" runat="server" Text="Modify Record" Height="26px" OnClick="btnAdd_Click"
                        Width="112px" Style="font-weight: 700" />&nbsp;&nbsp; &nbsp;&nbsp;
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
            <br />
        </div>
    </center>

</asp:Content>

