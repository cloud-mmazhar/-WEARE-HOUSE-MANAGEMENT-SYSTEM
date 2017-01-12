<%@ Page Language="C#" MasterPageFile="~/Emp/EmpMasterPage.master" AutoEventWireup="true"
    CodeFile="frmWarehousePaymentsMaster.aspx.cs" Inherits="Emp_frmWarehousePaymentsMaster"
    Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <br />
            <br />
            <br />
            <center>
                <table style="width: 347px">
                    <tr>
                        <td class="style1" colspan="3">
                            <b>Warehouse Payments Master </b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Payment for </b>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlPayType" runat="server" Height="17px" Width="130px">
                                <asp:ListItem Value="0">--Select One--</asp:ListItem>
                                <asp:ListItem Value="1">Registration</asp:ListItem>
                                <asp:ListItem Value="2">Storage</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="ddlPayType" InitialValue="--Select One--"
                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Payment Amount </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtPayAmt" runat="server" Height="22px" Width="130px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtPayAmt" ID="RequiredFieldValidator2"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Payment Due Date </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtDueDate" runat="server" Height="22px" Width="130px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDueDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtDueDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtDueDate" ID="RequiredFieldValidator3"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Payment Type </b>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlPaymentType" runat="server" Height="17px" Width="130px">
                                <asp:ListItem Value="--Select One--">--Select One--</asp:ListItem>
                                <asp:ListItem>By Cheque</asp:ListItem>
                                <asp:ListItem>Demand Draft(DD)</asp:ListItem>
                                <asp:ListItem>By Cash </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="ddlPaymentType" InitialValue="--Select One--"
                                ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Storage Transaction Id </b>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlTransactionId" runat="server" Height="17px" Width="130px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                InitialValue="--Select One--" ControlToValidate="ddlTransactionId"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
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
                        <td style="text-align: right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="font-weight: 700"
                                OnClick="btnSubmit_Click" />
                        </td>
                        <td style="text-align: left">
                            <asp:Button ID="btnClear" CausesValidation="false" runat="server" Text="Clear" Style="font-weight: 700" OnClick="btnClear_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <br />
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
