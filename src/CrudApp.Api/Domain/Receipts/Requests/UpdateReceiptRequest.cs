namespace CrudApp.Api.Domain.Receipts.Requests;

public record UpdateReceiptRequest(long Id, ICollection<long> Ids);