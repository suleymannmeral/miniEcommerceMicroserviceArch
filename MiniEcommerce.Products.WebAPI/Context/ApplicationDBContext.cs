using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Products.WebAPI.Models;

namespace MiniEcommerce.Products.WebAPI.Context;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    }
    public DbSet<Product> Products { get; set; }

}
