using MediatR;

namespace CrudApp.Application.Domain.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(long Id) : IRequest<CategoryByIdDto>;