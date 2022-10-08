using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using $safeprojectname$.Models.Constants;
using System.Diagnostics;

namespace $safeprojectname$.Behaviours
{
    public class LoggingRequestHandlerBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingRequestHandlerBehaviour<TRequest, TResponse>> _logger;

        public LoggingRequestHandlerBehaviour(ILogger<LoggingRequestHandlerBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).FullName;
            var requestJson = "";
            try
            {
                requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
            }
            catch (Exception ex)
            {
                requestJson = $"{ex.Message}";
            }

            _logger.LogInformation($"{Constants.Prefix}:" + "Handling {requestName}\n{requestJson}", requestName, requestJson);

            var sw = Stopwatch.StartNew();
            var response = await next();
            sw.Stop();

            var responseJson = "";
            try
            {
                responseJson = JsonConvert.SerializeObject(response, Formatting.Indented);
            }
            catch (Exception ex)
            {
                responseJson = $"{ex.Message}";
            }
            _logger.LogInformation($"{Constants.Prefix}:" + "Handled {requestName} in {ElapsedMilliseconds}ms\n{responseJson}", requestName, sw.ElapsedMilliseconds, responseJson);

            return response;
        }
    }
}