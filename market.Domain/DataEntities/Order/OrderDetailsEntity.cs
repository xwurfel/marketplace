﻿using market.Domain.DataEntities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.Domain.DataEntities.Order
{
    public class OrderDetailsEntity
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public virtual ProductEntity Product { get; set; }
        public virtual OrderEntity Order { get; set; }
    }
}
