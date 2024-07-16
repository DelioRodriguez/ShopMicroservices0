using Microsoft.EntityFrameworkCore;


namespace ShopMicroservices0.Customers.Persistance.Context
{
    public class ShopContext : DbContext
    {

        #region Constructor
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        #endregion


        #region "Db sets"
        public DbSet<Domain.Entities.Customers> Customers { get; set; }
        #endregion


    }
}
