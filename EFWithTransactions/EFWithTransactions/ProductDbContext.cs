using System.Data.Entity;

namespace EFWithTransactions
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
            : base("ProductConnectionString")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}