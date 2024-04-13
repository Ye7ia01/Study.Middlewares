using Middlewares.CustomMiddlewares;

namespace Middlewares
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<CustomMiddleware1>();
            var app = builder.Build();

            // Register the Custom Middleware in the Services 

            app.Use( async(HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync(" - Middleware 1 - ");
                await next(context);
            });

            //app.UseMiddleware<CustomMiddleware1>();
            app.UseMyCustomeMiddleware1();

            //app.MapGet("/", () => "Hello World!");

            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync(" - Middleware Terminal - ");
            });

            app.Run();
        }
    }
}
