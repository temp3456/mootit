using System;
using System.Collections.Generic;

namespace Mootit.Pizzeria.Core.DAL.Entities
{
    public partial class Order
    {
        public Order()
        {
            this.Order_Beverages = new List<Order_Beverages>();
            this.Order_Desserts = new List<Order_Desserts>();
            this.Order_Pizzas = new List<Order_Pizzas>();
            this.Created = DateTime.Now;
        }

        public long Id { get; set; }
        public long Customer { get; set; }
        public DateTime Created { get; set; }
        public DateTime Delivered { get; set; }

        public virtual ICollection<Order_Beverages> Order_Beverages { get; set; }
        public virtual ICollection<Order_Desserts> Order_Desserts { get; set; }
        public virtual ICollection<Order_Pizzas> Order_Pizzas { get; set; }
    }
}
