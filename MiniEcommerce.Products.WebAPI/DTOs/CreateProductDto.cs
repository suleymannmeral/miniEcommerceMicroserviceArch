namespace MiniEcommerce.Products.WebAPI.DTOs
{
    public record CreateProductDto(
        string Name,
        decimal Price,
        int QuantityInStock
    );
}
