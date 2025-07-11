namespace MiniEcommerce.Products.WebAPI.DTOs
{
    public sealed record ChangeProductStockDto( 
        Guid ProductID,
        int Quantity);
   
}
