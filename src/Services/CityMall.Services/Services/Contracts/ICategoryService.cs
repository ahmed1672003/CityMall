using CityMall.Dtos.Dtos.Categories;

namespace CityMall.Services.Services.Contracts;
public interface ICategoryService
{
    Task AddAsync(AddCategoryDto Dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateCategoryDto Dto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<GetCategoryDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetCategoryDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetCategoryDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string id, CancellationToken cancellationToken = default);

}
