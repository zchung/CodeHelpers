using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using $safeprojectname$.Constants;
using System.Reflection;

namespace $safeprojectname$.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection SetupExternal(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services
                .SetupExternalMediator()
                .SetupHttpClients(configurationManager);

            return services;
        }

        public static IServiceCollection SetupExternalMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection SetupHttpClients(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddHttpClient(ApiNameConstants.API_NAME, config =>
            {
                config.BaseAddress = configurationManager.GetServiceUri(ApiNameConstants.API_NAME);
            });
            return services;
        }
    }
}