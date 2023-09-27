using Catalog.Application.Queries;
using Catalog.Core.Entities;
using Catalog.Application.Repositories;
using MediatR;
using Catalog.Application.Helpers;

namespace Catalog.Application.Handlers
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, PagedList<Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandsQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<PagedList<Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _brandRepository.GetAllBrands(request.BrandRequest);
        }
    }
}
