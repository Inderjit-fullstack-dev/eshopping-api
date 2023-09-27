using Catalog.Application.Helpers;
using Catalog.Application.Requests;
using Catalog.Core.Entities;

namespace Catalog.Application.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands();
        Task<PagedList<Brand>> GetAllBrands(BrandRequest request);
    }
}
