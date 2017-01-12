<%@ Page Language="C#" MasterPageFile="~/Emp/EmpMasterPage.master" AutoEventWireup="true"
    CodeFile="frmWarehousePaymentDetails.aspx.cs" Inherits="Emp_frmWarehousePaymentDetails"
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
            <center>
                <table style="width: 347px">
                    <tr>
                        <td class="style1" colspan="3">
                            <b>Warehouse Payment Details </b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Payment Transaction Id </b>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlPayTID" runat="server" Height="17px" Width="130px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="ddlPayTID" InitialValue="--Select One--"
                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Actula Pay Date </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtActualPayDate" runat="server"  ></asp:TextBox>
                            <cc1:CalendarExtender ID="txtActualPayDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtActualPayDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtActualPayDate" ID="RequiredFieldValidator2"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Amount Paid </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtAmtPaid" runat="server"  ></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtAmtPaid" ID="RequiredFieldValidator3"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Due Amount</b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtDueAmt" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtDueAmt" ID="RequiredFieldValidator4"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Next Due Date </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtNextDueDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtNextDueDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtNextDueDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="txtNextDueDate"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Cheque/DD No </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtChkDDNo" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtChkDDNo" ID="RequiredFieldValidator6"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Cheque/DD Date </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtChkDDDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtChkDDDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtChkDDDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtChkDDDate" ID="RequiredFieldValidator7"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Cheque/DD Amount </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtChkqDDAmt" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtChkqDDAmt" ID="RequiredFieldValidator8"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Bank Name </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtBankName" ID="RequiredFieldValidator9"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <b>Pament Status </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtPayStatus" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtPayStatus" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                           
                        </td>
                        <td style="text-align: left">
                            
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="font-weight: 700"
                                OnClick="btnSubmit_Click" />
                        </td>
                        <td style="text-align: left">
                            <asp:Button ID="btnClear" CausesValidation="false" runat="server" Text="Clear" Style="font-weight: 700"
                                OnClick="btnClear_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblMsg" runat="server" style="font-weight: 700"></asp:Label>
                <br />
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
