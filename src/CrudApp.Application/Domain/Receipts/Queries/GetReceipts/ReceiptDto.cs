using CrudApp.Application.Domain.Products.Queries.GetProducts;

namespace CrudApp.Application.Domain.Receipts.Queries.GetReceipts;

public record ReceiptDto
{
    public Guid Id { get; init; }

    public IReadOnlyCollection<ProductDto> ProductsCollection { get; init; }
}