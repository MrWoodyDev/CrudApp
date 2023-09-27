using CrudApp.Core.Common;
using CrudApp.Core.Domain.Categories.Common;
using CrudApp.Core.Domain.Checks.Common;
using CrudApp.Core.Domain.Products.Common;
using CrudApp.Infrastructure.Core.Common;
using CrudApp.Infrastructure.Core.Domain.Categories;
using CrudApp.Infrastructure.Core.Domain.Checks;
using CrudApp.Infrastructure.Core.Domain.Products.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrudApp.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureRegistration(this IServiceCollection services)
    {
        services.AddMediatR(typeof(InfrastructureRegistration));

        //UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICheckRepository, CheckRepository>();
    }
}