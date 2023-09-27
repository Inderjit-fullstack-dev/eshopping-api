using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetAllProductsQuery : IRequest<IEnumerable<Product>>;
}
