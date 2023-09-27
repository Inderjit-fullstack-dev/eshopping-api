using Catalog.Application.Queries;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductsByBrandQueryHandler : IRequestHandler<GetProductsByBrandQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByBrandQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsByBrandName(request.BrandName);
        }
    }
}
