using CrudApp.Core.Common;
using CrudApp.Core.Domain.Products.Common;
using CrudApp.Core.Domain.Receipts.Common;
using CrudApp.Core.Domain.Receipts.Data;
using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.UpdateReceipt;

public class UpdateReceiptCommandHandler : IRequestHandler<UpdateReceiptCommand, Unit>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReceiptCommandHandler(IReceiptRepository receiptRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _receiptRepository = receiptRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateReceiptCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.FindByIdsAsync(request.ProductIds);
        var original = await _receiptRepository.FindAsync(request.Id);
        var data = new UpdateReceiptData(products);
        await original.UpdateAsync(data);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}