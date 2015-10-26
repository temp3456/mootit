<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewOrder.aspx.cs" Inherits="Mootit.Pizzeria.WebClient.NewOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mootit Pizzeria</title>
    <script src="../js/JQuery.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Mootit = new Object();
        Mootit.Products = {
            Pizzas: JSON.parse('<%= ListPizzas() %>'),
            Beverages: JSON.parse('<%= ListBeverages() %>'),
            Desserts: JSON.parse('<%= ListDesserts() %>')
        };

        $(document).ready(function () {
            $('#addPizza').on('click', function () {
                var elemento = $('<div>Total (R$): <span></span><br /><select></select></div>');
                var pizzas = elemento.find('select');
                pizzas.append('<option value="">Escolha o sabor</option>');
                for (var i = 0; i < Mootit.Products.Pizzas.length; i++) {
                    pizzas.append('<option value="' + Mootit.Products.Pizzas[i].Price + '" id=' + Mootit.Products.Pizzas[i].Id + '>' + '[R$ ' + Mootit.Products.Pizzas[i].Price + '] - ' + Mootit.Products.Pizzas[i].Flavor + ' (' + Mootit.Products.Pizzas[i].Description + ')</option>');
                }
                elemento.append('<br />');
                elemento.append(pizzas.clone());
                elemento.append('<br />');
                elemento.append(pizzas.clone());
                elemento.append('<br />');
                elemento.append(pizzas.clone());
                var removePizza = $('<a href="#">Remover Pizza</a>');
                removePizza.on('click', function () {
                    elemento.remove();
                });
                elemento.append('<br />');
                elemento.append(removePizza);

                $('#pizzasCollection').append(elemento);
                elemento.append('<br /><br/>');

                elemento.find('select').on('change', function () {
                    var max = 0;
                    elemento.find('select').each(function (i) {
                        if (this.value > max)
                            max = this.value;
                    });

                    elemento.find('span').text(max);
                });
            });

            $('#addBeverage').on('click', function () {
                var elemento = $('<div><select></select></div>');
                var beverages = elemento.find('select');
                beverages.append('<option value="">Escolha a bebida</option>');
                for (var i = 0; i < Mootit.Products.Beverages.length; i++) {
                    beverages.append('<option value="' + Mootit.Products.Beverages[i].Price + '" id=' + Mootit.Products.Beverages[i].Id + '>' + '[R$ ' + Mootit.Products.Beverages[i].Price + '] - ' + Mootit.Products.Beverages[i].Name + '</option>');
                }
                var remove = $('<a href="#">Remover bebida</a>');
                remove.on('click', function () {
                    elemento.remove();
                });
                elemento.append('<br />');
                elemento.append(remove);

                $('#beveragesCollection').append(elemento);
                elemento.append('<br />');
            });
            $('#addDessert').on('click', function () {
                var elemento = $('<div><select></select></div>');
                var desserts = elemento.find('select');
                desserts.append('<option value="">Escolha a sobremesa</option>');
                for (var i = 0; i < Mootit.Products.Desserts.length; i++) {
                    desserts.append('<option value="' + Mootit.Products.Desserts[i].Price + '" id=' + Mootit.Products.Desserts[i].Id + '>' + '[R$ ' + Mootit.Products.Desserts[i].Price + '] - ' + Mootit.Products.Desserts[i].Name + '</option>');
                }
                var remove = $('<a href="#">Remover sobremesa</a>');
                remove.on('click', function () {
                    elemento.remove();
                });
                elemento.append('<br />');
                elemento.append(remove);

                $('#dessertsCollection').append(elemento);
                elemento.append('<br />');
            });

            $('#submitOrder').on('click', function () {
                var params = {
                    Pizzas: new Array(),
                    Beverages: new Array(),
                    Desserts: new Array()
                };

                $('#pizzasCollection').children().each(function (i, p) {
                    var choosen = new Array();
                    $(this).find('select').each(function (h, f) {
                        var id = $(f).find(':selected').get(0).id;
                        if (id)
                            choosen.push(id);
                    });
                    if (choosen.length > 0)
                        params.Pizzas.push(choosen);
                });

                $('#beveragesCollection').find('select').each(function () {
                    var id = $(this).find(':selected').get(0).id;
                    if (id)
                        params.Beverages.push(id);
                });

                $('#dessertsCollection').find('select').each(function () {
                    var id = $(this).find(':selected').get(0).id;
                    if (id)
                        params.Desserts.push(id);
                });

                $('#HiddenField_Params').val(JSON.stringify(params));

                __doPostBack('HiddenField_Params');
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
    <asp:LinkButton PostBackUrl="~/Main.aspx" Text="Voltar" runat="server" ID="LinkButton_Back"></asp:LinkButton>
        <asp:HiddenField runat="server" ID="HiddenField_Params" ClientIDMode="Static" />
        <h1>
            Realizar novo pedido
        </h1>
        Adicionar ao pedido: <a id="addPizza" href="#">Pizza</a> <a id="addBeverage" href="#">
            Bebida</a> <a id="addDessert" href="#">Sobremesa</a>
        <br />
        <br />
        <div id="pizzasCollection">
        </div>
        <div id="beveragesCollection">
        </div>
        <br />
        <div id="dessertsCollection">
        </div>
        <br />
        <button id="submitOrder" type="button">
            Finalizar pedido</button>
    </div>
    </form>
</body>
</html>
