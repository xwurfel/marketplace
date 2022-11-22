using AutoMapper;
using market.Domain.DataEntities.Product;
using market.Domain.DataEntities.User;
using market.Host.Models.Products;
using market.Host.Models.Users;

namespace market.Host.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();
        }
    }
}
