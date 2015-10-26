using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mootit.Pizzeria.Service.Store;
using Mootit.Users.Service.Accounts;

namespace Mootit.Pizzeria.WebClient
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session[Login.SESSION_KEY_PHONE] == null)
                Response.Redirect("~/Login.aspx", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mootit.Pizzeria.Service.Store.StoreClient client = new Service.Store.StoreClient();

                client.Sync();

                Customer customer = new AccountsClient().GetCustomerByPhone(Convert.ToInt32(Session[Login.SESSION_KEY_PHONE]));

                GridView_Orders.DataSource = client.ListCustomerOrders(customer.User.Id);
                GridView_Orders.DataBind();
            }
        }
        
        protected string ShowTotal()
        {
            double total = 0;
            Order order = this.GetDataItem() as Order;
            total += order.PizzaCost;
            total += order.BeverageCost;
            total += order.DessertCost;

            return total.ToString("N2");
        }

        protected string ShowPizzas()
        {
            int temp;
            string pizzas = String.Empty;
            Order order = this.GetDataItem() as Order;

            if (order.Pizzas != null)
            {
                IOrderedEnumerable<Pizza> pizzasOrdered = order.Pizzas.OrderBy(i => i.Slice);

                foreach (Pizza pizza in pizzasOrdered.Where(i => i.Slice == 1))
                    pizzas += "[Inteira] " + pizza.Flavor + " (" + pizza.Description + " ): " + pizza.Price + "<br />";
                pizzas += "<br />";
                temp = 0;
                foreach (Pizza pizza in pizzasOrdered.Where(i => i.Slice == 2))
                {
                    pizzas += "[Meia] " + pizza.Flavor + " (" + pizza.Description + " ): " + pizza.Price + "<br />";
                    if (++temp % 2 == 0) pizzas += "<br />";
                }

                temp = 0;
                foreach (Pizza pizza in pizzasOrdered.Where(i => i.Slice == 3))
                {
                    pizzas += "[Um terço] " + pizza.Flavor + " (" + pizza.Description + " ): " + pizza.Price + "<br />";
                    if (++temp % 3 == 0) pizzas += "<br />";
                }

                temp = 0;
                foreach (Pizza pizza in pizzasOrdered.Where(i => i.Slice == 4))
                {
                    pizzas += "[Um quarto] " + pizza.Flavor + " (" + pizza.Description + " ): " + pizza.Price + "<br />";
                    if (++temp % 4 == 0) pizzas += "<br />";
                }

            }
            return pizzas;
        }

        protected string ShowBeverages()
        {
            string beverages = String.Empty;

            Order order = this.GetDataItem() as Order;

            if (order.Beverages != null)
                foreach (Beverage beverage in order.Beverages)
                    beverages += beverage.Name + ": " + beverage.Price + "<br />";

            return beverages;
        }

        protected string ShowDesserts()
        {
            string desserts = String.Empty;

            Order order = this.GetDataItem() as Order;

            if (order.Desserts != null)
                foreach (Dessert dessert in order.Desserts)
                    desserts += dessert.Name + ": " + dessert.Price + "<br />";

            return desserts;
        }
    }
}