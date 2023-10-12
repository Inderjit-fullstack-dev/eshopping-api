using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
