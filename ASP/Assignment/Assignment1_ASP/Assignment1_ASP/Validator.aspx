
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1_ASP.Validator" %>



<!DOCTYPE html>
<html>
<head runat="server">
    <title>Validator</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>User Information</h2>

        Name: <asp:TextBox ID="txtName" runat="server" /><br />
        Family Name: <asp:TextBox ID="txtFamilyName" runat="server" /><br />
        Address: <asp:TextBox ID="txtAddress" runat="server" /><br />
        City: <asp:TextBox ID="txtCity" runat="server" /><br />
        Zip Code: <asp:TextBox ID="txtZip" runat="server" /><br />
        Phone: <asp:TextBox ID="txtPhone" runat="server" /><br />
        Email: <asp:TextBox ID="txtEmail" runat="server" /><br /><br />

        <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" /><br /><br />
        <asp:Label ID="lblResult" runat="server" ForeColor="Red" />
    </form>
</body>
</html>



