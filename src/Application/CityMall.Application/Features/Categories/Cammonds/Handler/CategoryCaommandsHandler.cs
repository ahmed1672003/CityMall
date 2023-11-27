namespace CityMall.Application.Features.Categories.Cammonds.Handler;
public sealed class CategoryCaommandsHandler :
    IRequestHandler<AddCategoryCommand, ResponseModel<string>>,
    IRequestHandler<UpdateCategoryCommand, ResponseModel<string>>,
    IRequestHandler<DeleteCategoryByIdCommand, ResponseModel<string>>

{
    private readonly IUnitOfServices _services;

    public CategoryCaommandsHandler(IUnitOfServices services)
    {
        _services = services;
    }

    public async Task<ResponseModel<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _services.Categories.AddAsync(request.Dto);
            return ResponseResult.Created<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Categories.AnyByIdAsync(request.Dto.Id, cancellationToken))
                return ResponseResult.NotFound<string>();

            await _services.Categories.UpdateAsync(request.Dto, cancellationToken);
            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<string>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Categories.AnyByIdAsync(request.Id, cancellationToken))
                return ResponseResult.NotFound<string>();
            await _services.Categories.DeleteByIdAsync(request.Id, cancellationToken);
            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }

}
