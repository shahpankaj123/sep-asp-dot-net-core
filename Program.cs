using services;
using data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    ));

builder.Services.AddScoped<ITodoService, TodoServicesImpl>();

var app = builder.Build();

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    try
    {
        Console.WriteLine($"Request: {context.Request.Path}");
        await next();
        Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new
        {
            message = "Something went wrong",
            details = e.Message
        });

    }
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 2: Checking authentication");

    await next();
});


app.MapControllers();




app.Run();


