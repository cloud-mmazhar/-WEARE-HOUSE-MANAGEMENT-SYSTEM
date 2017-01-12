<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="frmUserRegistration.aspx.cs" Inherits="frmUserRegistration" Title="Untitled Page" %>
<%@ Register Src="~/User_UserControls/UserRegistrationCotrol.ascx" TagName="UserRegistration" TagPrefix="Uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <Uc1:UserRegistration ID="UserRegistration1" RedirectPage="~/frmRegistrationOver.aspx" runat="server" ConnectionName="WareHouseManagementConncetionString" />
</asp:Content>

