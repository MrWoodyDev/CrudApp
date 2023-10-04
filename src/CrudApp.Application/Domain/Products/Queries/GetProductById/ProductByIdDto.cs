using CrudApp.Application.Domain.Products.Queries.GetProducts;

namespace CrudApp.Application.Domain.Products.Queries.GetProductById;

public record ProductByIdDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; init; }

    public IReadOnlyCollection<CategoriesDto> CategoriesCollection { get; init; }
}