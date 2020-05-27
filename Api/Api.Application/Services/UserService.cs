using System;
using System.Threading.Tasks;
using Api.Application.DTOs.User;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Enums;
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
        public async Task<UserResponseDTO> Authenticate(UserRequestDTO userRequest)
        {
            var userAuthenticate = new UserResponseDTO();
            var user = _mapper.Map<User>(userRequest);

            var getUser = await _userRepository.Get(user);

            if (getUser == null)
                throw new Exception("Usuário ou senha incorretos.");
            
            userAuthenticate.Token = await _tokenService.GenerateToken(user);
            userAuthenticate.User = _mapper.Map<UserDTO>(user);

            return userAuthenticate;
        }
    }
}