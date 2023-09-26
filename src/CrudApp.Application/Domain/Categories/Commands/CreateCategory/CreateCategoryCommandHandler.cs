using CrudApp.Core.Common;
using CrudApp.Core.Domain.Categories.Common;
using CrudApp.Core.Domain.Categories.Models;
using MediatR;

namespace CrudApp.Application.Domain.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, long>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await Category.CreateAsync(request.Name);
        await _categoryRepository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}