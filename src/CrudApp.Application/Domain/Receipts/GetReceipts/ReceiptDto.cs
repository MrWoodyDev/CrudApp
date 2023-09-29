using CrudApp.Application.Domain.Categories.Queries.GetCategories;

namespace CrudApp.Application.Domain.Receipts.GetReceipts;

public record ReceiptDto
{
    public long ReceiptId { get; init; }

    public IReadOnlyCollection<ProductsDto> ProductsCollection { get; init; }
}