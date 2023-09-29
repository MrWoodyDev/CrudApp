namespace CrudApp.Api.Domain.Products.Requests;

public record CreateProductRequest(string Name, decimal Price, int Quantity, ICollection<Guid> CategoriesId);