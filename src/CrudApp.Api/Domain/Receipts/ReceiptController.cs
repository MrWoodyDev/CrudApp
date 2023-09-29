using CrudApp.Api.Common;
using CrudApp.Api.Domain.Receipts.Requests;
using CrudApp.Application.Domain.Receipts.Command.CreateReceipt;
using CrudApp.Application.Domain.Receipts.Command.RemoveReceipt;
using CrudApp.Application.Domain.Receipts.Queries.GetReceiptById;
using CrudApp.Application.Domain.Receipts.Queries.GetReceipts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Api.Domain.Receipts;

[Route(Routs.Receipts)]
public class ReceiptController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReceiptController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ReceiptDto[]> GetReceiptsAsync(CancellationToken cancellationToken)
    {
        var query = new GetReceiptsQuery();
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ReceiptByIdDto> GetReceiptByIdAsync(long id, CancellationToken cancellationToken)
    {
        var query = new GetReceiptByIdQuery(id);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> PostReceiptAsync([FromBody]CreateReceiptRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateReceiptCommand(request.ProductIds);
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteReceiptAsync([FromBody] RemoveReceiptRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveReceiptCommand(request.Id);
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}