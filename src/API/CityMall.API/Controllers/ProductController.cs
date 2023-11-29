
using CityMall.Application.Features.ProductImages.Commands;
using CityMall.Application.Features.ProductImages.Queries;
using CityMall.Application.Features.Products.Commands;
using CityMall.Application.Features.Products.Queries;
using CityMall.Services.Services;

namespace CityMall.API.Controllers;

[AllowAnonymous]
[ApiController]
public class ProductController : CityMallController
{
    public ProductController(IMediator mediator) : base(mediator) { }

    [HttpPost(Router.Products.AddProduct)]
    public async Task<IActionResult> AddProductAsync([FromBody] AddProductCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));

    [HttpPost(Router.Products.AddProductImages)]
    public async Task<IActionResult> AddProductImagesAsync([FromForm] AddProductImagesCommand cmd) => CityMallResult(await Mediator.Send(cmd));


    [HttpPut(Router.Products.UpdateProduct)]
    public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));

    [HttpPatch(Router.Products.DeleteProductById)]
    public async Task<IActionResult> DeleteProductByIdAsync([FromQuery][Required][MaxLength(64)][MinLength(64)] string productId) =>
        CityMallResult(await Mediator.Send(new DeleteProductCommand(productId)));


    [HttpGet(Router.Products.GetProductById)]
    public async Task<IActionResult> GetProductByIdAsync([FromQuery][Required][MaxLength(64)][MinLength(64)] string productId) =>
        CityMallResult(await Mediator.Send(new GetProductByIdQuery(productId)));

    [HttpGet(Router.Products.GetAllDeletedProducts)]
    public async Task<IActionResult> GetAllDeletedProductsAsync() =>
        CityMallResult(await Mediator.Send(new GetAllDeletedProductsQuery()));

    [HttpGet(Router.Products.GetAllUnDeletedProducts)]
    public async Task<IActionResult> GetAllUnDeletedProductsAsync() =>
        CityMallResult(await Mediator.Send(new GetAllUnDeletedProductsQuery()));

    [HttpGet(Router.Products.GetAllProducts)]
    public async Task<IActionResult> GetAllProductsAsync() =>
        CityMallResult(await Mediator.Send(new GetAllProductsQuery()));

    [HttpGet(Router.Products.GetAllProductImagesByProductId)]
    public async Task<IActionResult> GetAllProductImagesByProductIdAsync([Required][MaxLength(64)][MinLength(64)][FromQuery] string productId) =>
        CityMallResult(await Mediator.Send(new GetAllImagesProductByProductIdQuery(productId)));

    [HttpDelete(Router.Products.DeleteProductImageByImageId)]
    public async Task<IActionResult> DeleteProductImageByImageIdAsync([Required][MaxLength(64)][MinLength(64)][FromQuery] string imageId) =>
        CityMallResult(await Mediator.Send(new DeleteProductImageByIdCommand(imageId)));
}
