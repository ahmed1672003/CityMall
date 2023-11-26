
using CityMall.Application.Features.Addresses.Commands;
using CityMall.Dtos.Dtos.Addresses;

namespace CityMall.API.Controllers;

[AllowAnonymous]
[ApiController]
public class AddressController : CityMallController
{
    public AddressController(IMediator mediator) : base(mediator) { }
    /// <summary>
    /// add address
    /// </summary>
    /// <param name="Dto"></param>
    /// <returns></returns>
    [HttpPost(Router.Address.AddAddress)]
    public async Task<IActionResult> AddAddress([Required][FromForm] AddAddressDto Dto) => CityMallResult(await Mediator.Send(new AddAddressCommand(Dto)));

    /// <summary>
    /// update address
    /// </summary>
    /// <param name="Dto"></param>
    /// <returns></returns>
    [HttpPut(Router.Address.UpdateAddress)]
    public async Task<IActionResult> UpdateAddress([Required][FromForm] UpdateAddressDto Dto) => CityMallResult(await Mediator.Send(new UpdateAddressCommand(Dto)));

    /// <summary>
    /// delete address by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch(Router.Address.DeleteAddress)]
    public async Task<IActionResult> DeleteAddressById([Required][StringLength(64)][FromQuery] string id) => CityMallResult(await Mediator.Send(new DeleteAddressCommand(id)));
}
