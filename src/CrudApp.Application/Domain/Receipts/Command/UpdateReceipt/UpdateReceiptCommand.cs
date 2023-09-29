using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.UpdateReceipt;

public record UpdateReceiptCommand(long Id, ICollection<long> ProductIds) : IRequest<Unit>;