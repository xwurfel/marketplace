using market.Domain.DataEntities;
using market.Host.Models.Users;

namespace market.Host.Models.Products
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public UserModel Seller { get; set; }
        public int SellerId { get; set; }

        public List<ProductCategoryModel> Categories { get; set; }
    }
}
