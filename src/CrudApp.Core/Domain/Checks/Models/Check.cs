namespace CrudApp.Core.Domain.Checks.Models;

public class Check
{
    private Check()
    {

    }

    public long Id { get; set; }

    public IReadOnlyCollection<CheckProducts> CheckProducts { get; set; }
}