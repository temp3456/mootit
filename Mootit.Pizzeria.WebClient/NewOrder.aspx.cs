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
    public partial class NewOrder : System.Web.UI.Page
    {
        public class RequestOrder
        {
            public IEnumerable<string[]> Pizzas { get; set; }
            public string[] Beverages { get; set; }
            public string[] Desserts { get; set; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session[Login.SESSION_KEY_PHONE] == null)
                Response.Redirect("~/Login.aspx", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                GenerateOrder();
        }

        protected string ListPizzas()
        {
            List<object> returns = new List<object>();
            StoreClient client = new StoreClient();

            foreach (Pizza pizza in client.ListPizzas())
                returns.Add(new { Id = pizza.Id, Flavor = pizza.Flavor, Description = pizza.Description, Price = pizza.Price });

            return Newtonsoft.Json.JsonConvert.SerializeObject(returns.ToArray());
        }

        protected string ListBeverages()
        {
            List<object> returns = new List<object>();
            StoreClient client = new StoreClient();

            foreach (Beverage beverage in client.ListBeverages())
                returns.Add(new { Id = beverage.Id, Name = beverage.Name, Price = beverage.Price });

            return Newtonsoft.Json.JsonConvert.SerializeObject(returns.ToArray());
        }

        protected string ListDesserts()
        {
            List<object> returns = new List<object>();
            StoreClient client = new StoreClient();

            foreach (Dessert dessert in client.ListDesserts())
                returns.Add(new { Id = dessert.Id, Name = dessert.Name, Price = dessert.Price });

            return Newtonsoft.Json.JsonConvert.SerializeObject(returns.ToArray());
        }

        private void GenerateOrder()
        {
            if (!String.IsNullOrEmpty(this.HiddenField_Params.Value))
            {
                RequestOrder input = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestOrder>(this.HiddenField_Params.Value);

                Order order = new Order()
                {
                    Customer = new AccountsClient().GetCustomerByPhone(Convert.ToInt32(Session[Login.SESSION_KEY_PHONE])).User.Id
                };

                List<Beverage> beverages = new List<Beverage>();
                foreach (string beverage in input.Beverages)
                    beverages.Add(new Beverage()
                    {
                        Id = int.Parse(beverage)
                    });
                List<Dessert> desserts = new List<Dessert>();
                foreach (string dessert in input.Desserts)
                    desserts.Add(new Dessert()
                    {
                        Id = int.Parse(dessert)
                    });

                List<Pizza> pizzas = new List<Pizza>();
                foreach (string[] slices in input.Pizzas)
                    foreach (string slice in slices)
                        pizzas.Add(new Pizza()
                        {
                            Id = int.Parse(slice),
                            Slice = Convert.ToInt16(slices.Length)
                        });

                order.Pizzas = pizzas.ToArray();
                order.Beverages = beverages.ToArray();
                order.Desserts = desserts.ToArray();

                new StoreClient().InsertOrder(order);
            }
        }
    }
}