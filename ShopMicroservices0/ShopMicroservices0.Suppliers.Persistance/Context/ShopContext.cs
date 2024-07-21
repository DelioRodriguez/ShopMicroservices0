

using Microsoft.EntityFrameworkCore;

namespace ShopMicroservices0.Suppliers.Persistance.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.Suppliers> Suppliers { get; set; }
    }
}
