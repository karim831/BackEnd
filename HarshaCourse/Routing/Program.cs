using Routing.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options => {
    options.ConstraintMap.Add("myrange",typeof(RangeConstraint));
});

var app = builder.Build();

IDictionary<int,string> countries = new Dictionary<int,string>(){
    [1] = "United States",
    [2] = "Canada",
    [3] = "United Kingdom",
    [4] = "India",
    [5] = "Japan"
};


app.MapGet("/countries",async context => {
    foreach(var country in countries)
        await context.Response.WriteAsync($"{country.Key}, {country.Value}\n");
});

app.MapGet("/countries/{countryID:int}", async (HttpContext context,int countryID) => {
    if(countryID < 1 || countryID > 100){
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        return;
    }
    if(!countries.ContainsKey(countryID)){
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("[No Country]");
        return;
    }
        await context.Response.WriteAsync(countries[countryID]);
});




app.Run();