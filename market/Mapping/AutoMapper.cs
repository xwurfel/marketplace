using AutoMapper;
using market.Domain.DataModels.Product;
using market.Host.Models;

namespace market.Host.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductEntity, ProductModel>();
        }
    }
}
