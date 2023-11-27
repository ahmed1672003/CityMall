using CityMall.Application.Features.Email.Queries;

namespace CityMall.API.Controllers;
[ApiController]
[AllowAnonymous]
public class EmailsController : CityMallController
{
    public EmailsController(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// send email to all users
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpPatch(Router.Emails.SendEmailsToAllUsers)]
    public async Task<IActionResult> SendEmailsToAllUsers([FromForm] SendEmailsQuery query) =>
         CityMallResult(await Mediator.Send(query));


}
