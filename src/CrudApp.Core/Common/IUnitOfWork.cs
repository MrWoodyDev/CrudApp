namespace CrudApp.Core.Common;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}