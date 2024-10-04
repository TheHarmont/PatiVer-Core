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
        private const string RedisConnectionString = "Redis";

        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedis(configuration);
            services.AddServices();
        }

        private static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(RedisConnectionString);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
            });
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<ICacheService, CacheService>();
        }
    }
}
