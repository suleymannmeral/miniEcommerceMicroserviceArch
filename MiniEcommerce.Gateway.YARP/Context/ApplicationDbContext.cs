using Microsoft.EntityFrameworkCore;

namespace MiniEcommerce.Gateway.YARP.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

       
    }
}
