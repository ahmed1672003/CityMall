using CityMall.Dtos.Dtos.SubCategories;

namespace CityMall.Application.Features.SubCategories.Queries.Handler;
public sealed class SubCategoryQueriesHandler :
    IRequestHandler<GetSubCategoryByIdQuery, ResponseModel<GetSubCategoryDto>>,
    IRequestHandler<GetAllSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<GetAllUnDeletedSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<GetAllDeletedSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>
{
    private readonly IUnitOfServices _services;

    public SubCategoryQueriesHandler(IUnitOfServices services)
    {
        _services = services;
    }

    public async Task<ResponseModel<GetSubCategoryDto>> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.SubCategories.AnyAsync(request.Id, cancellationToken))
                return ResponseResult.NotFound<GetSubCategoryDto>();
            return ResponseResult.Success(await _services.SubCategories.GetByIdAsync(request.Id, cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetSubCategoryDto>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.SubCategories.GetAllAsync(cancellationToken: cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllUnDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.SubCategories.GetAllUnDeletedAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.SubCategories.GetAllDeletedAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(errors: ex.Message);
        }
    }
}
