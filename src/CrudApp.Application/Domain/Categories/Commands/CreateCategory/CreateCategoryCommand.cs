using MediatR;

namespace CrudApp.Application.Domain.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name) : IRequest<Guid>;