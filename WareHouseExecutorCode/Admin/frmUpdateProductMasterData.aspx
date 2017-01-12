<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmUpdateProductMasterData.aspx.cs" Inherits="Admin_frmUpdateProductMasterData" Title="Untitled Page" %>
<%@ Register Src="~/User_UserControls/BrowseImage.ascx" TagName="BrowseImage" TagPrefix="Uc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .style5
        {
            width: 120px;
        }
        .style6
        {
            height: 138px;
            text-align: left;
        }
        .style7
        {
            width: 94px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UP1" runat="server" >

<Triggers>

</Triggers>
<ContentTemplate >

<center>
        <br />
      
        <div style="width: 300px">
            <b>Update Products Data
        </b>
        </div>
        <br />
      
         <asp:Label ID="lblMsg" runat="server" ></asp:Label>
         <br />
        
        <table style="width: 382px">
            <tr>
                <td style="text-align: left" class="style7">
                    &nbsp;</td>
                <td style="text-align: left" class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="2">
                    (* Mandetary)</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left" class="style7">
                    Select Product
                </td>
                <td style="text-align: left" class="style5">
                    <asp:DropDownList ID="ddlProdMaster" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="ddlProdMaster_SelectedIndexChanged" >
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="ddlProdMaster" InitialValue="--Select One--"></asp:RequiredFieldValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align: left" class="style7">
                    Abbrevation
                </td>
                <td style="text-align: left" class="style5">
                    <asp:TextBox ID="txtAbbr" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtAbbr"></asp:RequiredFieldValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align: left" class="style7">
                    Description
                </td>
                <td style="text-align: left" class="style5">
                    <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="2">
                    Browse Image</td>
                <td style="text-align: left">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" class="style6">
                <Uc1:BrowseImage ID="BrowseImage1" runat="server" DefaultImageUrl="~/Images/NoImage.jpg" />
                </td>
            </tr>
            <tr>
            <td colspan="2">
                <asp:Button ID="btnAdd" runat="server" Text="Modify" Height="26px" 
                    onclick="btnAdd_Click" Width="97px" /></td><td >
                    &nbsp;</td><td>
                        
                    </td>
            </tr>
        </table>
       
    </center>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

