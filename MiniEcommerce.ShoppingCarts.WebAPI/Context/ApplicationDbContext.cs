using Microsoft.EntityFrameworkCore;
using MiniEcommerce.ShoppingCarts.WebAPI.Models;

namespace MiniEcommerce.ShoppingCarts.WebAPI.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
    

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
    }
}
