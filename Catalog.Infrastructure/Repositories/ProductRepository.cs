using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Database;
using MongoDB.Driver;

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
