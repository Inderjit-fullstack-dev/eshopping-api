using Catalog.Application.Queries;
using Catalog.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Catalog.API.Controllers
{
    public class BrandsController : ApiController
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands([FromQuery] BrandRequest request)
        {
            var result = await _mediator.Send(new GetBrandsQuery(request));
            return Ok(result);
        }
    }
}
