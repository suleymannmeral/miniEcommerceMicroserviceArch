namespace MiniEcommerce.ShoppingCarts.WebAPI.DTOs
{
    public sealed record ProductDto(
        Guid Id, 
        string Name, 
        decimal Price, 
        int QuantityInStock);
    

}
