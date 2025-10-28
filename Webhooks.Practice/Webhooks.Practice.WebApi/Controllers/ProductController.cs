using MediatR;
using Microsoft.AspNetCore.Mvc;
using Webhooks.Practice.Application.Dtos;
using Webhooks.Practice.Application.UseCases.Products.Commands.CreateProduct;
using Webhooks.Practice.Application.UseCases.Products.Queries.GetProducts;

namespace Webhooks.Practice.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto product)
        {

            CreateProductCommand command = new CreateProductCommand(product.Name, product.Description, product.price, product.Image);
            var productId = await _mediator.Send(command);
            return Ok(productId);

        }



    }
}
