using CityMall.Application.Features.Customers.Commands;
using CityMall.Application.Features.Customers.Queries;

namespace CityMall.API.Controllers;

[ApiController]
[AllowAnonymous]
public class CustomerController : CityMallController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public CustomerController(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// add customer
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPost(Router.Customer.AddCustomer)]
    public async Task<IActionResult> AddCustomerAsync([FromForm] AddCustomerCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));


    /// <summary>
    /// update customer
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPut(Router.Customer.UpdateCustomer)]
    public async Task<IActionResult> UpdateCustomerAsync([FromForm] UpdateCustommerCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));

    /// <summary>
    /// delete customer
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPatch(Router.Customer.DeleteCustomer)]
    public async Task<IActionResult> DeleteCustomerAsync([Required][MaxLength(64)][MinLength(64)] string customerId) =>
        CityMallResult(await Mediator.Send(new DeleteCustomerCommand(customerId)));


    /// <summary>
    /// get by id
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet(Router.Customer.GetById)]
    public async Task<IActionResult> GetByIdAsync(string customerId) =>
        CityMallResult(await Mediator.Send(new GetCustomerByIdQuery(customerId)));

    /// <summary>
    /// get all 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet(Router.Customer.GetAll)]
    public async Task<IActionResult> GetAllAsync() =>
        CityMallResult(await Mediator.Send(new GetAllCustomersQuery()));

    /// <summary>
    /// get all deleted
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet(Router.Customer.GetAllDeleted)]
    public async Task<IActionResult> GetAllDeletedAsync() =>
        CityMallResult(await Mediator.Send(new GetAllDeletedCustomersQuery()));

    /// <summary>
    /// get all un deleted
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet(Router.Customer.GetAllUnDeleted)]
    public async Task<IActionResult> GetAllUnDeletedAsync() =>
        CityMallResult(await Mediator.Send(new GetAllUnDeletedCustomersQuery()));
}
