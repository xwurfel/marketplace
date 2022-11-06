using market.Domain.Const;
using market.Domain.DataModels.Product;

namespace market.Domain.DataModels.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }

        public List<ProductEntity> ProductModels { get; set; }
    }
}
