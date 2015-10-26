<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mootit.Pizzeria.WebClient.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mootit Pizzeria</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Pizzas delivery</h1>
        <br />
        Digite seu telefone:
        <asp:TextBox runat="server" ID="TextBox_Phone"></asp:TextBox><asp:Button runat="server"
            ID="Button_Entrar" Text="Entrar" />
        <br />
        <br />
        <asp:Label runat="server" ID="Label_Response"></asp:Label>
    </div>
    </form>
</body>
</html>
