using CityMall.Dtos.Dtos.Products;

namespace CityMall.Services.Services.Contracts;
public interface IProductService
{
    Task AddAsync(AddProductDto Dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateProductDto Dto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<GetProductDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetProductDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetProductDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyUnDeletedAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyUnDeletedByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<bool> AnyUnDeletedBySKUAsync(string SKU, CancellationToken cancellationToken = default);
    Task<bool> AnyDeletedBySKUAsync(string SKU, CancellationToken cancellationToken = default);
    Task<bool> AnyBySKUAsync(string SKU, CancellationToken cancellationToken = default);
    Task<bool> AnyDeletedDuplicatedBySKUAsync(string id, string SKU, CancellationToken cancellationToken = default);
    Task<bool> AnyUnDeletedDuplicatedBySKUAsync(string id, string SKU, CancellationToken cancellationToken = default);
    Task<bool> AnyDuplicatedBySKUAsync(string id, string SKU, CancellationToken cancellationToken = default);
}