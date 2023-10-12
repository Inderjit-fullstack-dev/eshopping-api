using Catalog.Application.Queries;
using Catalog.Core.Entities;
using Catalog.Application.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductsByProductTypeQueryHandler : IRequestHandler<GetProductsByProductTypeQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByProductTypeQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductsByProductTypeQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsByProductType(request.productTypeName);
        }
    }
}
