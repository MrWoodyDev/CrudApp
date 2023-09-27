using CrudApp.Core.Domain.Categories.Models;
using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, decimal Price, int Quantity) : IRequest<long>;