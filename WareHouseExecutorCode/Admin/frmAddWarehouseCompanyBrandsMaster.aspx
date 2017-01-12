<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmAddWarehouseCompanyBrandsMaster.aspx.cs" Inherits="Admin_frmAddWarehouseCompanyBrandsMaster" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                <div style="width: 671px" class="style9">
                    Add Warehouse Company Brands Information
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
                            Select warehouse Id</td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlWarehouseId" AutoPostBack="true" runat="server" Height="16px" Width="180px"
                                OnSelectedIndexChanged="ddlWarehouseId_SelectedIndexChanged">
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
                            CompanyBrand Id</td>
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
                        <td style="text-align: left" class="style14">
                            Incharge Emp
                        </td>
                        <td style="text-align: left" class="style15">
                            <asp:DropDownList ID="ddlEmpId" runat="server" Height="16px" Width="180px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left" class="style16">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlEmpId"
                                ErrorMessage="*" InitialValue="--Select One--" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style17">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Brand Storage Accepted Date</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtAcceptedDate" runat="server" Width="180px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtAcceptedDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtAcceptedDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAcceptedDate" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Brand Storage End Date</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtEndDate" runat="server" Width="180px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtEndDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtEndDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Brand Storage Active State</td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlActiveState" runat="server" Height="16px" Width="180px"  >
                            <asp:ListItem Text="--Select One--">--Select One--</asp:ListItem>
                            <asp:ListItem Text="Active" Value="1">Active</asp:ListItem>
                            <asp:ListItem Text="InActive" Value="0">InActive</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlActiveState"
                                ErrorMessage="*" Style="font-weight: 700" InitialValue="--Select One--"></asp:RequiredFieldValidator>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Brand Storage Capacity Requested</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtRequested" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRequested"
                                ErrorMessage="*" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Amount Paid</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtAmount" runat="server" Width="180px"></asp:TextBox>
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
