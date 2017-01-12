<%@ Page Language="C#" MasterPageFile="~/Emp/EmpMasterPage.master" AutoEventWireup="true" CodeFile="frmProductStorageMaster.aspx.cs" Inherits="Emp_frmProductStorageMaster" Title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style5
        {
            width: 120px;
        }
        .style8
        {
            width: 341px;
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
            width: 341px;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlWarehouseId" EventName="SelectedIndexChanged" />
        </Triggers>
        <ContentTemplate>
            <center>
                <br />
                <div style="width: 422px" class="style9">
                    Product Storage Master
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
                            Select warehouse </td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlWarehouseId" runat="server" Height="16px" Width="180px"
                               >
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="ddlWarehouseId" ErrorMessage="*" 
                                InitialValue="--Select One--"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            Select Company </td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlCompanyBrandId" runat="server" Height="16px" Width="180px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlCompanyBrandId" Style="font-weight: 700" 
                                InitialValue="--Select One--"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Person Name</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtPersonName" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtPersonName" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Vehicle No</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtVehicleNo" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtVehicleNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            &nbsp;</td>
                        <td class="style5" style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td class="style12">
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
                                OnClick="btncancel_Click" Style="font-weight: 700" />&nbsp;&nbsp;
                            </td>
                    </tr>
                </table>
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

