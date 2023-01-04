using market.Data.Contracts.Repositories.Base;
using market.Domain.DataEntities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.Contracts.Repositories.Categories
{
    public interface ICategoryRepository : IBaseRepository<CategoryEntity, int>
    {
        public IEnumerable<CategoryEntity> GetAll();
    }
}
