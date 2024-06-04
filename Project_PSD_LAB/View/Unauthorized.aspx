<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unauthorized.aspx.cs" Inherits="Project_PSD_LAB.View.Unauthorized" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Access denied</h2>
        </div>
        <div>
            <asp:Label ID="UnauthorizedLbl" runat="server" Text="You do not have permission to view this page!"></asp:Label>
        </div>
        <div>
            <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
        </div>

        <asp:Label ID="TestLbl" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
