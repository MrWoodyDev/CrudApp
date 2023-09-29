using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, decimal Price, int Quantity, ICollection<Guid> CategoryIds) : IRequest<Unit>;