<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="frmModifyCompanyBrandMaster.aspx.cs" Inherits="Admin_frmModifyCompanyBrandMaster"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style5
        {
            width: 120px;
        }
        .style7
        {
            width: 157px;
        }
        .style8
        {
            width: 157px;
            font-weight: bold;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
     <asp:AsyncPostBackTrigger ControlID="ddlCBIds" EventName="SelectedIndexChanged" />
     </Triggers>
        <ContentTemplate>
            <center>
                <br />
                <div style="width: 422px" class="style9">
                    Modify Company Brand Details
                </div>
                <br />
                <asp:Label ID="lblMsg" runat="server" 
                    Style="font-weight: 700; font-size: small;"></asp:Label>
                <br />
                <table style="border: thin solid #009A31; width: 425px">
                    <tr>
                        <td style="text-align: left; font-weight: 700;" colspan="2" class="style10">
                            (<span class="style11">*</span> Mandetary)
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
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
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Select Brand
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:DropDownList ID="ddlCBIds" AutoPostBack="true" runat="server" 
                                Height="20px" Width="150px" 
                                onselectedindexchanged="ddlCBIds_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Brand Name
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtName" runat="server" Height="20px" Width="150px"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Abbrevation
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtAbbr" runat="server" Height="20px" Width="150px"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAbbr"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Description
                        </td>
                        <td style="text-align: left" class="style5">
                            <asp:TextBox ID="txtDesc" runat="server" Height="20px" Width="150px"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Product
                        </td>
                        <td class="style5">
                            <asp:DropDownList ID="ddlProducts" runat="server" Height="16px" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProducts"
                                ErrorMessage="*" InitialValue="--Select One--"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style8">
                            Storage Instruction
                        </td>
                        <td class="style5">
                            <asp:DropDownList ID="ddlStorageInst" runat="server" Height="20px" 
                                Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlStorageInst"
                                ErrorMessage="*" InitialValue="--Select One--"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" class="style7">
                            &nbsp;
                        </td>
                        <td style="text-align: left" class="style5">
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
                        <td colspan="4" style="text-align: right">
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
