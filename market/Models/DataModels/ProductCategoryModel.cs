namespace market.Models.DataModels
{
    public class ProductCategoryModel
    {
        public CategoryModel Category { get; set; }
        public ProductModel Product { get; set; }

        public int ProductId { get; set; }
        public int CategoryID { get; set; }
    }
}
