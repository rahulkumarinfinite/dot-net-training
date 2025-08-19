<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NumberOfCust.aspx.cs" Inherits="aspProj.NumberOfCust" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
            <div id="BillCount">
            <asp:Panel ID="pnlCount" runat="server">
    <asp:Label Text="Enter number of bills to add:" runat="server" />
    <asp:TextBox ID="txtBillCount" runat="server" />
                <br />
                <br />
    <asp:Button ID="btnGenerateForm" runat="server" Text="Generate Form" OnClick="btnGenerateForm_Click" />
</asp:Panel>

<hr />

<asp:PlaceHolder ID="phDynamicForm" runat="server" />
<asp:Button ID="btnSubmitBills" runat="server" Text="Submit Bills" OnClick="btnSubmitBills_Click" Visible="false" />
<asp:Label ID="lblMessage" runat="server" ForeColor="Green" />

        </div>
    </form>
</body>
</html>
