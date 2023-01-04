using market.Data.Context;
using market.Data.Contracts.Repositories.Categories;
using market.Data.Contracts.Repositories.Products;
using market.Data.Contracts.Repositories.Users;
using market.Data.Contracts.UnitsOfWork;
using market.Data.Repositories.Categories;
using market.Data.Repositories.Products;
using market.Data.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Users = new UserRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public IProductRepository Products { get; private set; } 

        public IUserRepository Users { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
