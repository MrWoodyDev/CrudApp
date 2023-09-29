using MediatR;

namespace CrudApp.Application.Domain.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductByIdDto>;