namespace CityMall.Application.Response;
public sealed class ResponseResult
{
    public static ResponseModel<TData> Success<TData>(TData data = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.OK, isSucceeded: true, data: data, errors: errors);

    public static ResponseModel<TData> Created<TData>(TData data = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.Created, isSucceeded: true, data: data, errors: errors);

    public static ResponseModel<TData> NotFound<TData>(TData data = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.NotFound, isSucceeded: true, data: data, errors: errors);

    public static ResponseModel<TData> BadRequest<TData>(TData data = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.BadRequest, isSucceeded: false, data: data, errors: errors);

    public static ResponseModel<TData> UnAuthorized<TData>(TData data = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.Unauthorized, isSucceeded: false, data: data, errors: errors);

    public static ResponseModel<TData> InternalServerError<TData>(TData data = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.InternalServerError, isSucceeded: false, data: data, errors: errors);

    public static ResponseModel<TData> Conflict<TData>(TData data = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.Conflict, isSucceeded: false, data: data, errors: errors);
}
