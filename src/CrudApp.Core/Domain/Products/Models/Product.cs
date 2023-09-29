using CrudApp.Core.Domain.Categories.Models;
using CrudApp.Core.Domain.Products.Data;
using CrudApp.Core.Domain.Receipts.Models;

namespace CrudApp.Core.Domain.Products.Models;

public class Product
{
    private Product()
    {

    }

    public Product(
        Guid id,
        string name, 
        decimal price, 
        int quantity,
        ICollection<Category> categories)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        Categories = categories;
    }

    public Guid Id { get; private set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public ICollection<Category> Categories { get; set; }

    public ICollection<Receipt> Receipts { get; set; }

    public static async Task<Product> CreateAsync(string name, decimal price, int quantity, ICollection<Category> categories)
    {
        var product = new Product(Guid.NewGuid(), name, price, quantity, categories);
        return product;
    }

    public async Task UpdateAsync(UpdateProductData data)
    {
        Name = data.Name;
        Price = data.Price;
        Quantity = data.Quantity;
        Categories = data.Categories;
    }
}