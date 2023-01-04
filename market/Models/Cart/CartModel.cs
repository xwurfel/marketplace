using market.Domain.DataEntities.Cart;

namespace market.Host.Models.Cart
{
    public class CartModel
    {
        public List<CartEntity> CartItems { get; set; }
        public int CartTotal { get; set; }
    }
}
