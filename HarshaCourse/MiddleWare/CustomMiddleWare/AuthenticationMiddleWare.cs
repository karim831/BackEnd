using Microsoft.AspNetCore.WebUtilities;

namespace HarshaCourse.AuthenticationMiddleWare;

public class AuthenticationMiddleWare{

    private readonly RequestDelegate _next;
    public AuthenticationMiddleWare(RequestDelegate next){
        this._next = next;
    }

    public async Task Invoke(HttpContext context){
        var queryDic = QueryHelpers.ParseQuery(await new StreamReader(context.Request.Body).ReadToEndAsync());

        string? email = queryDic.GetValueOrDefault("email").FirstOrDefault(), password = queryDic.GetValueOrDefault("password").FirstOrDefault();
        
        if(email is string e && password is string p){
            if(e.Equals("admin@example.com") && p.Equals("admin1234"))
                await _next(context);
            else
                await InvalidLogin(context);
        }
        else
            await InvalidLogin(context);
    }

    private async Task InvalidLogin(HttpContext context){
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid login");
    }
}


public static class AuthenticationMiddleWareExtension{
    public static IApplicationBuilder UseAuthenticationMiddleWare(this IApplicationBuilder app) => app.UseMiddleware<AuthenticationMiddleWare>();
} 




