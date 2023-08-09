using WebSocketExample.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<Auth>();

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

