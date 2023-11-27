namespace CityMall.Application.Features.Customers.Commands.Handler;
public sealed class CustomerCommandsHandler
    : IRequestHandler<AddCustomerCommand, ResponseModel<string>>,
     IRequestHandler<UpdateCustommerCommand, ResponseModel<string>>,
     IRequestHandler<DeleteCustomerCommand, ResponseModel<string>>
{

    private readonly IUnitOfServices _services;
    public CustomerCommandsHandler(IUnitOfServices services)
    {
        _services = services;
    }
    public async Task<ResponseModel<string>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _services.Customers.CreateAsync(request.Dto);
            return ResponseResult.Created<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<string>> Handle(UpdateCustommerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Customers.AnyByIdAsync(request.Dto.Id, cancellationToken))
                return ResponseResult.NotFound<string>();

            await _services.Customers.UpdateAsync(request.Dto, cancellationToken);
            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Customers.AnyByIdAsync(request.Id, cancellationToken))
                return ResponseResult.NotFound<string>();

            await _services.Customers.DeleteByIdAsync(request.Id, cancellationToken);

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {

            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
}
