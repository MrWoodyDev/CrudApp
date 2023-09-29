using MediatR;

namespace CrudApp.Application.Domain.Receipts.Queries.GetReceiptById;

public record GetReceiptByIdQuery(Guid Id) : IRequest<ReceiptByIdDto>;