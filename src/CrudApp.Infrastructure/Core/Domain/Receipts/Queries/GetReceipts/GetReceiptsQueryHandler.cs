using CrudApp.Application.Domain.Products.Queries.GetProducts;
using CrudApp.Application.Domain.Receipts.Queries.GetReceipts;
using CrudApp.Persistence.CrudAppDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Receipts.Queries.GetReceipts;

public class GetReceiptsQueryHandler : IRequestHandler<GetReceiptsQuery, ReceiptDto[]>
{
    private readonly CrudAppDbContext _context;

    public GetReceiptsQueryHandler(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<ReceiptDto[]> Handle(GetReceiptsQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _context.Receipts.AsNoTracking();
        var data = await sqlQuery
            .OrderByDescending(receipt => receipt.Id)
            .Include(receipt => receipt.Products)
            .Select(receipt => new ReceiptDto
            {
                Id = receipt.Id,
                ProductsCollection = receipt.Products.Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                        CategoriesCollection = product.Categories.Select(category => new CategoriesDto
                    {
                        Id = category.Id,
                        Name = category.Name
                    }).ToList()
                }).ToList(),
            }).ToArrayAsync(cancellationToken);
        return data;
    }
}