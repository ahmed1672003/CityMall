namespace CityMall.Application.Features.Users.Commands;
public sealed record RefreshjWTCommand(UpdateRefreshTokenDto Dto) : IRequest<ResponseModel<AuthDto>>;

