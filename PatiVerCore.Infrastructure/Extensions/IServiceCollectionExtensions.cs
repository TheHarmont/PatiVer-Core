using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatiVerCore.Application.Interfaces;
using PatiVerCore.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        private const string redisSectionName = "Redis";
        private const string configSectionName = "Configuration";
        private const string instanceSectionName = "InstanceName";

        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedis(configuration);
            services.AddServices();
        }

        private static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConfig = configuration.GetSection(redisSectionName);
            var config = redisConfig[configSectionName];
            var instanceName = redisConfig[instanceSectionName];

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config;
                options.InstanceName = instanceName;
            });
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<ICacheService, CacheService>();
        }
    }
}
