using CrudApp.Core.Domain.Checks.Models;
using CrudApp.Core.Domain.Products.Data;

namespace CrudApp.Core.Domain.Products.Models;

public class Product
{
    private Product()
    {
        
    }

    public Product(
        string name, 
        decimal price, 
        int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public long Id { get; private set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public IReadOnlyCollection<ProductCategory> ProductCategory { get; set; }

    public IReadOnlyCollection<CheckProducts> CheckProducts { get; set; }

    public static async Task<Product> CreateAsync(string name, decimal price, int quantity)
    {
        var product = new Product(name, price, quantity);
        return product;
    }

    public async Task UpdateAsync(UpdateProductData data)
    {
        Name = data.Name;
        Price = data.Price;
        Quantity = data.Quantity;
    }
}