namespace CrudApp.Application.Domain.Products.Queries.GetProducts;

public record ProductDto
{
    public long ProductId { get; init; }

    public string Name { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; init; }

    public IReadOnlyCollection<CategoriesDto> CategoriesCollection { get; init; }
}