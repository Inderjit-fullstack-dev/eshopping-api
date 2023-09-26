using Catalog.Application.Queries;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IEnumerable<Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandsQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<IEnumerable<Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _brandRepository.GetAllBrands();
        }
    }
}
