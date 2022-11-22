using market.Domain.Const;
using market.Domain.DataEntities.Product;
using Microsoft.AspNetCore.Identity;

namespace market.Domain.DataEntities.User
{
    public class UserEntity : IdentityUser
    {
        public UserType UserType { get; set; }

        public List<ProductEntity> ProductModels { get; set; }
    }
}
