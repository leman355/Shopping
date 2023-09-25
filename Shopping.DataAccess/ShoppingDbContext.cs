using Microsoft.EntityFrameworkCore;
using Shopping.Entities;

namespace Shopping.DataAccess
{
    public class ShoppingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ShopDb;User Id=postgres;Password=1;Search Path=public");
        }
        public DbSet<Product> Products { get; set; }
    }
}