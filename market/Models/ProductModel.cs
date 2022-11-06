using market.Domain.DataModels;

namespace market.Host.Models
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
