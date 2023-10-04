using CrudApp.Application.Domain.Categories.Queries.GetCategories;
using CrudApp.Application.Domain.Categories.Queries.GetCategoryById;
using CrudApp.Persistence.CrudAppDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryByIdDto>
{
    private readonly CrudAppDbContext _context;

    public GetCategoryByIdQueryHandler(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryByIdDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _context.Categories.AsNoTracking();
        var data = await sqlQuery
            .OrderByDescending(category => category.Id)
            .Include(category => category.Products)
            .Select(category => new CategoryByIdDto
            {
                Id = category.Id,
                Name = category.Name,
                ProductsCollection = category.Products.Select(product => new ProductsDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity
                }).ToList()
            }).FirstOrDefaultAsync(category => category.Id == request.Id, cancellationToken);
        return data;
    }
}