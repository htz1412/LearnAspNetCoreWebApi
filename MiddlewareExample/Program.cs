var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    Console.WriteLine("Logic before executing the Use method");
    await next.Invoke();
    Console.WriteLine("Logic after executing the Use method");
});

app.Map("/usingmapbranch", builder =>
{
    builder.Use(async (context, next) =>
    {
        Console.WriteLine("Use method of Map branch before executing next()");
        await next.Invoke();
        
        Console.WriteLine("Use method of Map branch after executing next()");
    });

    builder.Run(async context =>
    {
        Console.WriteLine("Run method of Map branch before executing.");
        await context.Response.WriteAsync("Hello from Use method of Map branch");
        Console.WriteLine("Run method of Map branch after executing.");
    });
});

app.Run(async context =>
{
    Console.WriteLine("Writing response to client in Run method");
    await context.Response.WriteAsync("Hello from the middleware component.");
});

app.MapControllers();

app.Run();
