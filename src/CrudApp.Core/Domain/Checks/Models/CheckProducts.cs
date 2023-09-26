using CrudApp.Core.Domain.Products.Models;

namespace CrudApp.Core.Domain.Checks.Models;

public class CheckProducts
{
    public long CheckId { get; private set; }

    public Check Check { get; set; }

    public long ProductId { get; private set; }

    public Product Product { get; set; }
}