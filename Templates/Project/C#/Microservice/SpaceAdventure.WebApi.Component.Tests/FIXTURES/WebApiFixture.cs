using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using SystemTestingTools;

namespace $safeprojectname$.Fixtures
{
    public class WebApiFixture : IDisposable
    {
        public WebApplicationFactory<Program> Server { get; set; }

        public string StubsFolder { get; private set; }

        public WebApiFixture()
        {
            StartServer();
        }

        private void StartServer()
        {
            StubsFolder = EnvironmentHelper.GetProjectFolder("Stubs");

            Server = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder
                .InterceptHttpCallsBeforeSending()
                .UseEnvironment("Development");
            });
        }

        public void Dispose()
        {
            Server.Dispose();
        }
    }
}