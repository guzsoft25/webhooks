using MediatR;

namespace Webhooks.Practice.Application.UseCases.Products.Commands.CreateProduct
{
    public record CreateProductCommand(string Name,string? Description,decimal Price,
        string? Image): IRequest<int>;
   
}
