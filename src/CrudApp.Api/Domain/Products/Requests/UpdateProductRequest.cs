namespace CrudApp.Api.Domain.Products.Requests;

public record UpdateProductRequest(Guid Id, string Name, decimal Price, int Quantity, ICollection<Guid> CategoriesId);