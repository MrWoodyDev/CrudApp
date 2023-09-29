using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.RemoveReceipt;

public record RemoveReceiptCommand(long Id) : IRequest<Unit>;