using CrudApp.Core.Common;
using CrudApp.Core.Domain.Products.Common;
using CrudApp.Core.Domain.Receipts.Common;
using CrudApp.Core.Domain.Receipts.Models;
using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.CreateReceipt;

public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, long>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReceiptCommandHandler(IReceiptRepository receiptRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _receiptRepository = receiptRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.FindByIdsAsync(request.ProductsId);
        var receipt = await Receipt.AddAsync(products);
        await _receiptRepository.AddAsync(receipt);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return receipt.Id;
    }
}