namespace CityMall.Application.Features.Addresses.Commands;

public sealed record DeleteAddressCommand(string Id) : IRequest<ResponseModel<string>>;
