﻿using Catalog.Application.Helpers;
using Catalog.Application.Requests;
using Catalog.Core.Entities;

namespace Catalog.Application.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<PagedList<Product>> GetAllProducts(ProductRequest productRequest);
        Task<IEnumerable<Product>> GetProductsByBrandName(string brandName);
        Task<IEnumerable<Product>> GetProductsByProductType(string productType);
        Task<Product> GetProductById(string id);
        Task<Product> AddProduct(Product product);
        Task<bool> UpdateProduct(string id, Product product);
        Task<bool> DeleteProduct(string id);
    }
}
