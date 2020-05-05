using System;
using System.Threading.Tasks;
using Api.Application.DTOs.User;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;

namespace Api.Application.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        readonly ITokenService _tokenService;
        readonly IMapper _mapper;
        public UserService(IUserRepository userRepository
            , ITokenService tokenService
            , IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> Authenticate(UserRequestDTO userDTO)
        {
            var response = new UserResponseDTO();
            var user = _mapper.Map<User>(userDTO);

            var getUser = await _userRepository.Get(user);

            if (getUser == null)
                new Exception("Usuário ou senha incorretos.");

            response.Token = await _tokenService.GenerateToken(getUser);
            response.User = _mapper.Map<UserDTO>(getUser);

            return response;
        }
    }
}