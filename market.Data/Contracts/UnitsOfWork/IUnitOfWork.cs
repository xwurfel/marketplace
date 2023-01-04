using market.Data.Contracts.Repositories.Categories;
using market.Data.Contracts.Repositories.Products;
using market.Data.Contracts.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.Contracts.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        public IProductRepository Products { get; }
        public IUserRepository Users { get; } 
        public ICategoryRepository Categories { get; }
    }
}
