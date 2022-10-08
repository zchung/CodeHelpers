namespace $safeprojectname$.Extensions
{
    public static class ExceptionStartupExtensions
    {
        public static WebApplication SetupExceptions(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler("/error");
            return app;
        }
    }
}