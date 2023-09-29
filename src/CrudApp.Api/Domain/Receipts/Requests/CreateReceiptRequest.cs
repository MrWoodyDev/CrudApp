namespace CrudApp.Api.Domain.Receipts.Requests;

public record CreateReceiptRequest(ICollection<long> ProductIds);