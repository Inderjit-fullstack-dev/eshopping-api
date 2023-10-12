using Catalog.Application.Helpers;
using Catalog.Application.Requests;
using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetAllProductsQuery(ProductRequest ProductRequest) : IRequest<PagedList<Product>>;
}
