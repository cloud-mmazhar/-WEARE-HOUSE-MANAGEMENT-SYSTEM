<%@ Page Language="C#" MasterPageFile="~/Emp/EmpMasterPage.master" AutoEventWireup="true" CodeFile="frmEmpChangePwd.aspx.cs" Inherits="Emp_frmEmpChangePwd" Title="Untitled Page" %>
<%@ Register Src="~/User_UserControls/UcChangePassword.ascx" TagName="PasswordChange" TagPrefix="Ucc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<br />
<br />
<Ucc1:PasswordChange ID="PasswordChange1" runat="server" />
</center>
</asp:Content>

