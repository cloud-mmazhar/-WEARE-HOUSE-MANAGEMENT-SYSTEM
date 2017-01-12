<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmAddUnitMaster.aspx.cs" Inherits="Admin_frmAddUnitMaster" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style5
        {
            width: 120px;
        }
        .style7
        {
            width: 129px;
        }
        .style8
        {
            width: 129px;
            font-weight: bold;
        }
        .style9
        {
            font-size: x-large;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <div style="width: 300px" class="style9">
            Add New Unit 
        </div>
        <br />
        <asp:Label ID="lblMsg" runat="server" style="font-weight: 700"></asp:Label>
        <br />
        <table style="border: thin solid #009A31; width: 425px">
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
                <td style="text-align: left; font-weight: 700;" colspan="2">
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
                <td style="text-align: left" class="style8">
                    Unit Name
                </td>
                <td style="text-align: left" class="style5">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="text-align: left" class="style8">
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
                <td style="text-align: left" class="style8">
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
                <td style="text-align: left" class="style7">
                    &nbsp;
                </td>
                <td style="text-align: left" class="style5">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Height="26px" OnClick="btnAdd_Click"
                        Width="97px" Style="font-weight: 700" />&nbsp;&nbsp;
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" CausesValidation="false"
                        OnClick="btncancel_Click" Style="font-weight: 700" />&nbsp;&nbsp;
                    <asp:Button ID="btnShowAll" runat="server" Text="Show All" CausesValidation="false"
                        OnClick="btnShowAll_Click" Style="font-weight: 700" Height="26px" Width="89px" />
                </td>
            </tr>
        </table>
        <br />
        <div style="overflow: auto; width: 422px;" runat="server" id="divUnit" height="500px"
            visible="false">
            <asp:GridView ID="grdUnit" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" style="font-weight: 700; font-size: small">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
    </center>
</asp:Content>

