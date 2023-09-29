using MediatR;

namespace CrudApp.Application.Domain.Products.Queries.GetProductById;

public record GetProductByIdQuery(long Id) : IRequest<ProductByIdDto>;