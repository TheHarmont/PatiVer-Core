using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PatiVerCore.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediator();
            services.ConfigureForwarderHeaders();
        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

        private static void ConfigureForwarderHeaders(this IServiceCollection services)
        {

        }
    }
}
