using market.Data.Context;
using market.Data.Contracts.Repositories.Categories;
using market.Domain.DataEntities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(CategoryEntity entity)
        {
            _context.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            _context.Categories.Remove(_context.Categories.FirstOrDefault(c => c.Id == id));
        }

        public IEnumerable<CategoryEntity> Find(Expression<Func<CategoryEntity, bool>> expression)
        {
            return _context.Categories.Where(expression);
        }

        public CategoryEntity Get(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Update(CategoryEntity entity)
        {
            _context.Categories.Update(entity);
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return _context.Categories;
        }
    }
}
