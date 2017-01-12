<%@ Page Language="C#" MasterPageFile="~/Emp/EmpMasterPage.master" AutoEventWireup="true" CodeFile="frmProductDischargeDetails.aspx.cs" Inherits="Emp_frmProductDischargeMasterDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
        .style5
        {
     }
        .style8
        {
         width: 186px;
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
        .style13
        {
         width: 186px;
     }
        .style15
        {
            width: 4px;
            height: 26px;
        }
        .style16
        {
            height: 26px;
         width: 14px;
     }
        .style19
     {
         height: 29px;
     }
     .style20
     {
         height: 29px;
         width: 14px;
     }
     .style22
     {
         width: 4px;
         height: 29px;
     }
     .style23
     {
         width: 14px;
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
                    Product Discharge Details</div>
                <br />
                <asp:Label ID="lblMsg" runat="server" Style="font-weight: 700; font-size: small;"></asp:Label>
                <br />
                <table style="border: thin solid #009A31; width: 416px">
                    <tr>
                        <td style="text-align: left" class="style13">
                            &nbsp;
                        </td>
                        <td style="text-align: left" class="style5">
                            &nbsp;
                        </td>
                        <td class="style23">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: 700;" colspan="2" class="style10">
                            (<span>*</span> Mandetary)
                        </td>
                        <td class="style23">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" colspan="2">
                            &nbsp;
                        </td>
                        <td class="style23">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            DischargeTransaction Id</td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlTransactionId" AutoPostBack="true" runat="server" Height="16px" 
                                Width="180px" onselectedindexchanged="ddlTransactionId_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left" class="style23">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="ddlTransactionId" InitialValue="--Select One--" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
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
                        <td style="text-align: left" class="style23">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="ddlCompanyBrandId" ErrorMessage="*" 
                                InitialValue="--Select One--" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
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
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Unit Name</td>
                        <td class="style22" style="text-align: left">
                            <asp:DropDownList ID="ddlUnitId" runat="server" Width="180px" 
                                onselectedindexchanged="ddlUnitId_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td class="style20" style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="ddlUnitId" ErrorMessage="*" InitialValue="--Select One--"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            Available Stock
                        </td>
                        <td class="style19" style="text-align: left" colspan="2">
                            <asp:TextBox ID="txtAvailStock" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Quantity For Discharge</td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtQtyforDischarge" runat="server" Width="180px"></asp:TextBox>
                            
                        </td>
                        <td style="text-align: left" class="style23">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtQtyforDischarge" Style="font-weight: 700"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" style="text-align: left">
                            &nbsp;</td>
                        <td class="style5" colspan="2" style="text-align: left">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtAvailStock" ControlToValidate="txtQtyforDischarge" 
                                ErrorMessage="Must be Less than Avilable Stock" Operator="LessThanEqual" 
                                Type="Integer" Font-Bold="True" Font-Size="Small"></asp:CompareValidator>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style13">
                            &nbsp;
                        </td>
                        <td style="text-align: left" class="style5">
                            &nbsp;
                        </td>
                        <td style="text-align: left" class="style23">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
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

