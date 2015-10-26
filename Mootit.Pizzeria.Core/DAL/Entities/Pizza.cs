using System;
using System.Collections.Generic;

namespace Mootit.Pizzeria.Core.DAL.Entities
{
    public partial class Pizza
    {
        public Pizza()
        {
            this.Order_Pizzas = new List<Order_Pizzas>();
        }
        public long Id { get; set; }
        public double Price { get; set; }
        public string Flavor { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order_Pizzas> Order_Pizzas { get; set; }
    }
}
