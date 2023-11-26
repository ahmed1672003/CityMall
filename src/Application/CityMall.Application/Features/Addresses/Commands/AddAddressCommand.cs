namespace CityMall.Application.Features.Addresses.Commands;
public sealed record AddAddressCommand(AddAddressDto Dto) : IRequest<ResponseModel<string>>;
