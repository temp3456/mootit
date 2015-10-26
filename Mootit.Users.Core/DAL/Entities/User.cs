using System;
using System.Collections.Generic;

namespace Mootit.Users.Core.DAL.Entities
{
    public partial class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
