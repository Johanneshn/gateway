using Gateway.Application;
using Gateway.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.Run();