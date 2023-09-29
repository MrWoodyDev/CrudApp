using MediatR;

namespace CrudApp.Application.Domain.Categories.Commands.RemoveCategory;

public record RemoveCategoryCommand(Guid Id) : IRequest<Unit>;