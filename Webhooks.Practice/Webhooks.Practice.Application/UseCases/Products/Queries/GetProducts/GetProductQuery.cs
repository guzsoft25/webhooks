using MediatR;
using Webhooks.Practice.Domain.Entities;

namespace Webhooks.Practice.Application.UseCases.Products.Queries.GetProducts
{
    public record GetProductQuery : IRequest<List<Product>>;
    
}
