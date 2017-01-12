<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpdatePersonalDetailsUserControl.ascx.cs"
    Inherits="UpdatePersonalDetails" %>

<%@ Register Src="~/User_UserControls/BrowseImage.ascx" TagName="BrowseImage" TagPrefix="Uc1" %>

<script src="~/Images/TextValidation.js" type="text/javascript"></script>
<style type="text/css">
    .HeaderTextStyle
    {
        font-weight: bold;
        text-align: left;
        font-size: medium;
        text-decoration: underline;
        font-family: Verdana;
        color:Blue;
    }
    .NormalTextStyle
    {
        text-align: left;
        font-size: 10px;
        font-family: Verdana;
    }
    .style5
    {
        font-family: Verdana;
        font-size: xx-small;
        text-align: left;
    }
    .style6
    {
        color: #FF3300;
        font-family: Verdana;
        font-size:9px;
    }
    
</style>
<center style="width: 578px">
<fieldset style="width: 578px" >
    <table>
        <tr>
            <td align="left" colspan="3" class="HeaderTextStyle">
                Update Your Personal Details
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
            
             <asp:Label ID="lblMsg" runat="server" BackColor="#FFFF99" Font-Bold="True" 
                    Font-Names="Verdana" Font-Size="9px" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td colspan="2" align="left">
                <span class="style5">&nbsp;&nbsp; To Add New Photo Browse Here</span><br />
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td colspan="2" align="right">
                <Uc1:BrowseImage ID="BrowseImage1" runat="server" 
                    DefaultImageUrl="~/Images/NoImage.jpg" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <span class="style6">( * Mandatory)</span><br />
            </td>
        </tr>
        <tr><td></td>
            <td>
                <br />
            </td>
            <td style="text-align: right">
                <asp:ImageButton ID="imgbtnSubmit" runat="server" 
                    ImageUrl="~/Images/btn_submit.jpg" onclick="imgbtnSubmit_Click" />
            </td>
        </tr>
        </table>
    
    </fieldset>
    <br />
    <asp:Label ID="lblError" runat="server" BackColor="#FFFF99" Font-Bold="True" 
                    Font-Names="Verdana" Font-Size="9px" ></asp:Label>
</center>
