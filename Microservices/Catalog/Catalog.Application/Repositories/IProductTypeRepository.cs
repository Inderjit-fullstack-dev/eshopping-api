using Catalog.Core.Entities;

namespace Catalog.Application.Repositories
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllProductTypes();
    }
}
