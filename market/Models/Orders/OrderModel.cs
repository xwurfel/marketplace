namespace market.Host.Models.Orders
{
    public class OrderModel
    {
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public IEnumerable<int> ProductsId { get; set; }
    }
}
