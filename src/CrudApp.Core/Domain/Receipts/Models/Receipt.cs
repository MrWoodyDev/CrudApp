using CrudApp.Core.Domain.Products.Models;
using CrudApp.Core.Domain.Receipts.Data;

namespace CrudApp.Core.Domain.Receipts.Models;

public class Receipt
{
    private Receipt()
    {

    }

    public Receipt(ICollection<Product> products)
    {
        Products = products;
    }

    public long Id { get; set; }

    public ICollection<Product> Products { get; set; }

    public static async Task<Receipt> AddAsync(ICollection<Product> products)
    {
        var receipt = new Receipt(products);
        return receipt;
    }

    public async Task UpdateAsync(UpdateReceiptData data)
    {
        Products = data.Products;
    }
}