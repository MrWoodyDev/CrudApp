namespace CrudApp.Api.Common.Responses;

public class PaginationResponse<T>
{
    public PaginationResponse(T data, int total)
    {
        Data = data;
        Total = total;
    }

    public T Data { get; set; }

    public int Total { get; set; }
}