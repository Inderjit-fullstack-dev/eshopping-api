using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetProductsByBrandQuery(string BrandName) : IRequest<IEnumerable<Product>>;
     
}
