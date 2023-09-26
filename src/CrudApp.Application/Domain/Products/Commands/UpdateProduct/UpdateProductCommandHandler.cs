using CrudApp.Core.Common;
using CrudApp.Core.Domain.Products.Common;
using CrudApp.Core.Domain.Products.Data;
using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var original = await _productRepository.FindAsync(request.Id);
        var data = new UpdateProductData(request.Name, request.Price, request.Quantity);
        await original.UpdateAsync(data);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}