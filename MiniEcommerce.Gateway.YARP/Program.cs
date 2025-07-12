using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Gateway.YARP.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddReverseProxy()
        .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!5353");
app.MapReverseProxy();

app.Run();
