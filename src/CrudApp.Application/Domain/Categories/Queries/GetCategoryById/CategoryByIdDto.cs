using CrudApp.Application.Domain.Categories.Queries.GetCategories;

namespace CrudApp.Application.Domain.Categories.Queries.GetCategoryById;

public record CategoryByIdDto
{
    public long CategoryId { get; set; }

    public string Name { get; set; }

    public IReadOnlyCollection<ProductsDto> ProductsCollection { get; set; }
}