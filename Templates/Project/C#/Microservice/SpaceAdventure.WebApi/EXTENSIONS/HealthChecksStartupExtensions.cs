namespace $safeprojectname$.Extensions
{
    public static class HealthChecksStartupExtensions
    {
        public static IServiceCollection SetupHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }

        public static WebApplication SetupHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("health");
            return app;
        }
    }
}