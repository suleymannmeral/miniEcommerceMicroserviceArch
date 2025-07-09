using Microsoft.EntityFrameworkCore;

namespace MiniEcommerce.ShoppingCarts.WebAPI.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
