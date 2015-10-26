using System;
using System.Collections.Generic;

namespace Mootit.Pizzeria.Core.DAL.Entities
{
    public partial class Dessert
    {
        public Dessert()
        {
            this.Order_Desserts = new List<Order_Desserts>();
        }
        public long Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order_Desserts> Order_Desserts { get; set; }
    }
}
