using MediatR;
using Microsoft.Extensions.Logging;
using Webhooks.Practice.Application.UnitOfWorks;

namespace Webhooks.Practice.Application.UseCases.Products.Commands.DeleteProduct
{
    class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<DeleteProductHandler> logger;

        public DeleteProductHandler(IUnitOfWork unitOfWork,ILogger<DeleteProductHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.ProductId == 0) {
                logger.LogCritical("ProductId is required");
                throw new ApplicationException("ProductId is required");
            }

            await unitOfWork.ProductRepository.RemoveProductAsync(request.ProductId);
        }
    }
}
