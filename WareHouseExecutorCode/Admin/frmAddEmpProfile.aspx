<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmAddEmpProfile.aspx.cs" Inherits="Admin_frmAddEmpProfile" Title="Untitled Page" %>
<%@ Register Src="~/Emp_UserControls/EmpRegistrationControl.ascx" TagName="Registration" TagPrefix="Uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<Uc1:Registration ID="Registration1" runat="server" HeaderText="Employee Profile Adding" ConnectionName="WareHouseManagementConncetionString" />
</center>
</asp:Content>

