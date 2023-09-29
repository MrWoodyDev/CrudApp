using MediatR;

namespace CrudApp.Application.Domain.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(Guid Id, string Name) : IRequest<Unit>;