using CrudApp.Application.Domain.Categories.Queries.GetCategories;
using CrudApp.Application.Domain.Receipts.GetReceipts;
using CrudApp.Persistence.CrudAppDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Receipts.Queries;

public class GetReceiptQueryHandler : IRequestHandler<GetReceiptQuery, ReceiptDto[]>
{
    private readonly CrudAppDbContext _context;

    public GetReceiptQueryHandler(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<ReceiptDto[]> Handle(GetReceiptQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _context.Receipts.AsNoTracking();
        var data = await sqlQuery
            .OrderByDescending(receipt => receipt.Id)
            .Include(receipt => receipt.Products)
            .Select(receipt => new ReceiptDto
            {
                ReceiptId = receipt.Id,
                ProductsCollection = receipt.Products.Select(product => new ProductsDto
                {
                    ProductId = product.Id,
                    Name = product.Name
                }).ToList(),
            }).ToArrayAsync(cancellationToken);
        return data;
    }
}