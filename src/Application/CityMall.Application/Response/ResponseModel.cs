namespace CityMall.Application.Response;
public class ResponseModel<TData>
{
    public ResponseModel(
        HttpStatusCode statusCode = default,
        bool isSucceeded = default,
        TData? data = default,
        object errors = default)
    {
        StatusCode = statusCode;
        IsSucceeded = isSucceeded;
        Data = data;
        Errors = errors;
    }
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSucceeded { get; set; }
    public string Message { get; set; }
    public object Errors { get; set; }
    public TData? Data { get; set; }
}
