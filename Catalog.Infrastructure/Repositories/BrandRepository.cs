using Catalog.Application.Requests;
using Catalog.Core.Entities;
using Catalog.Application.Repositories;
using Catalog.Infrastructure.Database;
using MongoDB.Driver;
using Catalog.Application.Helpers;

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

        public async Task<PagedList<Brand>> GetAllBrands(BrandRequest request)
        {
            var query = _context.Brands.AsQueryable();
            return await PagedList<Brand>.CreateAsync(query, request.CurrentPage, request.PageSize);
        }
    }
}
