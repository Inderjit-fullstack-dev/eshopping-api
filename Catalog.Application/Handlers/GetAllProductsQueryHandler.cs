using Catalog.Application.Queries;
using Catalog.Core.Entities;
using Catalog.Application.Repositories;
using MediatR;
using Catalog.Application.Helpers;

namespace Catalog.Application.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedList<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProducts(request.ProductRequest);
        }
    }
}
