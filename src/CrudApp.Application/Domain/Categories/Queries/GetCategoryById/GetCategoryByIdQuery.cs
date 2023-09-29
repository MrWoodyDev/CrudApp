using MediatR;

namespace CrudApp.Application.Domain.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryByIdDto>;