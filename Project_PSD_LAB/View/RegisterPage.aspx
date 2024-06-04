<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Project_PSD_LAB.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div><h1>MakeMeUpzz</h1></div>
        <div><h3>Register and be a member</h3></div>

        <div>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTxt" runat="server" TextMode="Email"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="GenderRBList" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="ConfirmationPasswordLbl" runat="server" Text="Confirmation Password"></asp:Label>
            <asp:TextBox ID="ConfirmationPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="DOBLbl" runat="server" Text="Date Of Birth"></asp:Label>
            <asp:TextBox ID="DOBTxt" runat="server" Type="date" TextMode="Date"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
        </div>

        <div>
            <asp:Label ID="LoginLbl" runat="server" Text="Already have an account?" ForeColor="#808080"></asp:Label>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" BackColor="#c0c0c0" OnClick="LoginBtn_Click"/>
        </div>
    </form>
</body>
</html>
