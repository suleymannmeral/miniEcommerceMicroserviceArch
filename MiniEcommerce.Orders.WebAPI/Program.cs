using MiniEcommerce.Orders.WebAPI.Context;
using MiniEcommerce.Orders.WebAPI.DTOs;
using MiniEcommerce.Orders.WebAPI.Models;
using MiniEcommerce.Orders.WebAPI.Options;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getall", async (MongoDbContext context,IConfiguration configuration) =>
{
    var items = context.GetCollection<Order>("Orders");

     var orders= await  items.Find<Order>(item=>true).ToListAsync();

    List<OrderDto> orderDtos = new();
    Result<List<ProductDto>>? products = new();

    HttpClient httpClient = new();
    var message=await httpClient.GetAsync($"http://{configuration.GetSection("HttpRequest:Products").Value}/getall");
    if(message.IsSuccessStatusCode)
    {
        products = await message.Content.ReadFromJsonAsync<Result<List<ProductDto>>>();
  
    }

    foreach (var order in orders)
    {
        orderDtos.Add(new OrderDto
        {
            Id = order.Id,
            ProductId = order.ProductId,
            ProductName = products!.Data!.First(p=>p.Id==order.ProductId).Name,
            Price = order.Price,
            CreatAt = order.CreatAt,
            Quantity= order.Quantity
        });
        
    }
    return new Result<List<OrderDto>>(orderDtos);
  


});
app.MapPost("/create", async (MongoDbContext context, List<CreateOrderDto> request) =>
{
    var items = context.GetCollection<Order>("Orders");
    List<Order> orders = new();
    foreach (var item in request)
    {
        Order order = new()
        {
            ProductId = item.productId,
            Quantity = item.quantity,
            Price = item.price,
            CreatAt = DateTime.Now,
        };

        orders.Add(order);
    }

    await items.InsertManyAsync(orders);

    return Results.Ok(new Result<string>("Sipariþ baþarýyla oluþturuldu"));
});


app.Run();
