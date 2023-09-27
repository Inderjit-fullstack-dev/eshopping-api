using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Commands
{
    public record UpdateProductCommand(string Id, Product Product) : IRequest<bool>;
}
