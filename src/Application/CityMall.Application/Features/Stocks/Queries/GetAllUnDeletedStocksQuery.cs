using CityMall.Dtos.Dtos.Stocks;

namespace CityMall.Application.Features.Stocks.Queries;
public sealed record GetAllUnDeletedStocksQuery() : IRequest<ResponseModel<IEnumerable<GetStockDto>>>;
