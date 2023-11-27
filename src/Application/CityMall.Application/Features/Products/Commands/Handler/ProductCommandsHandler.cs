namespace CityMall.Application.Features.Products.Commands.Handler;
public sealed class ProductCommandsHandler :
    IRequestHandler<AddProductCommand, ResponseModel<string>>,
    IRequestHandler<UpdateProductCommand, ResponseModel<string>>,
    IRequestHandler<DeleteProductCommand, ResponseModel<string>>
{
    private readonly IUnitOfServices _services;

    public ProductCommandsHandler(IUnitOfServices services)
    {
        _services = services;
    }

    public async Task<ResponseModel<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _services.Products.AnyUnDeletedBySKUAsync(request.Dto.SKU))
                return ResponseResult.BadRequest<string>();

            if (await _services.Products.AnyDeletedBySKUAsync(request.Dto.SKU))
                return ResponseResult.Conflict<string>();

            await _services.Products.AddAsync(request.Dto);

            return ResponseResult.Created<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Products.AnyUnDeletedByIdAsync(request.Dto.Id, cancellationToken))
                return ResponseResult.NotFound<string>();

            if (await _services.Products.AnyDeletedDuplicatedBySKUAsync(request.Dto.Id, request.Dto.SKU, cancellationToken))
                return ResponseResult.Conflict<string>();

            if (await _services.Products.AnyUnDeletedDuplicatedBySKUAsync(request.Dto.Id, request.Dto.SKU, cancellationToken))
                return ResponseResult.BadRequest<string>();

            await _services.Products.UpdateAsync(request.Dto, cancellationToken);

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    public async Task<ResponseModel<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Products.AnyUnDeletedByIdAsync(request.Id, cancellationToken))
                return ResponseResult.NotFound<string>();

            await _services.Products.DeleteByIdAsync(request.Id);
            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
}
