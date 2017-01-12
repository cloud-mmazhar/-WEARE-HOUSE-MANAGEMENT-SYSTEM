<%@ Page Language="C#" MasterPageFile="~/Emp/EmpMasterPage.master" AutoEventWireup="true" CodeFile="frmEmpContactDetails.aspx.cs" Inherits="Emp_frmEmpContactDetails" Title="Untitled Page" %>

<%@ Register Src="~/Emp_UserControls/UpdateContactDetailsUserControl.ascx" TagName="ContactDetails" TagPrefix="Ucc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
  <Ucc1:ContactDetails ID="ContactDetails1" runat="server" 
        StrConnectionName="WareHouseManagementConncetionString" 
        UserIdSession="Session[&quot;EmpId&quot;]" /></center>
</asp:Content>

