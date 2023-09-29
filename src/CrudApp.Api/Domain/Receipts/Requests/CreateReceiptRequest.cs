namespace CrudApp.Api.Domain.Receipts.Requests;

public record CreateReceiptRequest(ICollection<Guid> ProductIds);