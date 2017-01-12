<%@ Page Language="C#" MasterPageFile="~/Emp/EmpMasterPage.master" AutoEventWireup="true" CodeFile="frmProductStorageDetails.aspx.cs" Inherits="Emp_frmProductStorageMasterDetails" Title="Untitled Page" %>

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
                    Product Storage Details</div>
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
                        <td class="style8">
                            Transaction Id</td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlTransactionId" AutoPostBack="true" runat="server" Height="16px" 
                                Width="180px" onselectedindexchanged="ddlTransactionId_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="ddlTransactionId" InitialValue="--Select One--" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style8">
                            Company Brand </td>
                        <td class="style5" style="text-align: left">
                            <asp:DropDownList ID="ddlCompanyBrandId" runat="server" AutoPostBack="True" 
                                Height="16px"  
                                Width="180px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="ddlCompanyBrandId" ErrorMessage="*" 
                                InitialValue="--Select One--" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style14">
                            Package Name</td>
                        <td style="text-align: left" class="style15">
                            <asp:DropDownList ID="ddlPackageId" runat="server" Height="16px" Width="180px" 
                                AutoPostBack="True" >
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
                            Unit Name</td>
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
                            Quantity For Storage</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtQtyforStorage" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtQtyforStorage" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Storage Expected Days</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtExpectedDays" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtExpectedDays" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Amount For Storage</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtAmtForStorage" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmtForStorage"
                                ErrorMessage="*" Style="font-weight: 700"></asp:RequiredFieldValidator>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Instruction For Storage</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtStorageInstruction" runat="server" Width="180px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                ControlToValidate="txtStorageInstruction" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Current Stock Available</td>
                        <td class="style5" style="text-align: left">
                            <asp:TextBox ID="txtStockAvail" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="txtStockAvail" ErrorMessage="*" ></asp:RequiredFieldValidator>
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
                                 Style="font-weight: 700" onclick="btncancel_Click" />&nbsp;&nbsp;
                            </td>
                    </tr>
                </table>
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

