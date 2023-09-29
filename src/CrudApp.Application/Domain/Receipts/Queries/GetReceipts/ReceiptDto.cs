using CrudApp.Application.Domain.Products.Queries.GetProducts;

namespace CrudApp.Application.Domain.Receipts.Queries.GetReceipts;

public record ReceiptDto
{
    public long ReceiptId { get; init; }

    public IReadOnlyCollection<ProductDto> ProductsCollection { get; init; }
}