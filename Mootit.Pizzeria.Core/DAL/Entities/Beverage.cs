using System;
using System.Collections.Generic;

namespace Mootit.Pizzeria.Core.DAL.Entities
{
    public partial class Beverage
    {
        public Beverage()
        {
            this.Order_Beverages = new List<Order_Beverages>();
        }
        public long Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order_Beverages> Order_Beverages { get; set; }
    }
}
