
namespace CityMall.Application.Features.Stocks.Commands.Handler;
public sealed class StockCommandsHanler
    : IRequestHandler<AddStockCommand, ResponseModel<string>>,
      IRequestHandler<UpdateStockCommand, ResponseModel<string>>,
    IRequestHandler<DeleteStockByIdCommand, ResponseModel<string>>
{

    private readonly IUnitOfServices _services;

    public StockCommandsHanler(IUnitOfServices services)
    {
        _services = services;
    }

    public async Task<ResponseModel<string>> Handle(AddStockCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _services.Stocks.AddAsync(request.Dto, cancellationToken);

            return ResponseResult.Created<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<string>> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Stocks.AnyByIdAsync(request.Dto.Id))
                return ResponseResult.NotFound<string>();

            await _services.Stocks.UpdateAsync(request.Dto, cancellationToken);
            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<string>> Handle(DeleteStockByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Stocks.AnyByIdAsync(request.Id))
                return ResponseResult.NotFound<string>();

            await _services.Stocks.DeleteByIdAsync(request.Id, cancellationToken);
            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
}
