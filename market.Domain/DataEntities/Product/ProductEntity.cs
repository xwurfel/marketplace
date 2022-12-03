using market.Domain.DataEntities.User;

namespace market.Domain.DataEntities.Product
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public UserEntity Seller { get; set; }
        public List<ProductCategoryModel> Categories { get; set; }
    }
}
