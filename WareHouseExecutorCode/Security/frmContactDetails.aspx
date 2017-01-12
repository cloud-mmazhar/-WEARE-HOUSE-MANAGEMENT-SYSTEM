<%@ Page Language="C#" MasterPageFile="~/Security/SecurityMasterPage.master" AutoEventWireup="true" CodeFile="frmContactDetails.aspx.cs" Inherits="Security_frmContactDetails" Title="Untitled Page" %>

<%@ Register Src="~/Emp_UserControls/UpdateContactDetailsUserControl.ascx" TagName="ContactDetails" TagPrefix="Ucc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<br />
<br />
<Ucc1:ContactDetails ID="ContactDetails1" runat="server" 
        StrConnectionName="WareHouseManagementConnectionString" 
        UserIdSession="Session[&quot;EmpId&quot;]" />
</center>
</asp:Content>

