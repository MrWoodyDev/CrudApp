using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.RemoveProduct;

public record RemoveProductCommand(Guid Id) : IRequest<Unit>;