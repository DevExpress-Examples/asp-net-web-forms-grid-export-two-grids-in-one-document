<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxGridView ID="Grid1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="AccessDataSource1" KeyFieldName="CategoryID">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="CategoryID" />
                <dx:GridViewDataTextColumn FieldName="CategoryName" />
                <dx:GridViewDataTextColumn FieldName="Description" />
            </Columns>
        </dx:ASPxGridView>
        <br />
        <dx:ASPxGridView ID="Grid2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="AccessDataSource2" KeyFieldName="EmployeeID">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="EmployeeID" />
                <dx:GridViewDataTextColumn FieldName="LastName" />
                <dx:GridViewDataTextColumn FieldName="FirstName" />
                <dx:GridViewDataTextColumn FieldName="Title" />
            </Columns>
        </dx:ASPxGridView>

        <dx:ASPxButton ID="ExportButton" runat="server" Text="Export both grids" Width="205px" 
            OnClick="ExportButton_Click" />

        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb" 
            SelectCommand="SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]" />
        <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/nwind.mdb" 
            SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title] FROM [Employees]" />
    </form>
</body>
</html>
