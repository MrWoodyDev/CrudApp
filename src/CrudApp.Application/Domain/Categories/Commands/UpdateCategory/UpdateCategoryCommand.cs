using MediatR;

namespace CrudApp.Application.Domain.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(long Id, string Name) : IRequest<Unit>;