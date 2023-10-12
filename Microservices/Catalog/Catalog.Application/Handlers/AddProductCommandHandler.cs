using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Application.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.AddProduct(request.Product);
        }
    }
}
