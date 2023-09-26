using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.RemoveProduct;

public record RemoveProductCommand(long Id) : IRequest<Unit>;