using MediatR;

namespace CrudApp.Application.Domain.Receipts.Queries.GetReceiptById;

public record GetReceiptByIdQuery(long Id) : IRequest<ReceiptByIdDto>;