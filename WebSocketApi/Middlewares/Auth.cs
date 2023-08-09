using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.WebSockets;
using System.Security.Claims;

namespace WebSocketExample.Middlewares
{
    public class Auth : IMiddleware
    {

        public Auth()
        {

        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string authHeader = context.Request.Headers["Authorization"];
           

            Console.WriteLine(context.Request.Headers.ToString());

            
            Console.WriteLine(authHeader);

            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                string token = authHeader.Substring("Bearer ".Length).Trim();

                try
                {
                    // Validate the token
                    var claimsPrincipal = ValidateToken(token);
                    context.User = claimsPrincipal;
                }
                catch
                {
                    Console.WriteLine("Failure conneceted!");
                    // Return unauthorized status code if the token is invalid
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }


                await next(context);
            }
            Console.WriteLine("Connection unauthorized");
        }

        private ClaimsPrincipal ValidateToken(string token)
        {

            if (token == "D4T4")
            {
                return new ClaimsPrincipal();
            }


            throw new ArgumentException("Token unauthorized");

        }
    }
}
