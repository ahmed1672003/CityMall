
using CityMall.Application.Features.Stocks.Commands;
using CityMall.Application.Features.Stocks.Queries;

namespace CityMall.API.Controllers;

[ApiController]
[AllowAnonymous]
public class StockController : CityMallController
{
    public StockController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost(Router.Stocks.AddStock)]
    public async Task<IActionResult> AddStockAsync([Required][FromForm] AddStockCommand cmd) => CityMallResult(await Mediator.Send(cmd));

    [HttpPut(Router.Stocks.UpdateStock)]
    public async Task<IActionResult> UpdateStockAsync([Required][FromForm] UpdateStockCommand cmd) => CityMallResult(await Mediator.Send(cmd));

    [HttpPatch(Router.Stocks.DeleteStockById)]
    public async Task<IActionResult> DeleteStockByIdAsync([Required][MaxLength(64)][MinLength(64)] string stockId) =>
        CityMallResult(await Mediator.Send(new DeleteStockByIdCommand(stockId)));

    [HttpGet(Router.Stocks.GetStockById)]
    public async Task<IActionResult> GetStockByIdAsync([Required][MaxLength(64)][MinLength(64)] string stockId) =>
        CityMallResult(await Mediator.Send(new GetStockByIdQuery(stockId)));

    [HttpGet(Router.Stocks.GetAllStocks)]
    public async Task<IActionResult> GetAllStocksAsync() =>
        CityMallResult(await Mediator.Send(new GetAllStocksQuery()));

    [HttpGet(Router.Stocks.GetAllUnDeletedStocks)]
    public async Task<IActionResult> GetAllUnDeletedStocksAsync() =>
        CityMallResult(await Mediator.Send(new GetAllUnDeletedStocksQuery()));

}

