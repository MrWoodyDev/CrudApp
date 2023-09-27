using CrudApp.Core.Domain.Products.Models;

namespace CrudApp.Core.Domain.Receipts.Models;

public class Receipt
{
    public long Id { get; set; }

    public ICollection<Product> Products { get; set; }
}