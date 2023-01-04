using market.Data.Context;
using market.Data.Contracts.Repositories.Users;
using market.Domain.DataEntities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.Repositories.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(UserEntity entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(string id)
        {
            _context.Users.Remove(_context.Users.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public IEnumerable<UserEntity> Find(Expression<Func<UserEntity, bool>> expression)
        {
            return _context.Users.Where(expression);
        }

        public UserEntity Get(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _context.Users.AsEnumerable();
        }

        public void Update(UserEntity entity)
        {
            _context.Users.Update(entity);
        }
    }
}
