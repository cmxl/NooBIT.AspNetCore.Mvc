using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace NooBIT.AspNetCore.Mvc.AutoMapper
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddAutoMapperWithValidation(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            Mapper.AssertConfigurationIsValid();
            return services;
        }
    }
}