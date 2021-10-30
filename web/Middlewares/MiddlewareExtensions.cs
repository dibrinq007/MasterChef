using Microsoft.AspNetCore.Builder;

namespace MasterChef.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuMiddlewareMasterChef(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }

    }
}