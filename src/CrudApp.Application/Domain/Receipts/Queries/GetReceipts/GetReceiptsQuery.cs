using MediatR;

namespace CrudApp.Application.Domain.Receipts.Queries.GetReceipts;

public record GetReceiptsQuery() : IRequest<ReceiptDto[]>;