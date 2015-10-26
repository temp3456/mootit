using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mootit.Pizzeria.Core.DAL.Entities
{
    public partial class Order_Desserts
    {
        public long Id { get; set; }
        public long Id_Order { get; set; }
        public long Id_Dessert { get; set; }

        public virtual Dessert Desserts { get; set; }
        public virtual Order Orders { get; set; }
    }
}
