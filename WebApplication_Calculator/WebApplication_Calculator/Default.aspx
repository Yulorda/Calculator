<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication_Calculator.WebForm1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Калькулятор</title>
</head>
<body>
    <div>
        <h3>Калькулятор</h3>
        <form id="form1" runat="server">
            <table>
                <tr><td><p>Введите выражение:</p></td>
                <td><asp:TextBox ID="ExpressionField" runat="server"></asp:TextBox></td></tr>
                <tr><td><asp:Button ID="Calculate" Width="100" Text="Рассчитать" runat="server" OnClick="Calculate_Click"></asp:Button></td>
                <td><asp:Label ID="Output" Text="Результат" runat="server"></asp:Label></td></tr>
            </table>
        </form>
    </div>
</body>
</html>
