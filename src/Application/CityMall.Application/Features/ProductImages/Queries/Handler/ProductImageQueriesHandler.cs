using CityMall.Dtos.Dtos.ProductImages;

namespace CityMall.Application.Features.ProductImages.Queries.Handler;
public sealed class ProductImageQueriesHandler :
    IRequestHandler<GetAllImagesProductByProductIdQuery, ResponseModel<IEnumerable<GetProductImageDto>>>
{
    private readonly IUnitOfServices _services;

    public ProductImageQueriesHandler(IUnitOfServices services)
    {
        _services = services;
    }

    public async Task<ResponseModel<IEnumerable<GetProductImageDto>>> Handle(GetAllImagesProductByProductIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Products.AnyUnDeletedByIdAsync(request.ProductId, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetProductImageDto>>();
            return ResponseResult.Success(await _services.ProductImages.GetAllByProductIdAsync(request.ProductId, cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetProductImageDto>>(errors: ex.Message);
        }
    }
}
