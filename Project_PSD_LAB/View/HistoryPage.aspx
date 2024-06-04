<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="Project_PSD_LAB.View.HistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <div><h3>Transaction History</h3></div>

    <div><asp:Label ID="StatusLbl" runat="server" Text="There is no transaction made yet!" Visible="false"></asp:Label></div>

    <div id="TransactionList">
        <asp:GridView ID="TransactionListGV" runat="server" AutoGenerateColumns="False" DataKeyNames="TransactionID" OnSelectedIndexChanging="TransactionListGV_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" DataFormatString="{0:d}"/>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:CommandField HeaderText="Transaction Details" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
