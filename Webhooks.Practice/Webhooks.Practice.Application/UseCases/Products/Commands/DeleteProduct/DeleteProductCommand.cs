using MediatR;

namespace Webhooks.Practice.Application.UseCases.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(int ProductId) : IRequest;

}
