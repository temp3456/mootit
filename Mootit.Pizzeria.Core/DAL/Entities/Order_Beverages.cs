using System;
using System.Collections.Generic;

namespace Mootit.Pizzeria.Core.DAL.Entities
{
    public partial class Order_Beverages
    {
        public long Id { get; set; }
        public long Id_Order { get; set; }
        public long Id_Beverage { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual Order Order { get; set; }
    }
}
