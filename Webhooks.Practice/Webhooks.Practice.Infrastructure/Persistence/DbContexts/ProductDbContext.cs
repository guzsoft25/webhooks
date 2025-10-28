using Microsoft.EntityFrameworkCore;
using Webhooks.Practice.Domain.Entities;

namespace Webhooks.Practice.Infrastructure.Persistence.DbContexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(150);
            modelBuilder.Entity<Product>().Property(x => x.Description).HasMaxLength(600);
        }

        public DbSet<Product> Products => Set<Product>();

    }
}
