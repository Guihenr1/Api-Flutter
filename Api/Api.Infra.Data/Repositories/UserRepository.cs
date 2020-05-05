using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> Get(User user)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "employee" });
            return users.Where(x => x.Username.ToLower() == user.Username.ToLower() && x.Password == user.Password).FirstOrDefault();
        }
    }
}