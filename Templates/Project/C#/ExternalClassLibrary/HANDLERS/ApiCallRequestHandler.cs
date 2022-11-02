using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using $safeprojectname$.Constants;
using System.Text;

namespace $safeprojectname$.Handlers
{
    public class ApiCallRequest : IRequest<object>
    {
    }

    public class ApiCallRequestHandler : BaseHttpHandler, IRequestHandler<ApiCallRequest, object>
    {
        public ApiCallRequestHandler(ILogger<ApiCallRequestHandler> logger, IHttpClientFactory httpClientFactory) : base(UrlConstants.URL, logger, httpClientFactory)
        {
        }

        public async Task<object> Handle(ApiCallRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(ApiNameConstants.API_NAME);
                HttpContent requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{_baseUrl}", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // _logger.LogInformation("{0} Response: {1}", LogConstants.SuccessfulExecuteNewHighScoreRequest, content);
                    var highScoreResponse = JsonConvert.DeserializeObject<object>(content);
                    // result = highScoreResponse;
                }
                else
                {
                    //var errorEvent = ErrorConstants.ErrorExecuteNewHighScore;
                    //_logger?.LogError(errorEvent, "{0}, Message: {1}", errorEvent.Name, response.ReasonPhrase);
                    //result.Messages.Add(errorEvent.Name);
                }
            }
            catch (Exception ex)
            {
                //var errorEvent = ErrorConstants.ErrorExecuteNewHighScore;
                //_logger?.LogError(errorEvent, ex, errorEvent.Name);
                //result.Messages.Add(errorEvent.Name);
            }
            throw new NotImplementedException();
        }
    }
}