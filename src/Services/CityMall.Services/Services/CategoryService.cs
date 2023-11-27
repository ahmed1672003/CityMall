using CityMall.Dtos.Dtos.Categories;
using CityMall.Services.Exceptions.Categories;
using CityMall.Specifications.Specifications.Categories;

namespace CityMall.Services.Services;
public sealed class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    private readonly ISpecificationsFactory _specificationsFactory;
    public CategoryService(IUnitOfWork context, IMapper mapper, ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _mapper = mapper;
        _specificationsFactory = specificationsFactory;
    }

    public async Task AddAsync(AddCategoryDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.Categories.CreateAsync(_mapper.Map<Category>(Dto), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new CategoryCommandException($"Error From {nameof(CategoryService)}.{nameof(AddAsync)}", ex);
        }
    }

    public async Task UpdateAsync(UpdateCategoryDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory
                                        .CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), Dto.Id);
            Category model = await _context.Categories.RetrieveAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken);
            model = _mapper.Map<Category>(Dto);
            await _context.Categories.UpdateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new CategoryCommandException($"Error From {nameof(CategoryService)}.{nameof(UpdateAsync)}", ex);
        }
    }
    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory
                                        .CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), id);

            Category model = await _context.Categories.RetrieveAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken);
            await _context.Categories.DeleteAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new CategoryCommandException($"Error From {nameof(CategoryService)}.{nameof(DeleteByIdAsync)}", ex);
        }
    }
    public async Task<GetCategoryDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory
                                      .CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), id);
            return _mapper.Map<GetCategoryDto>(await _context.Categories.RetrieveAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new CategoryQueryException($"Error From {nameof(CategoryService)}.{nameof(GetByIdAsync)}", ex);
        }
    }

    public async Task<IEnumerable<GetCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetAllCategoriesSpec = _specificationsFactory
                                        .CreateCategorySpecifications(typeof(AsNoTrackingGetAllCategoriesSpecification));
            return _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(asNoTrackingGetAllCategoriesSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new CategoryQueryException($"Error From {nameof(CategoryService)}.{nameof(GetAllAsync)}", ex);
        }
    }

    public async Task<IEnumerable<GetCategoryDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetAllUnDeletedCategoriesSpec = _specificationsFactory
                                        .CreateCategorySpecifications(typeof(AsNoTrackingGetAllUnDeletedCategoriesSpecification));
            return _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(asNoTrackingGetAllUnDeletedCategoriesSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new CategoryQueryException($"Error From {nameof(CategoryService)}.{nameof(GetAllUnDeletedAsync)}", ex);
        }
    }
    public async Task<IEnumerable<GetCategoryDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetAllDeletedCategoriesSpec = _specificationsFactory
                                        .CreateCategorySpecifications(typeof(AsNoTrackingGetAllDeletedCategoriesSpecification));
            return _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(asNoTrackingGetAllDeletedCategoriesSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new CategoryQueryException($"Error From {nameof(CategoryService)}.{nameof(GetAllDeletedAsync)}", ex);
        }
    }
    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default) => await _context.Categories.AnyAsync(cancellationToken: cancellationToken);
    public async Task<bool> AnyAsync(string id, CancellationToken cancellationToken = default)
    {
        ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), id);

        return await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken);
    }
}
