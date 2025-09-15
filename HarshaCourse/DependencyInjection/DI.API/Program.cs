using DI.Core.ServiceContracts;
using DI.Infrastructure.ServiceImplementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IWeatherService,WeatherService>();
var app = builder.Build();

app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseRouting();


app.MapControllers();
app.Run();
