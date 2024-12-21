
namespace SnapMart.WebApi.Middleware
{
    public class APIAuthenticationMiddleware(ILogger<APIAuthenticationMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }
    }
}
