using Webhooks.Practice.Application.Contracts;
using Webhooks.Practice.Domain.Entities;
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
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveProductAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
