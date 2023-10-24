using System.ComponentModel.DataAnnotations;

namespace CityMall.Application.Features.Users.Commands;
public sealed record ConfirmeEmailCommand([Required] string UserId, [Required] string Token) : IRequest<ResponseModel<string>>;