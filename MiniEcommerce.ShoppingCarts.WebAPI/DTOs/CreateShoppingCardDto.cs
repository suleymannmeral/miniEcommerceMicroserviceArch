namespace MiniEcommerce.ShoppingCarts.WebAPI.DTOs
{
    public record CreateShoppingCardDto(
        Guid ProductId,
        int Stock);
    

}
