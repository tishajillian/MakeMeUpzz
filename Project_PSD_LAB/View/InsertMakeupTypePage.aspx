<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupTypePage.aspx.cs" Inherits="Project_PSD_LAB.View.InsertMakeupTypePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <div><h3>Insert New Makeup Type</h3></div>

    <div>
        <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="red"></asp:Label>
    </div>

    <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click" />

    <div>
        <asp:Button ID="BackBtn" runat="server" Text="Back" backcolor="Gray" OnClick="BackBtn_Click"/>
    </div>
</asp:Content>
