using CityMall.Dtos.Dtos.Stocks;

namespace CityMall.Application.Features.Stocks.Queries.Handler;
public sealed class StockQueriesHandler :
    IRequestHandler<GetAllStocksQuery, ResponseModel<IEnumerable<GetStockDto>>>,
    IRequestHandler<GetAllUnDeletedStocksQuery, ResponseModel<IEnumerable<GetStockDto>>>,
    IRequestHandler<GetStockByIdQuery, ResponseModel<GetStockDto>>
{
    private readonly IUnitOfServices _services;

    public StockQueriesHandler(IUnitOfServices services)
    {
        _services = services;
    }

    public async Task<ResponseModel<IEnumerable<GetStockDto>>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Stocks.GetAllAsync());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetStockDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetStockDto>>> Handle(GetAllUnDeletedStocksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Stocks.GetAllUnDeletedAsync());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetStockDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<GetStockDto>> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Stocks.AnyByIdAsync(request.Id, cancellationToken))
                return ResponseResult.NotFound<GetStockDto>();

            return ResponseResult.Success(await _services.Stocks.GetByIdAsync(request.Id, cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetStockDto>(errors: ex.Message);
        }

    }
}
