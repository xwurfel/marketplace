using market.Domain.Const;
using market.Host.Models.Products;

namespace market.Host.Models.Users
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
