<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Mootit.Pizzeria.WebClient.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mootit Pizzeria</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:LinkButton runat="server" ID="LinkButton_Solicitar" Text="Realizar um novo pedido" PostBackUrl="~/NewOrder.aspx"></asp:LinkButton>
        <br />
        <br />
        <div>
            <asp:GridView ID="GridView_Orders" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Nº Pedido" />
                    <asp:BoundField DataField="Customer" HeaderText="Cliente" Visible="false" />
                    <asp:BoundField DataField="Created" HeaderText="Data" />
                    <asp:BoundField DataField="Delivered" HeaderText="Entregue" />
                    <asp:TemplateField HeaderText="Pizzas">
                        <ItemTemplate>
                            <%# ShowPizzas() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bebidas">
                        <ItemTemplate>
                            <%# ShowBeverages() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sobremesas">
                        <ItemTemplate>
                            <%# ShowDesserts() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Saldo Total">
                        <ItemTemplate>
                            <%# ShowTotal() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
