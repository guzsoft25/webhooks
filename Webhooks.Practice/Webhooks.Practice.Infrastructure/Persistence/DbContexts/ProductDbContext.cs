using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhooks.Practice.Domain.Entities;

namespace Webhooks.Practice.Infrastructure.Persistence.DbContexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>();

    }
}
