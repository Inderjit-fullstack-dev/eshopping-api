using Catalog.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Database
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<ProductType> ProductTypes { get; }
        public IMongoCollection<Brand> Brands { get; }
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatbaseName);

            ProductTypes = db.GetCollection<ProductType>(settings.Value.ProductTypeCollection);
            Brands = db.GetCollection<Brand>(settings.Value.BrandCollection);
            Products = db.GetCollection<Product>(settings.Value.ProductCollection);
        }
    }
}
