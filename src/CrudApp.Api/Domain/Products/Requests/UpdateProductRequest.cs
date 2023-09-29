namespace CrudApp.Api.Domain.Products.Requests;

public record UpdateProductRequest(long Id, string Name, decimal Price, int Quantity, ICollection<long> CategoriesId);