<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="frmModifyWarehouseMaster.aspx.cs" Inherits="Admin_frmModifyWarehouseMaster"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style5
        {
            width: 120px;
        }
        .style8
        {
            width: 116px;
            font-weight: bold;
            vertical-align: top;
            text-align: left;
            font-size: small;
        }
        .style9
        {
            font-size: x-large;
            font-weight: bold;
        }
        .style10
        {
            font-size: small;
            color: #FF3000;
        }
        .style11
        {
            font-size: large;
        }
        .style12
        {
            width: 71px;
        }
        .style13
        {
            width: 116px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlWarehouseId" EventName="SelectedIndexChanged" />
        </Triggers>
        <ContentTemplate>
            <center>
                <br />
                <div style="width: 422px" class="style9">
                    Modify Warehouse Information
                </div>
                <br />
                <asp:Label ID="lblMsg" runat="server" Style="font-weight: 700; font-size: small;"></asp:Label>
                <br />
                <table style="border: thin solid #009A31; width: 425px">
                    <tr>
                        <td style="text-align: left" class="style13">
                            &nbsp;
                        </td>
                        <td style="text-align: left" class="style5">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: 700;" colspan="2" class="style10">
                            (<span class="style11">*</span> Mandetary)
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style12">
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
                        <td class="style12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            Select Name
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlWarehouseId" AutoPostBack="true" runat="server" Height="16px" Width="180px"
                                OnSelectedIndexChanged="ddlWarehouseId_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            &nbsp;
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;Name
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtName" runat="server" Height="21px" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtName" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Incharge Emp
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlEmpId" runat="server" Height="16px" Width="180px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlEmpId"
                                ErrorMessage="*" InitialValue="--Select One--" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Address
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtAddress" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAddress" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            EmailID
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtMail" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMail"
                                ErrorMessage="*" Style="font-weight: 700"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtMail" ErrorMessage="Invalid MailID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Style="font-size: x-small; font-weight: 700"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Phone No
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtPhoneNo" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhoneNo"
                                ErrorMessage="*" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Fax No
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtFaxNo" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFaxNo"
                                ErrorMessage="*" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Description
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtDesc" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style13">
                            &nbsp;
                        </td>
                        <td style="text-align: left" class="style5">
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                            &nbsp;
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnAdd" runat="server" Text="Submit" Height="26px" OnClick="btnAdd_Click"
                                Width="97px" Style="font-weight: 700" />&nbsp;&nbsp;
                            <asp:Button ID="btncancel" runat="server" Text="Clear All" CausesValidation="false"
                                OnClick="btncancel_Click" Style="font-weight: 700" />&nbsp;&nbsp;
                            <asp:Button ID="btnShowAll" runat="server" Text="Show All" CausesValidation="false"
                                OnClick="btnShowAll_Click" Style="font-weight: 700" Height="26px" Width="89px" />
                        </td>
                    </tr>
                </table>
                <br />
                <div style="overflow: auto; width: 422px; height: 250px" runat="server" id="divData"
                    visible="false">
                    <asp:GridView ID="grdWarehouse" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None" Style="font-weight: 700; font-size: small" Width="414px" >
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
