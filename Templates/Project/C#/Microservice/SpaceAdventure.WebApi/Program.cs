using $safeprojectname$.Application.Extensions;
using $safeprojectname$.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services
    .AddEndpointsApiExplorer()
    .SetupSwagger()
    .SetupHealthChecks()
    .SetupWebApi()
    .AddApplication();

var app = builder.Build();

app
    .SetupExceptions()
    .SetupSwagger()
    .SetupHealthChecks()
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

app.Run();

/// <summary>
/// This class is for testing purposes.
/// </summary>
public partial class Program
{ }