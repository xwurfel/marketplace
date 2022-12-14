using market.Data.Contracts.Repositories.Base;
using market.Domain.DataEntities.Product;
using System.Linq.Expressions;

namespace market.Data.Contracts.Repositories.Products
{
    public interface IProductRepository : IBaseRepository<ProductEntity, int> 
    {
        public IEnumerable<ProductEntity> GetAll();
        public IEnumerable<ProductEntity> FindSkipTake(Expression<Func<ProductEntity, bool>> expression, int skip, int take);
    }
}
