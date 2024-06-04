<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project_PSD_LAB.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div><h1>MakeMeUpzz</h1></div>
        <div><h3>Log into your account</h3></div>

        <div>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:CheckBox ID="RememberMeCbx" runat="server" Text="Remember Me" />
        </div>

        <div>
            <asp:Button ID="LoginBtn" runat="server" Text="Log in" OnClick="LoginBtn_Click" />
        </div>

        <div>
            <asp:Label ID="RegisterLbl" runat="server" Text="Not yet a member?" ForeColor="#808080"></asp:Label>
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" BackColor="#c0c0c0" OnClick="RegisterBtn_Click"/>
        </div>
    </form>
</body>
</html>
