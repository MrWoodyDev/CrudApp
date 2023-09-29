using CrudApp.Application.Domain.Categories.Queries.GetCategories;
using CrudApp.Persistence.CrudAppDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Categories.Queries;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, CategoryDto[]>
{
    private readonly CrudAppDbContext _context;

    public GetCategoriesQueryHandler(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto[]> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _context.Categories.AsNoTracking();
        var data = await sqlQuery
            .OrderByDescending(category => category.Id)
            .Include(category => category.Products)
            .Select(category => new CategoryDto
            {
                CategoryId = category.Id,
                Name = category.Name,
                ProductsCollection = category.Products.Select(products => new ProductsDto
                {
                    ProductId = products.Id,
                    Name = products.Name,
                    Price = products.Price,
                    Quantity = products.Quantity
                }).ToList(),
            }).ToArrayAsync(cancellationToken);
        return data;
    }
}