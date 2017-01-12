<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcChangePassword.ascx.cs"
    Inherits="UserControls_UcChangePassword" %>
<style type="text/css">
           
    .style2
    {
        width: 146px;
    }
           
    .style3
    {
        color: #00659C;
    }
    .style4
    {
        color: #00659C;
        text-align: right;
    }
           
    .style5
    {
        font-size: xx-small;
    }
    .style6
    {
        width: 100px;
        color: #00659C;
        font-size: xx-small;
        text-align: right;
    }
           
</style>
<center style="border: thin solid #00659C; width: 362px; height: 242px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
    </Triggers>
    <ContentTemplate >
    <table style="width: 254px" >
        <tr>
            <td colspan="3" style="text-align: center" >
                <b><span class="style3">Change Your Passwor Here</span> </b>
            </td>
        </tr>
        <tr>
            <td colspan="3"><br />
                </td>
        </tr>
        <tr>
            <td class="style6"  >
                Old Password
            </td>
            <td >
                <asp:TextBox ID="txtOldPwd" runat="server" ></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ControlToValidate="txtOldPwd" ID="RequiredFieldValidator1"
                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4" >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6"  >
                New Password
            </td>
            <td >
                <asp:TextBox ID="txtNewPwd" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ControlToValidate="txtNewPwd" ID="RequiredFieldValidator2"
                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4" >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6" >
                <span class="style5">Retype New Password</span>
            </td>
            <td >
                <asp:TextBox ID="txtConPwd" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ControlToValidate="txtConPwd" ID="RequiredFieldValidator3"
                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: right">
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtNewPwd" ControlToValidate="txtConPwd" 
                    ErrorMessage="Password Not Matched"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style2" >
                &nbsp;</td>
            <td style="text-align: right" >
                <asp:Button ID="Button1" runat="server" Height="26px" Text="Submit" 
                    Width="88px" onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</center>
