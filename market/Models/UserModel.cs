﻿using market.Domain.Const;

namespace market.Host.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }

        public List<ProductModel> ProductModels { get; set; }
    }
}
