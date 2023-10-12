using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Requests;
using Catalog.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductRequest request)
        {
            var result = await _mediator.Send(new GetAllProductsQuery(request));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("{brandName}")]
        public async Task<IActionResult> GetProductsByBrand(string brandName)
        {
            var result = await _mediator.Send(new GetProductsByBrandQuery(brandName));
            return Ok(result);
        }

        [HttpGet("{productTypeName}")]
        public async Task<IActionResult> GetProductsByProductType(string productTypeName)
        {
            var result = await _mediator.Send(new GetProductsByProductTypeQuery(productTypeName));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _mediator.Send(new AddProductCommand(product));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, Product product)
        {
            var result = await _mediator.Send(new UpdateProductCommand(id, product));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }

    }
}
