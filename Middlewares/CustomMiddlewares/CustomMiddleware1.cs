
using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;

namespace Middlewares.CustomMiddlewares
{
    public class CustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync(" - Custom Middleware - ");
            await next(context);
        }
    }

    public static class MyCustomMiddleware1 
    { 
        public static void UseMyCustomeMiddleware1(this WebApplication app)
        {
            app.UseMiddleware<CustomMiddleware1>();
        }
    }
}
