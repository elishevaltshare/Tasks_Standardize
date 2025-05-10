using System.Data.Common;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/HelloWorld", () =>
{
    var dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION");
    return SayHello(dbConnection);
})
.WithName("GetHelloWorld")
.WithOpenApi();

app.Run();

string SayHello(string? dbConnection)
{
    return string.IsNullOrEmpty(dbConnection)
          ? "almost there, secret: DB_CONNECTION is not set"
          : $"hello word - {dbConnection}";
}
