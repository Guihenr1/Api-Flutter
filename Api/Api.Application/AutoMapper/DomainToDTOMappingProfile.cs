using Api.Application.DTOs.Product;
using Api.Application.DTOs.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile {
        public DomainToDTOMappingProfile () {
            CreateMap<User, UserDTO> ();
            CreateMap<Product, ProductDTO> ();
        }

    }
}