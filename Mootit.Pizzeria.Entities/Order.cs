using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mootit.Pizzeria.Entities
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long Customer { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
        [DataMember]
        public DateTime Delivered { get; set; }
        [DataMember]
        public Pizza[] Pizzas { get; set; }
        [DataMember]
        public Dessert[] Desserts { get; set; }
        [DataMember]
        public Beverage[] Beverages { get; set; }
        [DataMember]
        public double PizzaCost { get; set; }
        [DataMember]
        public double DessertCost { get; set; }
        [DataMember]
        public double BeverageCost { get; set; }
    }
}
