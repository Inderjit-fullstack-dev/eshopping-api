using Catalog.Application.Queries;
using Catalog.Core.Entities;
using Catalog.Application.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductTypesQueryHandler : IRequestHandler<GetProductTypesQuery, IEnumerable<ProductType>>
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public GetProductTypesQueryHandler(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public async Task<IEnumerable<ProductType>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await _productTypeRepository.GetAllProductTypes();
        }
    }
}
