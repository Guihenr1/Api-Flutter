using Api.Application.AutoMapper;
using Api.Application.Interfaces;
using Api.Application.Services;
using Api.Domain.Interfaces;
using Api.Infra.Data.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSetupIoC (this IServiceCollection services, IConfiguration config, bool isDev) {
            services.ConfigureAutoMapper ();
            services.RegisterServices ();
            services.AddRepositories ();
            return services;
        }
        
        private static void ConfigureAutoMapper (this IServiceCollection services) {
            var mapperConfig = AutoMapperConfig.RegisterMappings ();
            services.AddAutoMapper (typeof (DomainToDTOMappingProfile), typeof (DTOMappingProfileToDomain));
        }

        private static void RegisterServices (this IServiceCollection services) {
            services.AddScoped<ITokenService, TokenService> ();
            services.AddScoped<IUserService, UserService> ();
            services.AddScoped<IProductService, ProductService> ();

            // Service Validators
            // services.AddScoped<ISegmentServiceValidator, SegmentServiceValidator> ();
        }

        private static void AddRepositories (this IServiceCollection services) {
            services.AddScoped<IUserRepository, UserRepository> ();
            services.AddScoped<IProductRepository, ProductRepository> ();
        }
    }
}