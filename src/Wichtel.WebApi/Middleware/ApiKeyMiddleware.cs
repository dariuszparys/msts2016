using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Wichtel.WebApi.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly string API_KEY = "1234";
        private readonly string HTTP_HEADER_API_KEY = "x-wichtel-key";

        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public ApiKeyMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<ApiKeyMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            var headers = context.Request.Headers;
            if(headers.ContainsKey(HTTP_HEADER_API_KEY))
            {
                var key = headers[HTTP_HEADER_API_KEY].ToString();
                if(key.CompareTo(API_KEY) == 0)
                {
                    await next.Invoke(context);
                    return;
                }
            }

            logger.LogError($"Missing header {HTTP_HEADER_API_KEY}");
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
        }
    }
}