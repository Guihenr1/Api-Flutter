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
        private UserResponseDTO userAuthenticate { get; set; }
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
            userAuthenticate = new UserResponseDTO();
            var user = _mapper.Map<User>(userRequest);

            var getUser = await _userRepository.Get(user);

            if (getUser == null)
                UserInvalid();
            
            await InsertToken(getUser);
            await InsertUser(getUser);

            return userAuthenticate;
        }

        void UserInvalid()
        {
            throw new Exception("Usuário ou senha incorretos.");
        }
    
        async Task InsertToken(User user) {
            userAuthenticate.Token = await _tokenService.GenerateToken(user);
        }

        async Task InsertUser(User user) {
            userAuthenticate.User = _mapper.Map<UserDTO>(user);
        }
    }
}