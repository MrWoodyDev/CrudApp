namespace CrudApp.Application.Domain.Categories.Queries.GetCategories;

public record CategoryDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public IReadOnlyCollection<ProductsDto> ProductsCollection { get; init; }
}