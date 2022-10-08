using System.Reflection;

namespace $safeprojectname$.Extensions
{
    public static class SwaggerStartupExtensions
    {
        public static IServiceCollection SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static WebApplication SetupSwagger(this WebApplication app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "$ext_safeprojectname$");
                options.RoutePrefix = string.Empty;
                options.DisplayRequestDuration();
            });
            return app;
        }
    }
}