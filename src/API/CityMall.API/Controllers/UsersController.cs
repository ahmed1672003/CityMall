using System.ComponentModel.DataAnnotations;

using CityMall.Application.Features.Users.Commands;
using CityMall.Application.Features.Users.Queries;
using CityMall.Dtos.Enums;
using CityMall.Infrastructure.Constants;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityMall.API.Controllers;

/// <summary>
/// user services 
/// </summary>
[ApiController]
public class UsersController : CityMallController
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="mediator"></param>
    public UsersController(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// register new user
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPost(Router.User.AddUser)]
    [AllowAnonymous]
    public async Task<IActionResult> AddUser([FromForm] AddUserCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));

    /// <summary>
    /// update user data
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPut(Router.User.UpdateUser)]
    public async Task<IActionResult> UpdateUser([FromForm] UpdateUserByIdCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));


    /// <summary>
    /// login user
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPatch(Router.User.LoginUser)]
    public async Task<IActionResult> LoginUser(LoginUserCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));

    /// <summary>
    /// log out users
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPatch(Router.User.LogOutUser)]
    public async Task<IActionResult> LogOutUser(LogOutUserCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));

    /// <summary>
    /// refersh jWT for user
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    [HttpPatch(Router.User.RefreshjWT)]
    public async Task<IActionResult> RefreshjWT(RefreshjWTCommand cmd) =>
        CityMallResult(await Mediator.Send(cmd));

    /// <summary>
    /// delete user by id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPatch(Router.User.DeleteUserById)]
    public async Task<IActionResult> DeleteUserById([Required][MaxLength(64)][MinLength(64)] string userId) =>
        CityMallResult(await Mediator.Send(new DeleteUserByIdCoammnd(userId)));

    /// <summary>
    /// undo delete user by id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPatch(Router.User.UndoDeleteUserById)]
    public async Task<IActionResult> UndoDeleteUserById([Required][MaxLength(64)][MinLength(64)] string userId) =>
        CityMallResult(await Mediator.Send(new UndoDeleteUserByIdCommand(userId)));

    /// <summary>
    /// confirme email
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet(Router.User.ConfirmeEmail)]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmeEmail([Required][MaxLength(64)][MinLength(64)] string userId, [Required] string token) =>
        CityMallResult(await Mediator.Send(new ConfirmeEmailCommand(userId, token)));

    /// <summary>
    /// get all users
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.User.GetAll)]
    public async Task<IActionResult> GetAll() =>
        CityMallResult(await Mediator.Send(new GetAllUsersQuery()));

    /// <summary>
    /// get all deleted users
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.User.GetAllDeleted)]
    public async Task<IActionResult> GetAllDeleted() =>
        CityMallResult(await Mediator.Send(new GetAllDeletedUsersQuery()));

    /// <summary>
    /// get all un deleted users
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.User.GetAllUnDeleted)]
    public async Task<IActionResult> GetAllUnDeleted() =>
        CityMallResult(await Mediator.Send(new GetAllUnDeletedUsersQuery()));

    /// <summary>
    /// paginate all users
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="keyWords"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    [HttpGet(Router.User.PaginateAll)]
    public async Task<IActionResult> PaginateAll(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", UserOrderBy? orderBy = UserOrderBy.CreatedAt) =>
        CityMallResult(await Mediator.Send(new PaginateAllUsersQuery(pageNumber.Value, pageSize.Value, keyWords, orderBy.Value)));

    /// <summary>
    /// paginate all deleted users
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="keyWords"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    [HttpGet(Router.User.PaginateAllDeleted)]
    public async Task<IActionResult> PaginateAllDeleted(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", UserOrderBy? orderBy = UserOrderBy.CreatedAt) =>
        CityMallResult(await Mediator.Send(new PaginateAllDeletedUsersQuery(pageNumber.Value, pageSize.Value, keyWords, orderBy.Value)));

    /// <summary>
    /// paginate all un deleted users
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="keyWords"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    [HttpGet(Router.User.PaginateAllUnDeleted)]
    public async Task<IActionResult> PaginateAllUnDeleted(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", UserOrderBy? orderBy = UserOrderBy.CreatedAt) =>
        CityMallResult(await Mediator.Send(new PaginateAllUnDeletedUsersQuery(pageNumber.Value, pageSize.Value, keyWords, orderBy.Value)));
}
