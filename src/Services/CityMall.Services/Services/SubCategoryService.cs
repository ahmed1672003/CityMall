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
    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByIdSpec = _specificationsFactory
                            .CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByIdSpecification), id);

            SubCategory model = await _context.SubCategories.RetrieveAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken);
            await _context.SubCategories.DeleteAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new SubCategoryCommandException($"Error From {nameof(SubCategoryService)}.{nameof(DeleteByIdAsync)}");
        }
    }
    public async Task UpdateAsync(UpdateSubCategoryDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByIdSpec = _specificationsFactory
                                .CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByIdSpecification), Dto.Id);
            SubCategory model = await _context.SubCategories.RetrieveAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken);
            model = _mapper.Map<SubCategory>(Dto);
            await _context.SubCategories.UpdateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            throw new SubCategoryCommandException($"Error From {nameof(SubCategoryService)}.{nameof(UpdateAsync)}");

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

    public async Task<IEnumerable<GetSubCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetAllSubCategoriesSpec = _specificationsFactory
                                .CreateSubCategorySpecifications(typeof(AsNoTrackingGetAllSubCategoriesSpecification));
            return _mapper.Map<IEnumerable<GetSubCategoryDto>>(await _context.SubCategories.RetrieveAllAsync(asNoTrackingGetAllSubCategoriesSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new SubCategoryQueryException($"Error From {nameof(SubCategoryService)}.{nameof(GetAllAsync)}");
        }
    }
    public async Task<IEnumerable<GetSubCategoryDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetAllDeletedSubCategoriesSpec = _specificationsFactory
                                        .CreateSubCategorySpecifications(typeof(AsNoTrackingGetAllDeletedSubCategoriesSpecification));
            return _mapper.Map<IEnumerable<GetSubCategoryDto>>(await _context.SubCategories.RetrieveAllAsync(asNoTrackingGetAllDeletedSubCategoriesSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new SubCategoryQueryException($"Error From {nameof(SubCategoryService)}.{nameof(GetAllDeletedAsync)}");
        }
    }
    public async Task<IEnumerable<GetSubCategoryDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetAllUnDeletedSubCategoriesSpec = _specificationsFactory
                                            .CreateSubCategorySpecifications(typeof(AsNoTrackingGetAllUnDeletedSubCategoriesSpecification));

            return _mapper.Map<IEnumerable<GetSubCategoryDto>>(await _context.SubCategories.RetrieveAllAsync(asNoTrackingGetAllUnDeletedSubCategoriesSpec, cancellationToken));

        }
        catch (Exception ex)
        {
            throw new SubCategoryQueryException($"Error From {nameof(SubCategoryService)}.{nameof(GetAllUnDeletedAsync)}");
        }
    }
    public async Task<GetSubCategoryDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByIdSpec = _specificationsFactory
                                    .CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByIdSpecification), id);
            return _mapper.Map<GetSubCategoryDto>(await _context.SubCategories.RetrieveAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new SubCategoryQueryException($"Error From {nameof(SubCategoryService)}.{nameof(GetByIdAsync)}");
        }
    }

}
