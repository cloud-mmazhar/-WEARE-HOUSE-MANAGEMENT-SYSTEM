<%@ Page Language="C#" MasterPageFile="~/Security/SecurityMasterPage.master" AutoEventWireup="true" CodeFile="frmSecurityMaster.aspx.cs" Inherits="Security_frmSecurityMaster" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">



    <style type="text/css">
        .style5
        {
            width: 120px;
        }
        .style8
        {
            width: 163px;
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
            font-size: x-small;
            color: #FF3000;
        }
        .style12
        {
            width: 71px;
        }
        .style13
        {
            width: 163px;
        }
        </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        
        </Triggers>
        <ContentTemplate>
            <center>
                <br />
                <div style="width: 422px" class="style9">
                    Security&nbsp; Details</div>
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
                            (<span>*</span> Mandetary)
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
                        <td style="text-align: left" class="style8">
                            Driver Name</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtDriverName" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtDriverName" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            License No</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtLicenceNo" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtLicenceNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            No Of&nbsp; People</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtNoOfPeople" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNoOfPeople"
                                ErrorMessage="*" Style="font-weight: 700"></asp:RequiredFieldValidator>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Vehicle No</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtVehicleNo" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                ControlToValidate="txtVehicleNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Vehicle RC No</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtVehicleRcNo" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="txtVehicleRcNo" ErrorMessage="*" ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Gatepass&nbsp; No</td>
                        <td class="style5" style="text-align: left">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="180px">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" style="text-align: left">
                            &nbsp;</td>
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
                                 Style="font-weight: 700; height: 26px;" onclick="btncancel_Click" />&nbsp;&nbsp;
                            </td>
                    </tr>
                </table>
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

