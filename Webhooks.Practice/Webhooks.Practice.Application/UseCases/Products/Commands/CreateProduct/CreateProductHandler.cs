using MediatR;
using Microsoft.Extensions.Logging;
using Webhooks.Practice.Application.UnitOfWorks;
using Webhooks.Practice.Domain.Entities;

namespace Webhooks.Practice.Application.UseCases.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger logger;

        public CreateProductHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null) {
                logger.LogCritical("provide required fields");
                throw new ApplicationException("provide required fields");
            }

            Product product 
                = new Product(request.Name, request.Description, request.Price, request.Image);

            int productId = await unitOfWork.ProductRepository.CreateProductAsync(product);
            return productId;
        }
    }
}
