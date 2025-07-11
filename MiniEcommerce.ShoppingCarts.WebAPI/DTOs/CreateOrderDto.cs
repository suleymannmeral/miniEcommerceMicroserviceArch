namespace MiniEcommerce.ShoppingCarts.WebAPI.DTOs
{
    public sealed record CreateOrderDto
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }   
        public decimal Price { get; set; }
    }
}
