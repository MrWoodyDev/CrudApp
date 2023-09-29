namespace CrudApp.Application.Domain.Categories.Queries.GetCategories;

public record ProductsDto
{
    public Guid ProductId { get; init; }

    public string Name { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; init; }
}