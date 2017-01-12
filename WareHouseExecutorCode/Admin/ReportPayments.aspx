<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ReportPayments.aspx.cs" Inherits="Admin_ReportPayments" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language="javascript" type="text/javascript">
 
    function callPrint(elementId)
    {
       var prtContent = document.getElementById(elementId);                
       var WinPrint = window.open('','', 'left=0,top=0,width=1000,height=600,toolbar=2,scrollbars=2,status=0');
       var docColor="Black";
       var strInnerHTML=prtContent.innerHTML;
       var strModifiedInnerHTMl=strInnerHTML.replace(/white/g,docColor);
       WinPrint.document.write(strModifiedInnerHTMl);
       WinPrint.document.close();
       WinPrint.focus();
       WinPrint.print();
       WinPrint.close();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <br />
        <br />
        <asp:Button ID="btnGetReport" OnClientClick="callPrint('divReport')" runat="server" Text="Print Report" />
        <br />
        <br />
        <div id="divReport">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                Style="font-weight: 700; font-family: Verdana; font-size: x-small" 
                Width="242px" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <Columns>
                   
                    <asp:BoundField DataField="TransactionDate" HeaderText="Date" 
                        ReadOnly="True" SortExpression="TransactionDate" />
                    <asp:BoundField DataField="PayTypeReason" HeaderText="PayReason" 
                        SortExpression="PayTypeReason" />
                    <asp:BoundField DataField="PayAmount" HeaderText="PayAmount" 
                        SortExpression="PayAmount" />
                    <asp:BoundField DataField="PayDueDate" HeaderText="DueDate" 
                        SortExpression="PayDueDate" />
                    <asp:BoundField DataField="PayType" HeaderText="PayType" 
                        SortExpression="PayType" />
                    <asp:BoundField DataField="Actual Pay Date" HeaderText="ActualDate" 
                        SortExpression="ActualPayDate" />
                    <asp:BoundField DataField="AmountPaid" HeaderText="AmountPaid" 
                        SortExpression="AmountPaid" />
                    <asp:BoundField DataField="AmountDue" HeaderText="AmountDue" 
                        SortExpression="AmountDue" />
                    <asp:BoundField DataField="Chq_DD_no" HeaderText="Chq_DD_no" 
                        SortExpression="Chq_DD_no" />
                    <asp:BoundField DataField="Chq_DD_Date" HeaderText="Chq_DD_Date" 
                        SortExpression="Chq_DD_Date" />
                    <asp:BoundField DataField="Chq_DD_Amt" HeaderText="Chq_DD_Amt" 
                        SortExpression="Chq_DD_Amt" />
                    <asp:BoundField DataField="Chq_DD_Bank" HeaderText="Chq_DD_Bank" 
                        SortExpression="Chq_DD_Bank" />
                   
                </Columns>
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:WareHouseManagementConnectionString %>" 
                SelectCommand="sp_GetWareHousePaymentsData" SelectCommandType="StoredProcedure">
            </asp:SqlDataSource>
        </div>
        <br />
        <br />
    </center>
</asp:Content>

