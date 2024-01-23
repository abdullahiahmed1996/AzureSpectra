using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureSpectra
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("F1")]
        public HttpResponseData RunF1([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req, [FromBody] string body)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            string connString = Environment.GetEnvironmentVariable("local") ?? "Missing";

            response.WriteString(connString);

            return response;
        }
    }
}
