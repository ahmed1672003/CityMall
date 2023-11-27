using CityMall.Application.Features.SubCategories.Commands;
using CityMall.Application.Features.SubCategories.Queries;

namespace CityMall.API.Controllers;

[AllowAnonymous]
[ApiController]
public class SubCategoryController : CityMallController
{
    public SubCategoryController(IMediator mediator) : base(mediator) { }

    [HttpPost(Router.SubCategories.AddSubCategory)]
    public async Task<IActionResult> AddSubCategoryAsync(AddSubCategoryCommand cmd) =>
            CityMallResult(await Mediator.Send(cmd));

    [HttpPut(Router.SubCategories.UpdateSubCategory)]
    public async Task<IActionResult> UpdateSubCategoryAsync(UpdateSubCategoryCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));

    [HttpPatch(Router.SubCategories.DeleteSubCategoryById)]
    public async Task<IActionResult> DeleteSubCategoryByIdAsync(string id) =>
        CityMallResult(await Mediator.Send(new DeleteSubCategoryByIdCommand(id)));

    [HttpGet(Router.SubCategories.GetSubCategoryById)]
    public async Task<IActionResult> GetSubCategoryByIdAsync(string id) =>
        CityMallResult(await Mediator.Send(new GetSubCategoryByIdQuery(id)));

    [HttpGet(Router.SubCategories.GetAllDeletedSubCategories)]
    public async Task<IActionResult> GetAllDeletedSubCategoriesAsync() =>
        CityMallResult(await Mediator.Send(new GetAllDeletedSubCategoriesQuery()));


    [HttpGet(Router.SubCategories.GetAllSubCategories)]
    public async Task<IActionResult> GetAllSubCategoriesAsync() =>
        CityMallResult(await Mediator.Send(new GetAllSubCategoriesQuery()));

    [HttpGet(Router.SubCategories.GetAllUnDeletedSubCategories)]
    public async Task<IActionResult> GetAllUnDeletedSubCategoriesAsync() =>
        CityMallResult(await Mediator.Send(new GetAllUnDeletedSubCategoriesQuery()));
}


