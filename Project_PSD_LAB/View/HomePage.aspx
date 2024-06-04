<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project_PSD_LAB.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text="" Font-Size="Large"></asp:Label>
    </div>

    <div>
        <asp:Label ID="UserRoleLbl" runat="server" Text="" Font-Size="Medium"></asp:Label>
    </div>

    <div id="UserListContainer" runat="server">
        <h2>User List</h2>
        <%--<asp:ListBox ID="UserListBox" runat="server" Height="200px"></asp:ListBox>--%>
        <asp:GridView ID="UserListGV" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" SortExpression="UserID" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserDOB" HeaderText="Date Of Birth" SortExpression="UserDOB" DataFormatString="{0:d}"/>
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                <asp:BoundField DataField="UserRole" HeaderText="Role" SortExpression="UserRole" />
                <asp:BoundField DataField="UserPassword" HeaderText="Password" SortExpression="UserPassword" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
