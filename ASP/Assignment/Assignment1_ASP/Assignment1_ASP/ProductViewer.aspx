<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductViewer.aspx.cs" Inherits="Assignment1_ASP.ProductViewer" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Product Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Select a Product</h2>

        <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" />
        <br /><br />

        <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />
        <br /><br />

        <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />
        <br /><br />

        <asp:Label ID="lblPrice" runat="server" Font-Bold="true" ForeColor="Green" />
    </form>
</body>
</html>

