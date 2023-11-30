using CityMall.Dtos.Dtos.ProductImages;

namespace CityMall.Services.Services.Contracts;
public interface IProductImageService
{
    Task AddRangeAsync(AddProductImagesDto Dto, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetProductImageDto>> GetAllByProductIdAsync(string productId, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task DeleteByProductIdAsync(string productId, CancellationToken cancellationToken = default);
    Task<bool> AnyByIdAsync(string id, CancellationToken cancellationToken = default);
}
