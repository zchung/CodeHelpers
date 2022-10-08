namespace $safeprojectname$.Extensions
{
    public static class WebApiExtensions
    {
        public static IServiceCollection SetupWebApi(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}