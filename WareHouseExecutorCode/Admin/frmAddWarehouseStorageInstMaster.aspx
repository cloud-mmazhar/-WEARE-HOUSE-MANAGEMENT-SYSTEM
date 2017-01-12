<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmAddWarehouseStorageInstMaster.aspx.cs" Inherits="Admin_frmWarehouseStorageInstMaster" Title="Untitled Page" %>

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
                <div style="width: 541px" class="style9">
                    Add Warehouse Storage Instructions
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
                            Storage instruction</td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlStorageInstId" runat="server" Height="16px" Width="180px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlStorageInstId" Style="font-weight: 700" 
                                InitialValue="--Select One--"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style14">
                            Storage Type Capacity
                        </td>
                        <td style="text-align: left" class="style15">
                            <asp:TextBox ID="txtStorageTypeCapacity" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left" class="style16">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ErrorMessage="*" ControlToValidate="txtStorageTypeCapacity"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style17">
                            &nbsp;
                        </td>
                    </tr>
                   
                   
                    <tr>
                        <td class="style14" style="text-align: left">
                            &nbsp;</td>
                        <td class="style15" style="text-align: left">
                            &nbsp;</td>
                        <td class="style16" style="text-align: left">
                            &nbsp;</td>
                        <td class="style17">
                            &nbsp;</td>
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


