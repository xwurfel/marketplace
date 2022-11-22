using market.Domain.Const;
using market.Host.Models.Products;
using Microsoft.AspNetCore.Identity;

namespace market.Host.Models.Users
{
    public class UserModel : IdentityUser
    {
        public UserType UserType { get; set; }

        public List<ProductModel> ProductModels { get; set; }
    }
}
