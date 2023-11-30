using System.Net;

using CityMall.Application.Response;

namespace CityMall.API.Controllers;
/// <summary>
/// 
/// </summary>
[ApiController]
public class CityMallController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public CityMallController(IMediator mediator) => Mediator = mediator;

    /// <summary>
    /// 
    /// </summary>
    public IMediator Mediator { get; }

    #region Results 
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <param name="response"></param>
    /// <returns></returns>
    public IActionResult CityMallResult<TData>(ResponseModel<TData> response) where TData : class
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                return new OkObjectResult(response);

            case HttpStatusCode.NotFound:
                return new NotFoundObjectResult(response);

            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(response);

            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(response);

            case HttpStatusCode.Conflict:
                return new ConflictObjectResult(response);

            case HttpStatusCode.Created:
                return new CreatedResult("server", response);

            case HttpStatusCode.NoContent:
                return new NoContentResult();

            case HttpStatusCode.Accepted:
                return new AcceptedResult("server", response);

            case HttpStatusCode.Forbidden:
                return new ForbidResult("Bearer");
            default:
                return new ObjectResult(response)
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                };
        }
    }
    #endregion
}
