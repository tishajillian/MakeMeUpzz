<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionReportPage.aspx.cs" Inherits="Project_PSD_LAB.View.TransactionReportPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <div><h3>Transaction Report</h3></div>

    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </div>

    <div>
        <asp:Label ID="DescLbl" runat="server" Text="There is no transaction history yet at this moment!" Visible="false"></asp:Label>
    </div>
</asp:Content>
