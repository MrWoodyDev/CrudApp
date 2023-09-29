using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.RemoveReceipt;

public record RemoveReceiptCommand(Guid Id) : IRequest<Unit>;