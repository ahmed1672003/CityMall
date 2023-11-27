using CityMall.Dtos.Dtos.Stocks;

namespace CityMall.Services.Services.Contracts;
public interface IStockService
{
    Task AddAsync(AddStockDto Dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateStockDto Dto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
    Task<GetStockDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetStockDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetStockDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyByIdAsync(string id, CancellationToken cancellationToken = default);
}
