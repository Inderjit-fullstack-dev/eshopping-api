using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Database
{
    public interface ICatalogContext
    {
        IMongoCollection<ProductType> ProductTypes { get; }
        IMongoCollection<Brand> Brands { get; }
        IMongoCollection<Product> Products { get; }
    }
}
