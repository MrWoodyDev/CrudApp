using MediatR;

namespace CrudApp.Application.Domain.Products.Queries.GetProducts;

public record GetProductsQuery(int PageNumber, int PageSize, Guid? CategoryId) : IRequest<(ProductDto[] data, int total)>;