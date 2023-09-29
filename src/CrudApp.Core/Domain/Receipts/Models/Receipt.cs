using CrudApp.Core.Domain.Products.Models;
using CrudApp.Core.Domain.Receipts.Data;

namespace CrudApp.Core.Domain.Receipts.Models;

public class Receipt
{
    private Receipt()
    {

    }

    public Receipt(Guid id, ICollection<Product> products)
    {
        Id = id;
        Products = products;
    }

    public Guid Id { get; set; }

    public ICollection<Product> Products { get; set; }

    public static async Task<Receipt> AddAsync(ICollection<Product> products)
    {
        var receipt = new Receipt(Guid.NewGuid(), products);
        return receipt;
    }

    public async Task UpdateAsync(UpdateReceiptData data)
    {
        Products = data.Products;
    }
}