using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetProductsByProductTypeQuery(string productTypeName) : IRequest<IEnumerable<Product>>;
}
