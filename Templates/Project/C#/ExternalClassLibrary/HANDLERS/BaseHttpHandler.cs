using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Handlers
{
    public class BaseHttpHandler
    {
        protected readonly string _baseUrl;
        protected ILogger _logger;
        protected IHttpClientFactory _httpClientFactory;

        public BaseHttpHandler(string baseUrl, ILogger logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _baseUrl = baseUrl;
        }
    }
}