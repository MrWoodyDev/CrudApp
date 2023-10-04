using CrudApp.Application.Domain.Categories.Queries.GetCategories;

namespace CrudApp.Application.Domain.Categories.Queries.GetCategoryById;

public record CategoryByIdDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public IReadOnlyCollection<ProductsDto> ProductsCollection { get; set; }
}