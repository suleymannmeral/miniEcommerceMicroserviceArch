using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniEcommerce.Gateway.YARP.Context;
using MiniEcommerce.Gateway.YARP.DTOs;
using MiniEcommerce.Gateway.YARP.Models;
using MiniEcommerce.Gateway.YARP.Service;
using System.Text;
using TS.Result;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular development server
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddReverseProxy()
        .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
});
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("JWT:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:SecretKey").Value ?? "")),
        ValidateLifetime = true
    };
});
builder.Services.AddAuthorization();
var app = builder.Build();

app.MapGet("/", () => "Hello World!5353");


app.MapPost("auth/register",async(ApplicationDbContext context,CancellationToken cancellationToken,RegisterDto request) =>
{
    bool isUserNameExist= await context.Users.AnyAsync(u => u.UserName == request.UserName, cancellationToken);
    if(isUserNameExist)
        return Results.BadRequest(Result<string>.Failure("Kullanýcý adý daha önce alýnmýþ"));
    var newUser = new User
    {
        UserName =request.UserName,
        Password = request.Password
    };
    await context.Users.AddAsync(newUser, cancellationToken);
    await context.SaveChangesAsync(cancellationToken);
    return Results.Ok(Result<string>.Succeed("Kullanýcý kaydý baþarýlý"));
});

app.MapPost("auth/login", async (ApplicationDbContext context, CancellationToken cancellationToken, LoginDto request) =>
{
   User? user = await context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);
    if (user is null)
        return Results.BadRequest("Username not found ");
    JWTProvider jWTProvider = new JWTProvider(builder.Configuration);
    // Generate Token
    string token = jWTProvider.CreateToken(user);
    return Results.Ok(token);

});
app.UseCors("AllowAngularApp"); // <--- bu satır çok önemli

app.UseAuthentication();
app.UseAuthorization();
app.MapReverseProxy();

using(var scoped= app.Services.CreateScope())
{
    var dbContext = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (dbContext.Database.IsRelational())
    {
        dbContext.Database.Migrate();
    }
}
app.Run();
