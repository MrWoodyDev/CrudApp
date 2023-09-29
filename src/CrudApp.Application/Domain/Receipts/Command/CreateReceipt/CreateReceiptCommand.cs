using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.CreateReceipt;

public record CreateReceiptCommand(ICollection<Guid> ProductsId) : IRequest<Guid>;