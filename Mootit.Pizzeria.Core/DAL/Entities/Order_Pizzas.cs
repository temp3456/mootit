using System;
using System.Collections.Generic;

namespace Mootit.Pizzeria.Core.DAL.Entities
{
    public partial class Order_Pizzas
    {
        public long Id { get; set; }
        public long Id_Order { get; set; }
        public long Id_Pizza { get; set; }
        public short Slice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
