using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace $safeprojectname$.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}