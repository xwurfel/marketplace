using market.Domain.DataModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.Contracts.Repositories.Products
{
    public interface IProductRepository : IBaseRepository<ProductEntity> { }
}
