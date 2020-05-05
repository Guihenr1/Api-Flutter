using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IUserRepository
    {
         Task<User> Get(User user);
    }
}