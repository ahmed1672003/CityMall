namespace CityMall.Application.Features.Addresses.Commands;

public sealed record UpdateAddressCommand(UpdateAddressDto Dto) : IRequest<ResponseModel<string>>;
