using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Exceptions;

namespace WealthParkApi.Middlewares
{
    /// <summary>
    /// ApiException handling middleware
    /// </summary>
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = StatusCodes.Status500InternalServerError; // 500 if unexpected

            if (ex is ApiException)
            {
                statusCode = (ex as ApiException).StatusCode;
            }
            // add more ifs when needed

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = @"application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }


    }
}
