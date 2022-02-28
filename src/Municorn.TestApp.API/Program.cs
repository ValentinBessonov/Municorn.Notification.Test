using Municorn.TestApp.Core;
using Municorn.TestApp.Extensions;
using Municorn.TestApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOwnSwaggerGen();

builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddDbContext();
builder.Services.AddRepositories();
builder.Services.AddExceptionHandler();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseExceptionHandler();

app.Run();
