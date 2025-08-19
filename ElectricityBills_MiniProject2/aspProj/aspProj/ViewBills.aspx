<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBills.aspx.cs" Inherits="aspProj.ViewBills" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
               <asp:Label Text="Enter Number of Bills to Retrieve:" runat="server" />
<asp:TextBox ID="txtCount" runat="server" /><br />

<asp:Button ID="btnFetch" runat="server" Text="Fetch Bills" OnClick="btnFetch_Click" /><br />
<asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true" />

        </div>
    </form>
</body>
</html>
