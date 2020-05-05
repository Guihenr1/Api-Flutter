using System.Threading.Tasks;
using Api.Application.DTOs.User;

namespace Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> Authenticate(UserRequestDTO userDTO);
    }
}