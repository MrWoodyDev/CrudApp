using CrudApp.Core.Domain.Products.Models;

namespace CrudApp.Core.Domain.Receipts.Data;

public record UpdateReceiptData(ICollection<Product> Products);