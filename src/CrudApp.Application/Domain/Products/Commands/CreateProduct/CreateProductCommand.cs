using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, decimal Price, int Quantity, ICollection<Guid> CategoryIds) : IRequest<Guid>;