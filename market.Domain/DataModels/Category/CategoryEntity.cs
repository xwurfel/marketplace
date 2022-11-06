namespace market.Domain.DataModels.Category
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductCategoryModel> Products { get; set; }
    }
}
