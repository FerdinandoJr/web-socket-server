using Application.Use_Cases;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure;
using Infrastructure.Repositories;
using WebSocketExample.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//
// Domain dependencies
//
builder.Services.AddSingleton<ConnectionWSService>();

//
// Infra dependencies
//
builder.Services.AddSingleton<IConnectionWSRepository, ConnectionWSRepository>();

//
// Application dependencies
//
builder.Services.AddSingleton<CreateConnectionUseCase>();
builder.Services.AddSingleton<GetConnectionsUseCase>();

builder.Services.AddSingleton<ConnectionWSManager>(); // Registro do ConnectionWSManager
builder.Services.AddTransient<Auth>();
builder.Services.AddControllers();

var app = builder.Build();

// <snippet_UseWebSockets>
var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromSeconds(30) // default = 120 s
};


app.UseMiddleware<Auth>();

app.UseWebSockets(webSocketOptions);

app.UseDefaultFiles();
app.UseStaticFiles();


app.MapControllers();

app.Run();

