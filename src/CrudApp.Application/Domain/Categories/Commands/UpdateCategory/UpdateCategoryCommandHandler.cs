using CrudApp.Core.Common;
using CrudApp.Core.Domain.Categories.Common;
using CrudApp.Core.Domain.Categories.Data;
using MediatR;

namespace CrudApp.Application.Domain.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var original = await _categoryRepository.FindAsync(request.Id);
        var data = new UpdateCategoryData(request.Name);
        await original.UpdateAsync(data);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}