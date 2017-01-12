<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmAddBrandPackageUnitMasterPrices.aspx.cs" Inherits="Admin_frmBrandPackageUnitMasterPrices" Title="Untitled Page" %>

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
            font-size: x-small;
            color: #FF3000;
        }
        .style12
        {
            width: 71px;
        }
        .style13
        {
            width: 341px;
        }
        .style14
        {
            width: 341px;
            font-weight: bold;
            vertical-align: top;
            text-align: left;
            font-size: small;
            height: 26px;
        }
        .style15
        {
            width: 120px;
            height: 26px;
        }
        .style16
        {
            height: 26px;
        }
        .style17
        {
            width: 71px;
            height: 26px;
        }
        .style18
        {
            color: #422010;
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
                <div style="width: 560px" class="style9">
                    <span class="style18">Add Brand Package Unit Data</span>
                </div>
                <br />
                <asp:Label ID="lblMsg" runat="server" Style="font-weight: 700; font-size: small;"></asp:Label>
                <br />
                <table style="border: thin solid #009A31; width: 456px">
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
                        <td class="style8">
                            CompanyBrand Id</td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlCompanyBrandId" runat="server" Height="16px" 
                                Width="180px" 
                                onselectedindexchanged="ddlCompanyBrandId_SelectedIndexChanged" 
                                AutoPostBack="True">
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
                        <td style="text-align: left" class="style14">
                            Package Id</td>
                        <td style="text-align: left" class="style15">
                            <asp:DropDownList ID="ddlPackageId" runat="server" Height="16px" Width="180px" 
                                AutoPostBack="True" onselectedindexchanged="ddlPackageId_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left" class="style16">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlPackageId"
                                ErrorMessage="*" InitialValue="--Select One--" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style17">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style14" style="text-align: left">
                            Unit Id</td>
                        <td class="style15" style="text-align: left">
                            <asp:DropDownList ID="ddlUnitId" runat="server" Width="180px">
                            </asp:DropDownList>
                        </td>
                        <td class="style16" style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="ddlUnitId" ErrorMessage="*" InitialValue="--Select One--"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style17">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Quantity Of The Unit</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtUnitQty" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtUnitQty" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Price of the Item for storage</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtPrice" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtPrice" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Registration Amount</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtRegAmt" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRegAmt"
                                ErrorMessage="*" Style="font-weight: 700"></asp:RequiredFieldValidator>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Discount Of Unit charge rate(Hr/Day)</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtUnitCharge" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                ControlToValidate="txtUnitCharge" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Storage Instruction Id</td>
                        <td class="style5" style="text-align: left">
                            <asp:DropDownList ID="ddlStorageinstId" runat="server" Width="180px">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="ddlStorageinstId" ErrorMessage="*" 
                                InitialValue="--Select One--"></asp:RequiredFieldValidator>
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
                            </td>
                    </tr>
                </table>
                <br />
                <div style="overflow: auto; width: 451px; height: 168px" runat="server" id="divData"
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

