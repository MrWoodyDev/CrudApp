using CrudApp.Core.Common;
using CrudApp.Core.Domain.Receipts.Common;
using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.RemoveReceipt;

public class RemoveReceiptCommandHandler : IRequestHandler<RemoveReceiptCommand, Unit>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveReceiptCommandHandler(IReceiptRepository receiptRepository, IUnitOfWork unitOfWork)
    {
        _receiptRepository = receiptRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveReceiptCommand request, CancellationToken cancellationToken)
    {
        await _receiptRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}