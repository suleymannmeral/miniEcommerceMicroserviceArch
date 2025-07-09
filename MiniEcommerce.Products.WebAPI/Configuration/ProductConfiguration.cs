using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniEcommerce.Products.WebAPI.Models;

namespace MiniEcommerce.Products.WebAPI.Configuration;

public  class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p=>p.Price).HasColumnType("money");    
    }
}
