using CityMall.Dtos.Dtos.Customers;

namespace CityMall.Application.Features.Customers.Queries.Handler;
public sealed class CustomerQueriesHandler
    : IRequestHandler<GetCustomerByIdQuery, ResponseModel<GetCustomerDto>>,
      IRequestHandler<GetAllCustomersQuery, ResponseModel<IEnumerable<GetCustomerDto>>>,
      IRequestHandler<GetAllUnDeletedCustomersQuery, ResponseModel<IEnumerable<GetCustomerDto>>>,
      IRequestHandler<GetAllDeletedCustomersQuery, ResponseModel<IEnumerable<GetCustomerDto>>>
{
    private readonly IUnitOfServices _services;

    public CustomerQueriesHandler(IUnitOfServices services)
    {
        _services = services;
    }

    public async Task<ResponseModel<GetCustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _services.Customers.AnyByIdAsync(request.Id, cancellationToken))
                return ResponseResult.NotFound<GetCustomerDto>();
            GetCustomerDto Dto = await _services.Customers.GetByIdAsync(request.Id, cancellationToken);
            return ResponseResult.Success(Dto);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCustomerDto>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetCustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Customers.GetAllAsync());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCustomerDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetCustomerDto>>> Handle(GetAllUnDeletedCustomersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Customers.GetAllUnDeltedAsync(cancellationToken: cancellationToken));

        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCustomerDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetCustomerDto>>> Handle(GetAllDeletedCustomersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return ResponseResult.Success(await _services.Customers.GetAllDeletedAsync(cancellationToken: cancellationToken));
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCustomerDto>>(errors: ex.Message);
        }
    }
}
