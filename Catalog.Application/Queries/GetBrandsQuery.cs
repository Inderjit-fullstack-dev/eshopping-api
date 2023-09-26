using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetBrandsQuery : IRequest<IEnumerable<Brand>>;
}
