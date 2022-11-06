using market.Domain.DataModels.User;

namespace market.Domain.DataModels.Product
{
    public class ProductEntity
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
