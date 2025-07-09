using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Products.WebAPI.Context;
using MiniEcommerce.Products.WebAPI.DTOs;
using MiniEcommerce.Products.WebAPI.Models;
using TS.Result;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getall",async (ApplicationDBContext context, CancellationToken cancellationToken )=>
{
    var products= await context
    .Products
    .OrderBy(p => p.Name)
    .ToListAsync(cancellationToken);

    Result<List<Product>> response = products;
    return response;
});

app.MapPost("/create", async (CreateProductDto createProductDto, ApplicationDBContext context, CancellationToken cancellationContext)=>
{
    bool isNameExist= await context.Products.AnyAsync(p => p.Name == createProductDto.Name, cancellationContext);
    if(isNameExist)
    {
        var repsonse= Result<string>.Failure("Product with this name already exists.");
        return Results.BadRequest(repsonse);
    }
    var product = new Product
    {
        Name = createProductDto.Name,
        Price = createProductDto.Price,
        QuantityInStock = createProductDto.QuantityInStock
    };
    await context.Products.AddAsync(product, cancellationContext);
    await context.SaveChangesAsync(cancellationContext);
    return Results.Ok(Result<string>.Succeed("Product has been created successfully"));
});
using (var scoped = app.Services.CreateScope())
{
    var srv = scoped.ServiceProvider;
    var dbContext = scoped.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    dbContext.Database.Migrate();
}

app.Run();
