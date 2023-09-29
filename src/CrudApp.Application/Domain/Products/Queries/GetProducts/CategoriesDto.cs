namespace CrudApp.Application.Domain.Products.Queries.GetProducts;

public record CategoriesDto
{
    public long CategoryId { get; init; }

    public string Name { get; init; }
}