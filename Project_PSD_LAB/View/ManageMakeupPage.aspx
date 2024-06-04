<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="ManageMakeupPage.aspx.cs" Inherits="Project_PSD_LAB.View.ManageMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <div><h3>Manage Makeups</h3></div>
    <div id="MakeupList">
        <asp:GridView ID="MakeupListGV" runat="server" AutoGenerateColumns="False" DataKeyNames="MakeupID" OnRowUpdating="MakeupListGV_RowUpdating" OnRowDeleting="MakeupListGV_RowDeleting">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupTypeID" HeaderText="Makeup Type ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupBrandID" HeaderText="Makeup Brand ID" SortExpression="MakeupBrandID" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />            
                        <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:Button ID="InsertMakeupBtn" runat="server" Text="Insert New Makeup" OnClick="InsertMakeupBtn_Click" />

    <div><h3>Manage Makeup Types</h3></div>
    <div id="MakeupTypeList">
        <asp:GridView ID="MakeupTypeListGV" runat="server" AutoGenerateColumns="False" DataKeyNames="MakeupTypeID" OnRowUpdating="MakeupTypeListGV_RowUpdating" OnRowDeleting="MakeupTypeListGV_RowDeleting">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="Makeup Type ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupTypeName" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />            
                        <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:Button ID="InsertMakeupTypeBtn" runat="server" Text="Insert New Makeup Type" OnClick="InsertMakeupTypeBtn_Click" />

    <div><h3>Manage Makeup Brands</h3></div>
    <div id="MakeupBrandList">
        <asp:GridView ID="MakeupBrandListGV" runat="server" AutoGenerateColumns="False" DataKeyNames="MakeupBrandID" OnRowUpdating="MakeupBrandListGV_RowUpdating" OnRowDeleting="MakeupBrandListGV_RowDeleting">
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="Makeup Brand ID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Makeup Brand Rating" SortExpression="MakeupBrandRating" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />            
                        <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>    
            </Columns>

        </asp:GridView>
    </div>

    <asp:Button ID="InsertMakeupBrandBtn" runat="server" Text="Insert New Makeup Brand" OnClick="InsertMakeupBrandBtn_Click" />


</asp:Content>
