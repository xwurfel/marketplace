﻿namespace market.Models.DataModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductCategoryModel> Products { get; set; }
    }
}
