using Microsoft.EntityFrameworkCore;
using MiniEcommerce.ShoppingCarts.WebAPI.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/getall", async (ApplicationDbContext context, CancellationToken cancellationToken) =>
{

});

using (var scoped = app.Services.CreateScope())
{
    var srv= scoped.ServiceProvider;
    var dbContext = srv.GetRequiredService<ApplicationDbContext>(); 
    dbContext.Database.Migrate(); // Ensure the database is created and migrations are applied
}
    app.Run();
