using FluentAssertions;
using $safeprojectname$.Fixtures;

namespace $safeprojectname$.Apis
{
    [TestClass]
    public class WebApiTests
    {
        private static WebApiFixture _webApiFixture;

        [ClassInitialize]
        public static void ClassInitialise(TestContext testContext)
        {
            _webApiFixture = new WebApiFixture();
        }

        [TestMethod]
        public async Task Version_Should_Return_Success()
        {
            var client = _webApiFixture.Server.CreateClient();
            var result = await client.GetAsync("api/version");
            result.IsSuccessStatusCode.Should().Be(true);
        }
    }
}