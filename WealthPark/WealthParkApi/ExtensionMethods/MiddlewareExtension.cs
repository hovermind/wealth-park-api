using Microsoft.AspNetCore.Builder;
using WealthParkApi.Middlewares;

namespace WealthParkApi.ExtensionMethods
{
    /// <summary>
    /// Extention method to add middlewares
    /// </summary>
    public static class MiddlewareExtension
    {
        public static void ConfigureAppMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiExceptionMiddleware>();
            app.UseMiddleware<SerilogMiddleware>();
        }
    }
}
