using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Persistence.Context;
using PatiVerCore.Persistence.Repositories;

namespace PatiVerCore.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        private const string connectionStringSectionName = "PatiVer";

        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(connectionStringSectionName);

            services.AddDbContext<AppDBContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.
                AddScoped<ILocalDataRepository, LocalDataRepository>();
        }
    }
}
