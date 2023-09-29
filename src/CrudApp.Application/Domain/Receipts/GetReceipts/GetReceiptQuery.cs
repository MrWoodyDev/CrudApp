using MediatR;

namespace CrudApp.Application.Domain.Receipts.GetReceipts;

public record GetReceiptQuery() : IRequest<ReceiptDto[]>;