<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Project_PSD_LAB.View.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <div><h3>Profile Update</h3></div>

    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UsernameTxt" runat="server" Text="" Enabled="false"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTxt" runat="server" Text="" Enabled="false"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="GenderRBList" runat="server" Enabled="false">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
    </div>

    <div>
        <asp:Label ID="DOBLbl" runat="server" Text="Date Of Birth"></asp:Label>
        <asp:TextBox ID="DOBTxt" runat="server" Text="" Type="date" TextMode="Date" Enabled="false"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

    <div>
        <asp:Button ID="EditBtn" runat="server" Text="Edit" OnClick="EditBtn_Click" />
    </div>

   <div>
        <asp:Button ID="CancelBtn" runat="server" Text="Cancel" OnClick="CancelBtn_Click" Visible="false"/>
    </div>

    <div>
        <asp:Button ID="UpdateProfileBtn" runat="server" Text="Update Profile" OnClick="UpdateProfileBtn_Click" Visible="false"/>
    </div>

    <div><h3>Password Update</h3></div>

    <div>
        <asp:Label ID="OldPasswordLbl" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="OldPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="NewPasswordLbl" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="NewPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="PasswordErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    
    <div>
        <asp:Button ID="UpdatePasswordBtn" runat="server" Text="Update Password" OnClick="UpdatePasswordBtn_Click" />
    </div>

</asp:Content>
