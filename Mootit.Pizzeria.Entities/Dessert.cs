using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mootit.Pizzeria.Entities
{
    [DataContract]
    public class Dessert
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
