using CityMall.Dtos.Dtos.Categories;

namespace CityMall.Application.Features.Categories.Queries.Handler;
public sealed class CategoryQueriesHandler :
    IRequestHandler<GetCategoryByIdQuery, ResponseModel<GetCategoryDto>>,
    IRequestHandler<GetAllCategoriesQuery, ResponseModel<IEnumerable<GetCategoryDto>>>,
    IRequestHandler<GetAllDeletedCategoriesQuery, ResponseModel<IEnumerable<GetCategoryDto>>>,
    IRequestHandler<GetAllUnDeletedCategoriesQuery, ResponseModel<IEnumerable<GetCategoryDto>>>
{
    private readonly IUnitOfServices _services;

    public CategoryQueriesHandler(IUnitOfServices services)
    {
        _services = services;
    }
    public async Task<ResponseModel<GetCategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Categories.AnyAsync(request.Id, cancellationToken))
                return ResponseResult.NotFound<GetCategoryDto>();

            return ResponseResult.Success(await _services.Categories.GetByIdAsync(request.Id));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCategoryDto>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<IEnumerable<GetCategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Categories.GetAllAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<IEnumerable<GetCategoryDto>>> Handle(GetAllDeletedCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Categories.GetAllDeletedAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<IEnumerable<GetCategoryDto>>> Handle(GetAllUnDeletedCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Categories.GetAllUnDeletedAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(errors: ex.Message);
        }
    }
}
