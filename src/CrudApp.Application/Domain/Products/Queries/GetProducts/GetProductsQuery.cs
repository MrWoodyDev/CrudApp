using MediatR;

namespace CrudApp.Application.Domain.Products.Queries.GetProducts;

public record GetProductsQuery(int PageNumber, int PageSize) : IRequest<(ProductDto[] data, int total)>;