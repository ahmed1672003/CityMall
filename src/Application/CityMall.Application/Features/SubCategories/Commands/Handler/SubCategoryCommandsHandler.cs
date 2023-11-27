namespace CityMall.Application.Features.SubCategories.Commands.Handler;
public sealed class SubCategoryCommandsHandler :
    IRequestHandler<AddSubCategoryCommand, ResponseModel<string>>,
    IRequestHandler<UpdateSubCategoryCommand, ResponseModel<string>>,
    IRequestHandler<DeleteSubCategoryByIdCommand, ResponseModel<string>>
{
    private readonly IUnitOfServices _services;
    public SubCategoryCommandsHandler(IUnitOfServices services)
    {
        _services = services;
    }
    public async Task<ResponseModel<string>> Handle(AddSubCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _services.SubCategories.AddAsync(request.Dto);
            return ResponseResult.Created<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<string>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.SubCategories.AnyByIdAsync(request.Dto.Id))
                return ResponseResult.NotFound<string>();
            await _services.SubCategories.UpdateAsync(request.Dto);

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<string>> Handle(DeleteSubCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.SubCategories.AnyByIdAsync(request.Id))
                return ResponseResult.NotFound<string>();

            await _services.SubCategories.DeleteByIdAsync(request.Id);
            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
}