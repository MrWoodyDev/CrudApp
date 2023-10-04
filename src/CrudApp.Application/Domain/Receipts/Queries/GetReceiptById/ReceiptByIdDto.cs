using CrudApp.Application.Domain.Products.Queries.GetProducts;

namespace CrudApp.Application.Domain.Receipts.Queries.GetReceiptById;

public record ReceiptByIdDto
{
    public Guid Id { get; init; }

    public IReadOnlyCollection<ProductDto> ProductsCollection { get; init; }
}