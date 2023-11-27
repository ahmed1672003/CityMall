using CityMall.Dtos.Dtos.Stocks;

namespace CityMall.Application.Features.Stocks.Queries;
public sealed record GetStockByIdQuery(string Id) : IRequest<ResponseModel<GetStockDto>>;
