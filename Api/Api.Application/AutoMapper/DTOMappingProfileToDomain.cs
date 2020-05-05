using Api.Application.DTOs.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Application.AutoMapper
{
    public class DTOMappingProfileToDomain : Profile {
        public DTOMappingProfileToDomain () {
            CreateMap<UserRequestDTO, User> ();
        }
    }
}