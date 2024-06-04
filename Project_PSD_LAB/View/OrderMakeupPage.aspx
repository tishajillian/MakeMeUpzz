<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="OrderMakeupPage.aspx.cs" Inherits="Project_PSD_LAB.View.OrderMakeupPage" EnableEventValidation="false" EnableViewState="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div id="MakeupListContainer" runat="server">
     <div>
        <h2>
            Order Makeup
        </h2>
    </div>
    <asp:GridView ID="MakeupListGV" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
            <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
            <asp:BoundField DataField="MakeupWeight" HeaderText="Weight (gram)" SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupTypeName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrandName" />
            <asp:TemplateField HeaderText="Order">
                <ItemTemplate>
                    <asp:TextBox ID="QuantityTextBox" runat="server" Text="0" BorderColor="WhiteSmoke" Style="border-color: dimgrey;"></asp:TextBox>
                    <asp:Button ID="OrderButton" runat="server" Text="Order" CommandArgument='<%# Bind("MakeupID") %>' OnClick="OrderButton_Click"/>                  
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
    </div>

    <asp:Label ID="errorMsgLbl" runat="server" Text="" ForeColor="Red"></asp:Label>

    <div id="CartListContainer" runat="server">
    <div>
        <h2>
            Your Cart
        </h2>
    </div>
    <asp:GridView ID="CartGV" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
        <asp:BoundField DataField="Weight" HeaderText="Weight (gram)" SortExpression="MakeupWeight" />
        <asp:BoundField DataField="TypeName" HeaderText="Type" SortExpression="TypeName" />
        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
    </Columns>
    </asp:GridView>
    
     <%--<asp:Label ID="DebugLbl" runat="server" Text=""></asp:Label>--%>

     <div>
         <asp:Label ID="CartLbl" runat="server" Text="" Visible="false"></asp:Label>
     </div>
     
    <div>
        <asp:Button ID="ClearCartButton" runat="server" Text="Clear Cart" OnClick="ClearCartButton_Click" />
        <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" BackColor="GreenYellow"/>
    </div>
    
    <div>
        <asp:Label ID="CheckoutLbl" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>

    </div>

</asp:Content>
