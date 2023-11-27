
using CityMall.Application.Features.Categories.Cammonds;
using CityMall.Application.Features.Categories.Queries;

namespace CityMall.API.Controllers;
/// <summary>
/// 
/// </summary>
[ApiController]
[AllowAnonymous]
public class CategoryController : CityMallController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public CategoryController(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPost(Router.Categories.AddCategory)]
    public async Task<IActionResult> AddCategoryAsync([FromForm] AddCategoryCommand cmd) => CityMallResult(await Mediator.Send(cmd));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPut(Router.Categories.UpdateCategory)]
    public async Task<IActionResult> UpdateCategoryAsync([FromForm] UpdateCategoryCommand cmd) => CityMallResult(await Mediator.Send(cmd));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    [HttpPatch(Router.Categories.DeleteCategoryById)]
    public async Task<IActionResult> DeleteCategoryByIdAsync([MaxLength(64)][MinLength(64)] string categoryId) =>
        CityMallResult(await Mediator.Send(new DeleteCategoryByIdCommand(categoryId)));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    [HttpGet(Router.Categories.GetCategoryById)]
    public async Task<IActionResult> GetCategoryByIdAsync([FromQuery][MaxLength(64)][MinLength(64)] string categoryId) =>
        CityMallResult(await Mediator.Send(new GetCategoryByIdQuery(categoryId)));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.Categories.GetAllCategories)]
    public async Task<IActionResult> GetAllCategoriesAsync() => CityMallResult(await Mediator.Send(new GetAllCategoriesQuery()));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.Categories.GetAllUnDeletedCategories)]
    public async Task<IActionResult> GetAllUnDeletedCategoriesAsync() => CityMallResult(await Mediator.Send(new GetAllUnDeletedCategoriesQuery()));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.Categories.GetAllDeletedCategories)]
    public async Task<IActionResult> GetAllDeletedCategoriesAsync() => CityMallResult(await Mediator.Send(new GetAllDeletedCategoriesQuery()));
}
