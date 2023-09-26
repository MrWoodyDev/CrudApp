using CrudApp.Core.Common;
using CrudApp.Core.Domain.Products.Common;
using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.RemoveProduct;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}