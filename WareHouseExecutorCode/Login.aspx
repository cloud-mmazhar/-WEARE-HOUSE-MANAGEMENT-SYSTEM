<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: small;
            font-weight: bold;
        }
        .style2
        {
            font-size: x-small;
            font-weight: bold;
        }
        .style3
        {
            color: #FF3000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <br />
    <center>
     
     <asp:Label ID="lblLogoutMsg" runat="server" ></asp:Label>
     
        <table style="background-color: #FFCB31; width: 228px;" border="0" cellpadding="0"
            cellspacing="0">
            <tr>
                <td align="center" style="background-image: url('ImgMain/topkey2ylw.jpg'); background-repeat: no-repeat;
                    width: 230px; height: 50px;">
                    <span class="style1">Login Here</span>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <span class="style2">&nbsp;<span class="style3">( * is Mandatory)</span></span><br />
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <span class="style2">LoginId</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUname" runat="server" Font-Bold="True" Style="font-weight: 700"
                                    Height="20px" Width="120px" Font-Size="XX-Small"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ControlToValidate="txtUname" ID="RequiredFieldValidator1"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="style2">Password</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" Font-Bold="True" Style="font-weight: 700"
                                    Height="20px" Width="120px" Font-Size="X-Small" TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="RequiredFieldValidator2"
                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="text-align: right">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" Font-Bold="True" Font-Size="Small"
                                    OnClick="btnLogin_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Font-Bold="True" ForeColor="Red" Font-Size="X-Small" ID="lblmsg" 
                        runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><br />
                    </td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:Label>
    </center>
</asp:Content>
