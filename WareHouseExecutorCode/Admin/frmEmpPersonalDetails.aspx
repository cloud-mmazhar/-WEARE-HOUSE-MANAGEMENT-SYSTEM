<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="frmEmpPersonalDetails.aspx.cs" Inherits="Admin_frmEmpPersonalDetails"
    Title="Untitled Page" %>

<%@ Register Src="~/Emp_UserControls/UpdatePersonalDetailsUserControl.ascx"
    TagName="UpdatePersonalDetails" TagPrefix="Uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Uc1:UpdatePersonalDetails ID="UpdatePersonalDetails1" runat="server" StrConnectionName="WareHouseManagementConncetionString" />
</asp:Content>
