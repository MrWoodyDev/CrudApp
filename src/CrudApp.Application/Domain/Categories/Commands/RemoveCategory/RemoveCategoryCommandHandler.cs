using CrudApp.Core.Common;
using CrudApp.Core.Domain.Categories.Common;
using MediatR;

namespace CrudApp.Application.Domain.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}