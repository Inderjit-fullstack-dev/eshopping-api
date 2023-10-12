using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetProductTypesQuery : IRequest<IEnumerable<ProductType>>;
}
