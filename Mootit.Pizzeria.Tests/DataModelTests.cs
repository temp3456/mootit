using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mootit.Pizzeria.Entities;

namespace Mootit.Pizzeria.Tests
{
    [TestClass]
    public class DataModelTests
    {
        [TestMethod]
        [TestCategory("DAL")]
        [Description("This test will validate a simple connection and it will try to list all available products on store")]
        public void Pizzeria_Validate_1()
        {
            using (Service.Store store = new Service.Store())
            {
                var pizzas = store.ListPizzas();
                var beverages = store.ListBeverages();
                var desserts = store.ListDesserts();
            }
        }

        [TestMethod]
        [TestCategory("DAL")]
        [Description("This test will validate some roles on store, such as, if user try to buy more than 2 pizzas")]
        public void Pizzeria_Validate_2()
        {
            using (Service.Store store = new Service.Store())
            {
                Pizza pizzaA = store.GetPizza(1);
                pizzaA.Slice = 1;
                Pizza pizzaB = store.GetPizza(5);
                pizzaB.Slice = 2;
                Pizza pizzaC = store.GetPizza(2);
                pizzaC.Slice = 2;

                Beverage beverage = store.GetBeverage(8);

                Order order = new Order();

                order.Customer = 1;
                order.Pizzas = new Pizza[] { pizzaA, pizzaB, pizzaC };
                order.Beverages = new Beverage[] { beverage };

                var added = store.InsertOrder(order);
            }
        }

        //[TestMethod]
        [TestCategory("DAL")]
        [Description("This test will validate some roles on store, such as, if user try to buy more than 2 pizzas and one of them has more than one slice")]
        public void Pizzeria_Validate_3()
        {
            using (Service.Store store = new Service.Store())
            {

                Order order = new Order();

                order.Customer = 1;

                var added = store.InsertOrder(order);
            }
        }

        [TestMethod]
        [TestCategory("DAL")]
        [Description("Return any order to validade the data integrity")]
        public void Pizzeria_Validate_4()
        {
            using (Service.Store store = new Service.Store())
            {
                var orders = store.GetOrder(1);
            }
        }
    }
}
