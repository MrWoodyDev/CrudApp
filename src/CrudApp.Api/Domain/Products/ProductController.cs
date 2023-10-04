using CrudApp.Api.Common;
using CrudApp.Api.Common.Responses;
using CrudApp.Api.Domain.Products.Requests;
using CrudApp.Application.Domain.Products.Commands.CreateProduct;
using CrudApp.Application.Domain.Products.Commands.RemoveProduct;
using CrudApp.Application.Domain.Products.Commands.UpdateProduct;
using CrudApp.Application.Domain.Products.Queries.GetProductById;
using CrudApp.Application.Domain.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Api.Domain.Products;

[Route(Routs.Products)]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<PaginationResponse<ProductDto[]>> GetProductsAsync(int pageNumber, int pageSize, Guid categoryId, CancellationToken cancellationToken)
    {
        var query = new GetProductsQuery(pageNumber, pageSize, categoryId);
        var response = await _mediator.Send(query, cancellationToken);
        return new PaginationResponse<ProductDto[]>(response.data, response.total);
    }

    [HttpGet("{id}")]
    public async Task<ProductByIdDto> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> PostProductAsync([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateProductCommand(request.Name, request.Price, request.Quantity, request.CategoriesId);
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> PutProductAsync([FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateProductCommand(request.Id, request.Name, request.Price, request.Quantity, request.CategoriesId);
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] RemoveProductRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveProductCommand(request.Id);
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}