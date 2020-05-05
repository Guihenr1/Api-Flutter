using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}