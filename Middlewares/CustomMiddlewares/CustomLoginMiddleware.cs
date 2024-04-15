
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Middlewares.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Middlewares.CustomMiddlewares
{

    public class CustomLoginMiddleware : IMiddleware
    {
        [HttpPost]
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            if(context.Request.Method ==  "POST" && context.Request.ContentLength > 0)
            {
                var buffer = new byte[Convert.ToInt16(context.Request.ContentLength)];
                await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyString = Encoding.UTF8.GetString(buffer);
                LoginDTO? user = JsonConvert.DeserializeObject<LoginDTO>(bodyString);
                if(user != null) 
                { 
                    if(user.email == "ye7iaabdelhady@gmail.com" && user.password == "P@ssw0rd")
                    {
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync("Login Successfull");
                        await next(context);
                        return;
                    } 
                }

                string errorMessage = "Invalid Credentials";
                if (user.email is null) errorMessage = "Invalid Email";
                else if (user.password is null) errorMessage = "InvalidPassword";

                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(errorMessage);
                await next(context);
                return;
            }
            /*
            // Read From Query String
            bool login = context.Request.Query.ContainsKey("email") && context.Request.Query.ContainsKey("password") ? true : false;
            if(login) {

                string? email = context.Request.Query["email"];
                string? password = context.Request.Query["password"];

                if (email == "ye7iaabdelhady@gmail.com" && password == "P@ssw0rd")
                {
                    await context.Response.WriteAsync("Login Successfull");
                    await next(context);
                }
            }

            // Read From body


            
            await context.Response.WriteAsync("Invalid Credentials");
            await next(context);
        */
            }
            
    }

    public static class CustomLoginMiddelwareExtention
    {
        public static void useCustomLoginMiddleware(this WebApplication app)
        {
            app.UseMiddleware<CustomLoginMiddleware>();
        }

    }
}
