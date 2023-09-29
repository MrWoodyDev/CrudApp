using MediatR;

namespace CrudApp.Application.Domain.Receipts.Command.CreateReceipt;

public record CreateReceiptCommand(ICollection<long> ProductsId) : IRequest<long>;