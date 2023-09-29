using MediatR;

namespace CrudApp.Application.Domain.Categories.Queries.GetCategories;

public record GetCategoriesQuery() : IRequest<CategoryDto[]>;