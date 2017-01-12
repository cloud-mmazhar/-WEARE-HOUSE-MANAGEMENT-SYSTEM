<%@ Page Language="C#" MasterPageFile="~/Emp/EmpMasterPage.master" AutoEventWireup="true" CodeFile="frmEmpPersonalDetails.aspx.cs" Inherits="Emp_frmPersonalDetails" Title="Untitled Page" %>

<%@ Register Src="~/Emp_UserControls/UpdatePersonalDetailsUserControl.ascx" TagName="PersonalDetails" TagPrefix="Ucc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<br />
<br />
<Ucc1:PersonalDetails ID="PersonalDetails" runat="server" 
        UserIdSession="Session[&quot;EmpId&quot;]" 
        StrConnectionName="WareHouseManagementConnectionString" /> 

</center>
</asp:Content>

