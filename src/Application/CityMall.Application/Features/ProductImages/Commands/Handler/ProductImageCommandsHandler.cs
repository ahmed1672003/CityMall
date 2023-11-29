using CityMall.Services.Services;

namespace CityMall.Application.Features.ProductImages.Commands.Handler;
public sealed class ProductImageCommandsHandler :
    IRequestHandler<AddProductImagesCommand, ResponseModel<string>>,
    IRequestHandler<DeleteProductImageByIdCommand, ResponseModel<string>>
{
    private readonly IUnitOfServices _services;

    public ProductImageCommandsHandler(IUnitOfServices services)
    {
        _services = services;
    }
    public async Task<ResponseModel<string>> Handle(AddProductImagesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Products.AnyUnDeletedByIdAsync(request.Dto.ProductId))
                return ResponseResult.NotFound<string>();
            await _services.ProductImages.AddRangeAsync(request.Dto, cancellationToken);
            return ResponseResult.Created<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<string>> Handle(DeleteProductImageByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.ProductImages.AnyByIdAsync(request.Id, cancellationToken))
                return ResponseResult.NotFound<string>();

            await _services.ProductImages.DeleteByIdAsync(request.Id, cancellationToken);

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
}
