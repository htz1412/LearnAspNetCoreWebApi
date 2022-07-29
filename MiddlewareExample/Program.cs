var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    Console.WriteLine("Logic before executing the next delegate in Use method");
    await next.Invoke();
    Console.WriteLine("Logic after executing the next delegate in Use method");
});

app.Run(async context =>
{
    Console.WriteLine("Writing the response to the client in the Run method");
    await context.Response.WriteAsync("Hello from middleware component.");
});

app.MapControllers();

app.Run();