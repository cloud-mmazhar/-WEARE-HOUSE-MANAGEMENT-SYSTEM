<%@ Page Language="C#" MasterPageFile="~/Security/SecurityMasterPage.master" AutoEventWireup="true"
    CodeFile="frmWarehouseDischargeGatepass.aspx.cs" Inherits="Security_frmWarehouseDischargeGatepass"
    Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: large;
            width: 269px;
            font-weight: bold;
            color: #4A1810;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <br />
            <br />
            <br />
            <br />
            <div style="border: thin solid #0065FF; width: 378px; height: 216px">
            <p class="style1" style="text-align:center"> Gate Pass Generation</p>
                
                <br />
                <br />
                <table style="font-size: x-small">
                    <tr>
                        <td style="text-align: left; font-size: small;">
                            <b style="text-align: left">Date and Time </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtDate" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-size: small;">
                            <b>Instruction To Driver </b>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtInstruction" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        <asp:RequiredFieldValidator ControlToValidate="txtInstruction" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                                style="font-weight: 700" onclick="btnSubmit_Click" />
                        </td>
                        <td style="text-align: right">
                            <asp:Button CausesValidation="false" ID="btnCancel" runat="server" Text="Clear" 
                                style="font-weight: 700" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
                </div>
                <asp:Label ID="lblMsg" runat="server" 
                    style="font-weight: 700; font-size: small" ></asp:Label>
                <br />
            <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
