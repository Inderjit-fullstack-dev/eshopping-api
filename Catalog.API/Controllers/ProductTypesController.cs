using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class ProductTypesController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductTypes()
        {
            var result = await _mediator.Send(new GetProductTypesQuery());
            return Ok(result);
        }
    }
}
