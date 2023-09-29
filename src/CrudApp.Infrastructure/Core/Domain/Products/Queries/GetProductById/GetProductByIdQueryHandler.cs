using CrudApp.Application.Domain.Products.Queries.GetProductById;
using CrudApp.Application.Domain.Products.Queries.GetProducts;
using CrudApp.Persistence.CrudAppDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Infrastructure.Core.Domain.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductByIdDto>
{

    private readonly CrudAppDbContext _context;

    public GetProductByIdQueryHandler(CrudAppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductByIdDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _context.Products.AsNoTracking();
        var data = await sqlQuery
            .OrderByDescending(product => product.Id)
            .Include(product => product.Categories)
            .Select(product => new ProductByIdDto
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
            }).FirstOrDefaultAsync(product => product.ProductId == request.Id, cancellationToken);
        return data;
    }
}