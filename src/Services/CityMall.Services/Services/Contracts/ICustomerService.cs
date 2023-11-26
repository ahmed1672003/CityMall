using CityMall.Dtos.Dtos.Customers;

namespace CityMall.Services.Services.Contracts;
public interface ICustomerService
{
    Task CreateAsync(AddCustomerDto Dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateCustomerDto Dto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string id, CancellationToken cancellationToken = default);
    Task<GetCustomerDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetCustomerDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetCustomerDto>> GetAllUnDeltedAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetCustomerDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default);

}
