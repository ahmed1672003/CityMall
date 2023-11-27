using CityMall.Dtos.Dtos.SubCategories;
using CityMall.Services.Exceptions.SubCategories;
using CityMall.Specifications.Specifications.SubCategories;

namespace CityMall.Services.Services;
public sealed class SubCategoryService : ISubCategoryService
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    private readonly ISpecificationsFactory _specificationsFactory;

    public SubCategoryService(IUnitOfWork context, IMapper mapper, ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _mapper = mapper;
        _specificationsFactory = specificationsFactory;
    }

    public async Task AddAsync(AddSubCategoryDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SubCategories.CreateAsync(_mapper.Map<SubCategory>(Dto), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new SubCategoryCommandException($"Error From {nameof(SubCategoryService)}.{nameof(AddAsync)}");
        }
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default) =>
        await _context.SubCategories.AnyAsync(cancellationToken: cancellationToken);

    public async Task<bool> AnyAsync(string id, CancellationToken cancellationToken = default)
    {
        ISpecification<SubCategory> asNoTrackingGetSubCategoryByIdSpec = _specificationsFactory
                        .CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByIdSpecification), id);

        return await _context.SubCategories.AnyAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken);
    }
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<GetSubCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetSubCategoryDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetSubCategoryDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GetSubCategoryDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateSubCategoryDto Dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
