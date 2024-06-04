<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupPage.aspx.cs" Inherits="Project_PSD_LAB.View.UpdateMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <div><h3>Update Makeup</h3></div>

    <div>
        <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="PriceLbl" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="PriceTxt" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="WeightLbl" runat="server" Text="Weight"></asp:Label>
        <asp:TextBox ID="WeightTxt" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="TypeIDLbl" runat="server" Text="Type ID"></asp:Label>
        <asp:TextBox ID="TypeIDTxt" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="BrandIDLbl" runat="server" Text="Brand ID"></asp:Label>
        <asp:TextBox ID="BrandIDTxt" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="red"></asp:Label>
    </div>

    <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
    
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="Back" backcolor="Gray" OnClick="BackBtn_Click"/>
    </div>

</asp:Content>
