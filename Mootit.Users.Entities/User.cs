using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mootit.Users.Entities
{
    [DataContract]
    public class User
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Username { get; set; }
    }
}
