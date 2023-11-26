
using CityMall.Domain.Entities;
using CityMall.Specifications.Specifications.Addresses;

namespace CityMall.Application.Features.Addresses.Commands.Handler;
public sealed class AddressCommandsHandler :
    IRequestHandler<AddAddressCommand, ResponseModel<string>>,
    IRequestHandler<UpdateAddressCommand, ResponseModel<string>>,
    IRequestHandler<DeleteAddressCommand, ResponseModel<string>>
{
    #region Fields
    private readonly IUnitOfServices _services;
    private readonly ISpecificationsFactory _specificationsFactory;
    #endregion

    #region Ctor
    public AddressCommandsHandler(IUnitOfServices services, ISpecificationsFactory specificationsFactory)
    {
        _services = services;
        _specificationsFactory = specificationsFactory;
    }
    #endregion

    #region Add Address
    public async Task<ResponseModel<string>> Handle(AddAddressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _services.Addresses.AddAsync(request.Dto, cancellationToken);
            return ResponseResult.Created<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    #endregion

    #region Update Address
    public async Task<ResponseModel<string>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Address> asNoTrackingGetUnDeletedAddressByIdSpec = _specificationsFactory.CreateAddressSpecifications(typeof(AsNoTrackingGetUnDeletedAddressByIdSpecification), request.Dto.Id);

            if (!await _services.Addresses.AnyAsync(asNoTrackingGetUnDeletedAddressByIdSpec, cancellationToken))
                return ResponseResult.NotFound<string>();

            await _services.Addresses.UpdateAsync(request.Dto, cancellationToken);

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    #endregion

    #region Delete Address 
    public async Task<ResponseModel<string>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Address> asNoTrackingGetUnDeletedAddressByIdSpec = _specificationsFactory.CreateAddressSpecifications(typeof(AsNoTrackingGetUnDeletedAddressByIdSpecification), request.Id);

            if (!await _services.Addresses.AnyAsync(asNoTrackingGetUnDeletedAddressByIdSpec, cancellationToken))
                return ResponseResult.NotFound<string>();

            await _services.Addresses.DeleteByIdAsync(request.Id);

            return ResponseResult.Success<string>();
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<string>(errors: ex.Message);
        }
    }
    #endregion
}
