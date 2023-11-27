using CityMall.Dtos.Dtos.Products;

namespace CityMall.Application.Features.Products.Queries.Handler;
public sealed class ProductQueriesHandler :
    IRequestHandler<GetProductByIdQuery, ResponseModel<GetProductDto>>,
    IRequestHandler<GetAllDeletedProductsQuery, ResponseModel<IEnumerable<GetProductDto>>>,
    IRequestHandler<GetAllUnDeletedProductsQuery, ResponseModel<IEnumerable<GetProductDto>>>,
    IRequestHandler<GetAllProductsQuery, ResponseModel<IEnumerable<GetProductDto>>>
{
    private readonly IUnitOfServices _services;

    public ProductQueriesHandler(IUnitOfServices services)
    {
        _services = services;
    }

    public async Task<ResponseModel<GetProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Products.AnyUnDeletedByIdAsync(request.Id))
                return ResponseResult.NotFound<GetProductDto>();

            return ResponseResult.Success(await _services.Products.GetByIdAsync(request.Id, cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetProductDto>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetProductDto>>> Handle(GetAllDeletedProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Products.GetAllDeletedAsync());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetProductDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetProductDto>>> Handle(GetAllUnDeletedProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Products.GetAllUnDeletedAsync());

        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetProductDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Products.GetAllAsync());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetProductDto>>(errors: ex.Message);
        }
    }
}
