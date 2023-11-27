using CityMall.Dtos.Dtos.SubCategories;

namespace CityMall.Services.Services.Contracts;
public interface ISubCategoryService
{
    Task AddAsync(AddSubCategoryDto Dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateSubCategoryDto Dto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<GetSubCategoryDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetSubCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetSubCategoryDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetSubCategoryDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string id, CancellationToken cancellationToken = default);
}
