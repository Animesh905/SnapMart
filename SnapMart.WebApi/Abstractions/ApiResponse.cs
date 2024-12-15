namespace SnapMart.WebApi.Abstractions;

public class ApiResponse<T>
{
    public string Message { get; set; }
    public T Data { get; set; }
    public int StatusCode { get; set; }
    public T Errors { get; set; } // To hold validation or error messages
}
