using CrudApp.Core.Domain.Products.Models;

namespace CrudApp.Core.Domain.Checks.Models;

public class Check
{
    private Check()
    {

    }

    public long Id { get; set; }

    public ICollection<Product> Products { get; set; }
}