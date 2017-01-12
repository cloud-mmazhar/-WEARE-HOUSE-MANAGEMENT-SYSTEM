<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmEmpContactDetails.aspx.cs" Inherits="Admin_frmEmpContactDetails" Title="Untitled Page" %>
<%@ Register Src="~/Emp_UserControls/UpdateContactDetailsUserControl.ascx" TagName="ContactDetails" TagPrefix="Uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<Uc1:ContactDetails ID="ContactDetails1" runat="server" StrConnectionName="WareHouseManagementConncetionString" UserIdSession='Session["EmpId"]' />
</asp:Content>

