using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.Contracts.Repositories.Base
{
    public interface IBaseRepository<TEntity, in TKey> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();

        public TEntity Get(TKey id);

        public void Create(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(TKey id);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

    }
}
