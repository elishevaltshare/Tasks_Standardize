using System.Data.Common;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://+:80");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/HelloMessage", () =>
{
    var dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION");
    return Logic.GetHelloMessage(dbConnection);
})
.WithName("GetHelloMessage")
.WithOpenApi();

app.Run();

public static class Logic
{
    public static string GetHelloMessage(string? dbConnection)
    {
        //if (string.IsNullOrEmpty(dbConnection))
        //    return "almost there, secret: DB_CONNECTION is not set";
        return $"hello word - {dbConnection}";
    }
}