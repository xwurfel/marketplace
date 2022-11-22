using market.Domain.DataEntities.Category;
using market.Domain.DataEntities.Product;

namespace market.Domain.DataEntities
{
    public class ProductCategoryModel
    {
        public CategoryEntity Category { get; set; }
        public ProductEntity Product { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
