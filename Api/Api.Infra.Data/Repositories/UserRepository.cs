using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repositories
{
    public class UserRepository : PostgresContext<User>, IUserRepository
    {
        public async Task<User> Get(User user)
        {
            var result = await QueryFirstOrDefault<User>(
                $@"SELECT * FROM ""User"" WHERE ""UserName"" = @Username AND ""Password"" = @Password", 
                new{ user.Username, user.Password});
            return result;
        }
    }
}