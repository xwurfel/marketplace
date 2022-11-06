using market.Domain.DataModels.Category;
using market.Domain.DataModels.Product;

namespace market.Domain.DataModels
{
    public class ProductCategoryModel
    {
        public CategoryEntity Category { get; set; }
        public ProductEntity Product { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
