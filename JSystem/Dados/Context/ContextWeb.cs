using JSystem.Dados.ConfigurationModel;
using JSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JSystem.Dados.Context
{
    public class ContextWeb : DbContext
    {
        public ContextWeb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<BrandModel> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
