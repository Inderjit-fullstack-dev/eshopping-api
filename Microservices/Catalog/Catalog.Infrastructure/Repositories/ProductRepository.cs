using Catalog.Core.Entities;
using Catalog.Application.Repositories;
using Catalog.Infrastructure.Database;
using MongoDB.Driver;
using Catalog.Application.Requests;
using Catalog.Application.Helpers;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Catalog.Application.Constants;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<PagedList<Product>> GetAllProducts(ProductRequest productRequest)
        {
            IMongoQueryable<Product> query = _context.Products.AsQueryable();

            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;

            if(!string.IsNullOrEmpty(productRequest.Search))
            {                
                filter = builder.Regex(x => x.Name, new BsonRegularExpression(productRequest.Search, "i"));
                query = query.Where(x => filter.Inject());
            }

            if (!string.IsNullOrEmpty(productRequest.SortColumn) && (productRequest.SortBy == DataFilterConstants.ASC || productRequest.SortBy == DataFilterConstants.DESC))
            {
                query = FilterProducts(query, productRequest);
            }

            return await PagedList<Product>.CreateAsync(query, productRequest.CurrentPage, productRequest.PageSize);
        }

        private static IMongoQueryable<Product> FilterProducts(IMongoQueryable<Product> query, ProductRequest request)
        {
            var sortMap = new Dictionary<string, Func<IMongoQueryable<Product>, IMongoQueryable<Product>>>
            {
                {SortingConstants.Name, query => request.SortBy == DataFilterConstants.ASC ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name)},
                {SortingConstants.Price, query => request.SortBy == DataFilterConstants.ASC ? query.OrderBy(x => x.Price) : query.OrderByDescending(x => x.Price)}
            };

            if (sortMap.TryGetValue(request.SortColumn, out var sortFunction))
            {
                query = sortFunction(query);
            }

            return query;
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandName(string brandName)
        {
            // FILTERING THE RECORD USING FILTER DEFINATION.
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Brand.BrandName, brandName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByProductType(string productType)
        {
            return await _context.Products.Find(p => p.ProductType.ProductTypeName == productType).ToListAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> UpdateProduct(string id, Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(p => p.Id == id, product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteResult = await _context.Products.DeleteOneAsync(p => p.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        
    }
}
