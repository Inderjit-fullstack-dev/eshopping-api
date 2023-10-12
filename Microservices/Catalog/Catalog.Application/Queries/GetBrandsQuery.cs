using Catalog.Application.Helpers;
using Catalog.Application.Requests;
using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetBrandsQuery(BrandRequest BrandRequest) : IRequest<PagedList<Brand>>;
}
