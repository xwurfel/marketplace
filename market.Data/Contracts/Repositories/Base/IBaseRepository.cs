﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.Contracts.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        
        public TEntity Get(int id);

        public void Create(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(int id);

    }
}