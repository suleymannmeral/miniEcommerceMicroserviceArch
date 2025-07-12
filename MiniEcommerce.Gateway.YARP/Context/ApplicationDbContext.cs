using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Gateway.YARP.Models;

namespace MiniEcommerce.Gateway.YARP.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
