namespace MiniEcommerce.Orders.WebAPI.DTOs
{
    public sealed record CreateOrderDto(
        Guid productId,
        int quantity,
        decimal price
        );
   
    public sealed record OrderDto
    {
        public Guid  Id { get; init; }
        public Guid  ProductId { get; init; }
        public string ProductName { get; init; } = default!;
        public decimal Price { get; init; }
        public DateTime CreatAt { get; init; }
        public int Quantity { get; init; }
        }
}
