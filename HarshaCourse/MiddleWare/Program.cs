using HarshaCourse.AuthenticationMiddleWare;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => {
    if(context.Request.Method == HttpMethod.Post.Method)
        await next();
    else{
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid login");
    }

});

app.UseAuthenticationMiddleWare();

app.Run(async context => {
    await context.Response.WriteAsync("Successful login");
});

app.Run();

