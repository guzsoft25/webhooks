using Microsoft.EntityFrameworkCore;
using Webhooks.Practice.Application.Contracts;
using Webhooks.Practice.Domain.Entities;
using Webhooks.Practice.Infrastructure.Exceptions;
using Webhooks.Practice.Infrastructure.Persistence.DbContexts;

namespace Webhooks.Practice.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<int> CreateProductAsync(Product product)
        {
            await dbContext.AddAsync(product);
            return product.ProductId;
        }

        public async Task<IQueryable<Product>> GetProductsAsync()
        {
            var products = dbContext.Products.AsQueryable();
            return products;
        }

        public async Task RemoveProductAsync(int productId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            if(product == null) {
                throw new InfrastructureException($"unit of Id {productId} does not exist");
            }

            dbContext.Products.Remove(product);
        }
    }
}
