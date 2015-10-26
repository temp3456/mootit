using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mootit.Pizzeria.Entities
{
    [DataContract]
    public class Pizza
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string Flavor { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public short Slice { get; set; }
    }
}
