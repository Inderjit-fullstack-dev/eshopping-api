using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Database;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ICatalogContext _context;

        public BrandRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await _context.Brands.Find(_ => true).ToListAsync();
        }
    }
}
