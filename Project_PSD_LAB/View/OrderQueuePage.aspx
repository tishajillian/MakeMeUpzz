<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="OrderQueuePage.aspx.cs" Inherits="Project_PSD_LAB.View.OrderQueuePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div>
        <h3>Order Queue</h3>
    </div>
    <div id="TransactionList">
        <asp:GridView ID="TransactionListGV" runat="server" AutoGenerateColumns="False" DataKeyNames="TransactionID" OnSelectedIndexChanging="TransactionListGV_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" DataFormatString="{0:d}"/>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />               
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="HandleTransactionBtn" runat="server" CommandName="Select" Text="Handle Transaction" />  
                    </ItemTemplate>
                </asp:TemplateField>               
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Label ID="StatusLbl" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>
</asp:Content>
