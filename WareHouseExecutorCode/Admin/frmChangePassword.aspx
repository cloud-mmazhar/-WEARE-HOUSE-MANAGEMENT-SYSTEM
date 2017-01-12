<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmChangePassword.aspx.cs" Inherits="Admin_frmChangePassword" Title="Untitled Page" %>

<%@ Register src="../User_UserControls/UcChangePassword.ascx" tagname="UcChangePassword" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
   <br />
   <br />
   <br />
    <uc1:UcChangePassword ID="UcChangePassword1" runat="server" />
    </center> 
</asp:Content>

