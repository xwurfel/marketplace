using market.Data.Context;
using market.Data.Contracts.Repositories.Products;
using market.Domain.DataEntities.Product;
using System.Linq.Expressions;

namespace market.Data.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _context.Products.Select(x => x);
        }
        public ProductEntity Get(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Create(ProductEntity entity)
        {
            _context.Products.Add(entity);
        }
        public void Update(ProductEntity entity)
        {
            _context.Products.Update(entity);
        }

        public void Delete(int id)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public IEnumerable<ProductEntity> Find(Expression<Func<ProductEntity, bool>> expression)
        {
            return _context.Products.Where(expression);
        }

        public IEnumerable<ProductEntity> FindSkipTake(Expression<Func<ProductEntity, bool>> expression, int skip, int take)
        {
            return _context.Products.Where(expression).Skip(skip).Take(take);
        }

    }
}
