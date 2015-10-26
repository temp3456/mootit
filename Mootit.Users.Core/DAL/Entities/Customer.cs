using System;
using System.Collections.Generic;

namespace Mootit.Users.Core.DAL.Entities
{
    public partial class Customer
    {
        public long Id_User { get; set; }
        public int PhoneNumer { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }
        public virtual User Users { get; set; }
    }
}
