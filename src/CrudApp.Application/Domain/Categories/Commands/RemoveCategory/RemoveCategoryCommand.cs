using MediatR;

namespace CrudApp.Application.Domain.Categories.Commands.RemoveCategory;

public record RemoveCategoryCommand(long Id) : IRequest<Unit>;