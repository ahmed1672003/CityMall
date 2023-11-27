using CityMall.Dtos.Dtos.Customers;
using CityMall.Services.Exceptions.Customers;
using CityMall.Specifications.Specifications.Customers;

namespace CityMall.Services.Services;
public sealed class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    private readonly ISpecificationsFactory _specificationsFactory;
    public CustomerService(IUnitOfWork context, IMapper mapper, ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _mapper = mapper;
        _specificationsFactory = specificationsFactory;
    }
    public async Task CreateAsync(AddCustomerDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            Customer model = _mapper.Map<Customer>(Dto);
            await _context.Customers.CreateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new CustomerCommandException("Error From CustomerService.AddCustomerAsync()", ex);
        }
    }
    public async Task UpdateAsync(UpdateCustomerDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Customer> asNoTrackingGetUnDeletedCustomerByIdSpec = _specificationsFactory
                .CreateCustomerSpecifications(typeof(AsNoTrackingGetUnDeletedCustomerByIdSpecification), Dto.Id);

            Customer model = await _context.Customers.RetrieveAsync(asNoTrackingGetUnDeletedCustomerByIdSpec, cancellationToken);
            model = _mapper.Map<Customer>(Dto);
            await _context.Customers.UpdateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new CustomerCommandException($"Error From {nameof(CustomerService)}.{nameof(UpdateAsync)}", ex);
        }
    }
    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Customer> asNoTrackingGetUnDeletedCustomerByIdSpec = _specificationsFactory.CreateCustomerSpecifications(typeof(AsNoTrackingGetUnDeletedCustomerByIdSpecification), id);
            Customer model = await _context.Customers.RetrieveAsync(asNoTrackingGetUnDeletedCustomerByIdSpec, cancellationToken);
            await _context.Customers.DeleteAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new CustomerCommandException($"Error From {nameof(CustomerService)}.{nameof(DeleteByIdAsync)}", ex);
        }
    }
    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default) =>
        await _context.Customers.AnyAsync(cancellationToken: cancellationToken);
    public async Task<bool> AnyByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        ISpecification<Customer> asNoTrackingGetUnDeletedCustomerByIdSpec = _specificationsFactory.CreateCustomerSpecifications(typeof(AsNoTrackingGetUnDeletedCustomerByIdSpecification), id);
        return await _context.Customers.AnyAsync(asNoTrackingGetUnDeletedCustomerByIdSpec, cancellationToken);
    }
    public async Task<IEnumerable<GetCustomerDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Customer> asNoTrackingGetAllCustomerSpec = _specificationsFactory.
                               CreateCustomerSpecifications(typeof(AsNoTrackingGetAllCustomerSpecification));

            return _mapper.Map<IEnumerable<GetCustomerDto>>
                (await _context.Customers.RetrieveAllAsync(asNoTrackingGetAllCustomerSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new CustomerQueryException($"Error From {nameof(CustomerService)}.{GetAllAsync}", ex);
        }
    }
    public async Task<GetCustomerDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Customer> asNoTrackingGetUnDeletedCustomerByIdSpec = _specificationsFactory
                            .CreateCustomerSpecifications(typeof(AsNoTrackingGetUnDeletedCustomerByIdSpecification), id);

            return _mapper.Map<GetCustomerDto>
                (await _context.Customers.RetrieveAsync(asNoTrackingGetUnDeletedCustomerByIdSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new CustomerQueryException($"Error From {nameof(CustomerService)}.{nameof(GetByIdAsync)}", ex);
        }
    }
    public async Task<IEnumerable<GetCustomerDto>> GetAllUnDeltedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Customer> asNoTrackingGetAllUnDeletedCustomerSpec = _specificationsFactory
                        .CreateCustomerSpecifications(typeof(AsNoTrackingGetAllUnDeletedCustomerSpecification));

            return _mapper.Map<IEnumerable<GetCustomerDto>>(await _context.Customers.RetrieveAllAsync(asNoTrackingGetAllUnDeletedCustomerSpec, cancellationToken));
        }
        catch (Exception ex)
        {

            throw new CustomerQueryException($"Error From {nameof(CustomerService)}.{nameof(GetAllUnDeltedAsync)}", ex);
        }
    }
    public async Task<IEnumerable<GetCustomerDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Customer> asNoTrackingGetAllDeletedCustomerSpec = _specificationsFactory
                        .CreateCustomerSpecifications(typeof(AsNoTrackingGetAllDeletedCustomerSpecification));

            return _mapper.Map<IEnumerable<GetCustomerDto>>(await _context.Customers.RetrieveAllAsync(asNoTrackingGetAllDeletedCustomerSpec, cancellationToken));
        }
        catch (Exception ex)
        {

            throw new CustomerQueryException($"Error From {nameof(CustomerService)}.{nameof(GetAllDeletedAsync)}", ex);
        }
    }
}
