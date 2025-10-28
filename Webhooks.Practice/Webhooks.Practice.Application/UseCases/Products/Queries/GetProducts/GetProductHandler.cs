using MediatR;
using Webhooks.Practice.Application.UnitOfWorks;
using Webhooks.Practice.Domain.Entities;

namespace Webhooks.Practice.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, List<Product>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetProductHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.ProductRepository.GetProductsAsync();
            return products.ToList();
        }
    }
}
