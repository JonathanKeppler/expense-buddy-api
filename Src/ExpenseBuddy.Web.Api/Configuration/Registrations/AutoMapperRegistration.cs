using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExpenseBuddy.Configuration.Registrations
{
    public static class AutoMapperRegistration
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            var assembliesToRegister = new[]
            {
                typeof(Startup).Assembly
            };

            var mapperConfiguration = GetMapperConfiguration(assembliesToRegister);

            services.AddSingleton<IMapper>(new Mapper(mapperConfiguration));

            return services;
        }

        public static IConfigurationProvider GetMapperConfiguration(ICollection<Assembly> assembliesToRegister)
        {
            var type = typeof(Profile);

            var mapperConfigurationExpression = new MapperConfigurationExpression
            {
                ShouldUseConstructor = ci => !ci.IsStatic && ci.IsPublic
            };

            foreach (var assembly in assembliesToRegister)
            {
                var profiles = assembly
                    .GetTypes()
                    .Where(p => typeof(Profile).IsAssignableFrom(p))
                    .Select(t => (Profile)Activator.CreateInstance(t));

                mapperConfigurationExpression.AddProfiles(profiles);
            }

            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);
            mapperConfiguration.AssertConfigurationIsValid();

            return mapperConfiguration;
        }
    }
}
