using CrudApp.Persistence.CrudAppDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudApp.Persistence;

public static class PersistenceRegistration
{
    private const string ConnectionString = "CrudAppDb";

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString)
                               ?? throw new AggregateException($"Connection string: '{ConnectionString}' is not found in configurations.");

        services.AddDbContext<CrudAppDbContext>(options =>
            options.UseSqlServer(connectionString));
    }
}