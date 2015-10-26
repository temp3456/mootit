<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCustomer.aspx.cs"
    Inherits="Mootit.Pizzeria.WebClient.RegisterCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register customer</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Register customer
        </h1>
        Telefone Contato:
        <asp:TextBox runat="server" ID="TextBox_Phone"></asp:TextBox><br />
        Nome completo:
        <asp:TextBox runat="server" ID="TextBox_FullName"></asp:TextBox><br />
        Endereço:
        <asp:TextBox runat="server" ID="TextBox_Address"></asp:TextBox><br />
        Email:
        <asp:TextBox runat="server" ID="TextBox_UserName"></asp:TextBox><br />
        <br />
        <asp:Button runat="server" ID="Button_Register" Text="Registrar" />
        <br />
        <br />
        <asp:Label runat="server" ID="Label_Response"></asp:Label>
    </div>
    </form>
</body>
</html>
