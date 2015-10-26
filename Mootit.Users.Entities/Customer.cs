using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mootit.Users.Entities
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public int PhoneNumer { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Fullname { get; set; }
    }
}
