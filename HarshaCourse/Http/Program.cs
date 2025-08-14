using Microsoft.AspNetCore.WebUtilities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (
        context.Request.Method == HttpMethod.Get.Method &&
        context.Request.Path == "/"
    )
    {
        string invalidMessage = "";
        int? firstNumber = null;
        int? secondNumber = null;
        string? op = null;
        string[] operations = ["add", "mul", "sub", "div", "mod"];

        var query = context.Request.Query;

        if (!query.ContainsKey("firstNumber") || !int.TryParse(query["firstNumber"], out int tempFirst))
        {
            context.Response.StatusCode = 400;
            invalidMessage += "Invalid input for 'firstNumber'\n";
        }
        else
        {
            firstNumber = tempFirst;
        }

        if (!query.ContainsKey("secondNumber") || !int.TryParse(query["secondNumber"], out int tempSecond))
        {
            context.Response.StatusCode = 400;
            invalidMessage += "Invalid input for 'secondNumber'\n";
        }
        else
        {
            secondNumber = tempSecond;
        }

        
        

        if (!query.ContainsKey("operation") || !(query["operation"][0] is string operation))
        {
            context.Response.StatusCode = 400;
            invalidMessage += "Invalid input for 'operation'\n";
        }
        else
        {
            if (operations.Contains(operation))
            {
                op = operation.ToLower();
            }
            else
            {
                context.Response.StatusCode = 400;
                invalidMessage += "Invalid input for 'operation'\n";
            }
        }

        // Do calculation
        if (context.Response.StatusCode != 400)
        {
            switch (op)
            {
                case "add":
                    await context.Response.WriteAsync($"{firstNumber + secondNumber}");
                    break;
                case "sub":
                    await context.Response.WriteAsync($"{firstNumber - secondNumber}");
                    break;
                case "mul":
                    await context.Response.WriteAsync($"{(long?)firstNumber * secondNumber}");
                    break;
                case "div":
                    if(secondNumber != 0)
                        await context.Response.WriteAsync($"{firstNumber / (secondNumber * 1.0)}");
                    else{
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("DivisionByZero");
                    }
                    break;
                case "mod":
                    if(secondNumber != 0)
                        await context.Response.WriteAsync($"{firstNumber % secondNumber}");
                    else{
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("DivisionByZero");
                    }
                    break;
            }
        }
        else
            await context.Response.WriteAsync(invalidMessage);
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("Not Found!");
    }
});

app.Run();
