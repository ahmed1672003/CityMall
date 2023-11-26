using CityMall.Services.Exceptions.Addresses;
using CityMall.Specifications.Specifications.Addresses;

namespace CityMall.Services.Services;
public sealed class AddressService : IAddressService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    public AddressService(IMapper mapper, IUnitOfWork context, ISpecificationsFactory specificationsFactory)
    {
        _mapper = mapper;
        _context = context;
        _specificationsFactory = specificationsFactory;
    }
    public async Task AddAsync(AddAddressDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            Address model = _mapper.Map<Address>(Dto);
            await _context.Addresses.CreateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new AddressCommandException("Error From AddressService.AddAddressAsync()", ex);
        }
    }
    public async Task UpdateAsync(UpdateAddressDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Address> asNoTrackingGetUnDeletedAddressByIdSpec = _specificationsFactory.CreateAddressSpecifications(typeof(AsNoTrackingGetUnDeletedAddressByIdSpecification), Dto.Id);
            Address model = await _context.Addresses.RetrieveAsync(asNoTrackingGetUnDeletedAddressByIdSpec, cancellationToken);
            model = _mapper.Map<Address>(Dto);
            await _context.Addresses.UpdateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new AddressCommandException("Error From AddressService.UpdateAddressAsync()", ex);
        }
    }
    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Address> asNoTrackingGetUnDeletedAddressByIdSpec = _specificationsFactory.CreateAddressSpecifications(typeof(AsNoTrackingGetUnDeletedAddressByIdSpecification), id);
            Address model = await _context.Addresses.RetrieveAsync(asNoTrackingGetUnDeletedAddressByIdSpec, cancellationToken);
            await _context.Addresses.DeleteAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new AddressQueryException("Error From AddressService.DeleteAddressByIdAsync()", ex);
        }
    }
    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default) => await _context.Addresses.AnyAsync(cancellationToken: cancellationToken);
    public async Task<bool> AnyAsync(ISpecification<Address> specification, CancellationToken cancellationToken = default) =>
        await _context.Addresses.AnyAsync(specification, cancellationToken);
    public async Task<IEnumerable<GetAddressDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return _mapper.Map<IEnumerable<GetAddressDto>>(await _context.Addresses.RetrieveAllAsync(cancellationToken: cancellationToken));
        }
        catch (Exception ex)
        {
            throw new AddressQueryException("Error From AddressService.GetAllAsync()", ex);
        }
    }
    public async Task<IEnumerable<GetAddressDto>> GetAllAsync(ISpecification<Address> specification, CancellationToken cancellationToken = default)
    {
        try
        {
            return _mapper.Map<IEnumerable<GetAddressDto>>(await _context.Addresses.RetrieveAllAsync(specification, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new AddressQueryException("Error From AddressService.GetAllAsync()", ex);
        }
    }
}
