using Webhooks.Practice.Domain.Entities;

namespace Webhooks.Practice.Application.Contracts
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> GetProductsAsync();
        Task<int> CreateProductAsync(Product product);
        Task RemoveProductAsync(int productId);
    }
}


