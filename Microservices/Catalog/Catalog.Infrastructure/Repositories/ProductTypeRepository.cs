using Catalog.Core.Entities;
using Catalog.Application.Repositories;
using Catalog.Infrastructure.Database;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ICatalogContext _context;

        public ProductTypeRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductType>> GetAllProductTypes()
        {
            return await _context.ProductTypes.Find(_ => true).ToListAsync();
        }
    }
}
