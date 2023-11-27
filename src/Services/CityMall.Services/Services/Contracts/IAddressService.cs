namespace CityMall.Services.Services.Contracts;
public interface IAddressService
{
    Task AddAsync(AddAddressDto Dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateAddressDto Dto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetAddressDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetAddressDto>> GetAllAsync(ISpecification<Address> specification, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyByIdAsync(string id, CancellationToken cancellationToken = default);
}