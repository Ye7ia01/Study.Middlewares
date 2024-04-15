using Middlewares.CustomMiddlewares;

namespace Middlewares
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<CustomMiddleware1>();
            builder.Services.AddTransient<CustomLoginMiddleware>();
            var app = builder.Build();

            // Register the Custom Middleware in the Services 

            /*
            app.Use( async(HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync(" - Middleware 1 - ");
                await next(context);
            });
            */

            //Use Below if No extention method applied
            //app.UseMiddleware<CustomMiddleware1>();

            // I am Using app.useCustom() because i created an extention method using the above expression
            //app.UseMyCustomeMiddleware1();


            app.useCustomLoginMiddleware();
            //app.MapGet("/", () => "Hello World!");


            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync(" - Middleware Terminal - ");
            });

            app.Run();
        }
    }
}
