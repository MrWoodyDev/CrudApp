using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.UpdateReceipt;

public record UpdateReceiptCommand(Guid Id, ICollection<Guid> ProductIds) : IRequest<Unit>;