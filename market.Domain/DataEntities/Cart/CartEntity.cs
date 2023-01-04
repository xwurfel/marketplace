using market.Domain.DataEntities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.Domain.DataEntities.Cart
{
    public class CartEntity
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
