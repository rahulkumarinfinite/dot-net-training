<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="aspProj.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          UserName:  <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username" />
            <br />
           Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" />
             <br />
             <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
             <br />
             <br />
             <br />
             <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

        </div>
    </form>
</body>
</html>
