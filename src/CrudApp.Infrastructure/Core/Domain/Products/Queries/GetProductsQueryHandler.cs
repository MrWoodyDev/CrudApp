using CrudApp.Application.Domain.Products.Queries.GetProducts;
using CrudApp.Persistence.CrudAppDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Products.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, (ProductDto[] data, int total)>
{
    private readonly CrudAppDbContext _context;

    public GetProductsQueryHandler(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<(ProductDto[] data, int total)> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _context.Products.AsNoTracking();
        var skip = (request.PageNumber - 1) * request.PageSize;
        var data = await sqlQuery
            .OrderByDescending(product => product.Id)
            .Include(product => product.Categories)
            .Skip(skip)
            .Take(request.PageSize)
            .Select(product => new ProductDto
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoriesCollection = product.Categories.Select(category => new CategoriesDto
                {
                    CategoryId = category.Id,
                    Name = category.Name
                }).ToList(),
            }).ToArrayAsync(cancellationToken);

        var total = await sqlQuery
            .OrderByDescending(product => product.Id)
            .Include(product => product.Categories)
            .CountAsync(cancellationToken);
        return (data, total);
    }
}