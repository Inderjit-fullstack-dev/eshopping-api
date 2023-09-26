using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productRepository.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var result = await _productRepository.GetProductById(id);
            return Ok(result);
        }

        [HttpGet("{brandName}")]
        public async Task<IActionResult> GetProductsByBrand(string brandName)
        {
            var result = await _productRepository.GetProductsByBrandName(brandName);
            return Ok(result);
        }

        [HttpGet("{productType}")]
        public async Task<IActionResult> GetProductsByProductType(string productType)
        {
            var result = await _productRepository.GetProductsByProductType(productType);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _productRepository.AddProduct(product);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, Product product)
        {
            var result = await _productRepository.UpdateProduct(id, product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _productRepository.DeleteProduct(id);
            return Ok(result);
        }

    }
}
