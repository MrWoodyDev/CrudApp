using CrudApp.Api.Common;
using CrudApp.Api.Domain.Categories.Requests;
using CrudApp.Application.Domain.Categories.Commands.CreateCategory;
using CrudApp.Application.Domain.Categories.Commands.RemoveCategory;
using CrudApp.Application.Domain.Categories.Commands.UpdateCategory;
using CrudApp.Application.Domain.Categories.Queries.GetCategories;
using CrudApp.Application.Domain.Categories.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Api.Domain.Categories;

[Route(Routs.Categories)]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<CategoryDto[]> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        var query = new GetCategoriesQuery();
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<CategoryByIdDto> GetCategoryByIdAsync(long id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByIdQuery(id);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> PostCategoryAsync([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateCategoryCommand(request.Name);
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> PutCategoryAsync([FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateCategoryCommand(request.Id, request.Name);
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategoryAsync([FromBody] RemoveCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RemoveCategoryCommand(request.Id);
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}