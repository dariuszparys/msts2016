using Microsoft.AspNetCore.Builder;

namespace Wichtel.WebApi.Middleware
{
    public static class ApiKeyExtensions
    {
        public static IApplicationBuilder UseApiKey(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}