namespace Server;
using Server.Authorization;
using Server.Services;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var ver = VerClass.verif;
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
            var nume = credentials[0];
            var parola = credentials[1];
            Console.WriteLine(ver);
            // authenticate credentials with user service and attach user to http context
            User? ctrl = null;
            if (ver == "profesor") ctrl = await userService.AuthenticateProfesor(nume, parola);
            if (ver == "elev") ctrl = await userService.AuthentificateElev(nume, parola);
            
            if(ctrl!=null)
            {
               context.Items["User"] = ctrl;
            }
            else
            {

            }
        }
        catch
        {
            // do nothing if invalid auth header
            // user is not attached to context so request won't have access to secure routes
        }
        await _next(context);
    }
}