using CrudApp.Core.Domain.Categories.Models;

namespace CrudApp.Core.Domain.Products.Data;

public record UpdateProductData(string Name, decimal Price, int Quantity, ICollection<Category> Categories);