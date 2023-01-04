using market.Data.Contracts.Repositories.Base;
using market.Domain.DataEntities.Product;
using market.Domain.DataEntities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.Data.Contracts.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<UserEntity, string>
    {
        public IEnumerable<UserEntity> GetAll();
    }
}
