namespace MiniEcommerce.ShoppingCarts.WebAPI.DTOs
{
    public record CreateShoppingCartDto(
        Guid ProductId,
        int Quantity);
    

}
