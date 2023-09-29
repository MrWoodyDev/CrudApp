using CrudApp.Application.Domain.Products.Queries.GetProducts;
using CrudApp.Application.Domain.Receipts.Queries.GetReceiptById;
using CrudApp.Persistence.CrudAppDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Receipts.Queries.GetReceiptById;

public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, ReceiptByIdDto>
{
    private readonly CrudAppDbContext _context;

    public GetReceiptByIdQueryHandler(CrudAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ReceiptByIdDto> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _context.Receipts.AsNoTracking();
        var data = await sqlQuery
            .OrderByDescending(receipt => receipt.Id)
            .Include(receipt => receipt.Products)
            .Select(receipt => new ReceiptByIdDto
            {
                ReceiptId = receipt.Id,
                ProductsCollection = receipt.Products.Select(product => new ProductDto
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CategoriesCollection = product.Categories.Select(category => new CategoriesDto
                    {
                        CategoryId = category.Id,
                        Name = category.Name
                    }).ToList()
                }).ToList()
            }).FirstOrDefaultAsync(receipt => receipt.ReceiptId == request.Id, cancellationToken);
        return data;
    }
}