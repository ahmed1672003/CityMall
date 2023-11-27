using CityMall.Dtos.Dtos.Products;
using CityMall.Services.Exceptions.Products;
using CityMall.Specifications.Specifications.Products;

namespace CityMall.Services.Services;
public sealed class ProductService : IProductService
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    private readonly ISpecificationsFactory _specificationsFactory;
    public ProductService(IUnitOfWork context, IMapper mapper, ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _mapper = mapper;
        _specificationsFactory = specificationsFactory;
    }
    public async Task AddAsync(AddProductDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.Products.CreateAsync(_mapper.Map<Product>(Dto), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            throw new ProductCommandException($"Error From {nameof(ProductService)}.{nameof(AddAsync)}", ex);
        }
    }
    public async Task UpdateAsync(UpdateProductDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Product> asNoTrackingGetUnDeletedProductByIdSpec = _specificationsFactory
                                    .CreateProductSpecifications(typeof(AsNoTrackingGetUnDeletedProductByIdSpecification), Dto.Id);

            Product model = await _context.Products.RetrieveAsync(asNoTrackingGetUnDeletedProductByIdSpec, cancellationToken);
            model = _mapper.Map<Product>(Dto);
            await _context.Products.UpdateAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            throw new ProductCommandException($"Error From {nameof(ProductService)}.{nameof(UpdateAsync)}", ex);
        }
    }
    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Product> asNoTrackingGetUnDeletedProductByIdSpec = _specificationsFactory
                                   .CreateProductSpecifications(typeof(AsNoTrackingGetUnDeletedProductByIdSpecification), id);

            Product model = await _context.Products.RetrieveAsync(asNoTrackingGetUnDeletedProductByIdSpec, cancellationToken);
            await _context.Products.DeleteAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            throw new ProductCommandException($"Error From {nameof(ProductService)}.{nameof(DeleteByIdAsync)}", ex);
        }
    }
    public async Task<IEnumerable<GetProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Product> asNoTrackingGetAllProductsSpec = _specificationsFactory
                                .CreateProductSpecifications(typeof(AsNoTrackingGetAllProductsSpecification));

            return _mapper.Map<IEnumerable<GetProductDto>>(await _context.Products.RetrieveAllAsync(asNoTrackingGetAllProductsSpec, cancellationToken));
        }
        catch (Exception ex)
        {

            throw new ProductQueryException($"Error From {nameof(ProductService)}.{nameof(GetAllAsync)}", ex);
        }
    }
    public async Task<IEnumerable<GetProductDto>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Product> asNoTrackingGetAllDeletedProductsSpec = _specificationsFactory
                               .CreateProductSpecifications(typeof(AsNoTrackingGetAllDeletedProductsSpecification));

            return _mapper.Map<IEnumerable<GetProductDto>>(await _context.Products.RetrieveAllAsync(asNoTrackingGetAllDeletedProductsSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new ProductQueryException($"Error From {nameof(ProductService)}.{nameof(GetAllDeletedAsync)}", ex);
        }
    }
    public async Task<IEnumerable<GetProductDto>> GetAllUnDeletedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Product> asNoTrackingGetAllUnDeletedProductsSpec = _specificationsFactory
                              .CreateProductSpecifications(typeof(AsNoTrackingGetAllUnDeletedProductsSpecification));

            return _mapper.Map<IEnumerable<GetProductDto>>(await _context.Products.RetrieveAllAsync(asNoTrackingGetAllUnDeletedProductsSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new ProductQueryException($"Error From {nameof(ProductService)}.{nameof(GetAllUnDeletedAsync)}", ex);
        }
    }
    public async Task<GetProductDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<Product> asNoTrackingGetUnDeletedProductByIdSpec = _specificationsFactory
                           .CreateProductSpecifications(typeof(AsNoTrackingGetUnDeletedProductByIdSpecification), id);

            return _mapper.Map<GetProductDto>(await _context.Products.RetrieveAsync(asNoTrackingGetUnDeletedProductByIdSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new ProductQueryException($"Error From {nameof(ProductService)}.{nameof(GetByIdAsync)}", ex);
        }
    }
    public async Task<bool> AnyUnDeletedAsync(CancellationToken cancellationToken = default) =>
       await _context.Products.AnyAsync(cancellationToken: cancellationToken);
    public async Task<bool> AnyUnDeletedByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        ISpecification<Product> asNoTrackingGetUnDeletedProductByIdSpec = _specificationsFactory
                                    .CreateProductSpecifications(typeof(AsNoTrackingGetUnDeletedProductByIdSpecification), id);
        return await _context.Products.AnyAsync(asNoTrackingGetUnDeletedProductByIdSpec, cancellationToken);
    }
    public async Task<bool> AnyUnDeletedBySKUAsync(string SKU, CancellationToken cancellationToken = default)
    {
        ISpecification<Product> asNoTrackingGetUnDeletedProductBySKUSpec = _specificationsFactory
                                    .CreateProductSpecifications(typeof(AsNoTrackingGetUnDeletedProductBySKUSpecification), SKU);
        return await _context.Products.AnyAsync(asNoTrackingGetUnDeletedProductBySKUSpec, cancellationToken);
    }
    public async Task<bool> AnyDeletedBySKUAsync(string SKU, CancellationToken cancellationToken = default)
    {
        ISpecification<Product> asNoTrackingGetDeletedProductBySKUSpec = _specificationsFactory
                                    .CreateProductSpecifications(typeof(AsNoTrackingGetDeletedProductBySKUSpecification), SKU);
        return await _context.Products.AnyAsync(asNoTrackingGetDeletedProductBySKUSpec, cancellationToken);
    }
    public async Task<bool> AnyBySKUAsync(string SKU, CancellationToken cancellationToken = default)
    {

        ISpecification<Product> asNoTrackingGetProductBySKUSpec = _specificationsFactory
                                    .CreateProductSpecifications(typeof(AsNoTrackingGetProductBySKUSpecification), SKU);
        return await _context.Products.AnyAsync(asNoTrackingGetProductBySKUSpec, cancellationToken);
    }
    public async Task<bool> AnyDeletedDuplicatedBySKUAsync(string id, string SKU, CancellationToken cancellationToken = default)
    {
        ISpecification<Product> asNoTrackingCheckDeletedDuplicatedProductBySKUSpec = _specificationsFactory
                                   .CreateProductSpecifications(typeof(AsNoTrackingCheckDeletedDuplicatedProductBySKUSpecification), id, SKU);

        return await _context.Products.AnyAsync(asNoTrackingCheckDeletedDuplicatedProductBySKUSpec, cancellationToken);
    }
    public async Task<bool> AnyUnDeletedDuplicatedBySKUAsync(string id, string SKU, CancellationToken cancellationToken = default)
    {
        ISpecification<Product> asNoTrackingCheckUnDeletedDuplicatedProductBySKUSpec = _specificationsFactory
                                .CreateProductSpecifications(typeof(AsNoTrackingCheckUnDeletedDuplicatedProductBySKUSpecification), id, SKU);
        return await _context.Products.AnyAsync(asNoTrackingCheckUnDeletedDuplicatedProductBySKUSpec, cancellationToken);
    }
    public async Task<bool> AnyDuplicatedBySKUAsync(string id, string SKU, CancellationToken cancellationToken = default)
    {

        ISpecification<Product> asNoTrackingCheckDuplicatedProductBySKUSpec = _specificationsFactory
                                .CreateProductSpecifications(typeof(AsNoTrackingCheckDuplicatedProductBySKUSpecification), id, SKU);
        return await _context.Products.AnyAsync(asNoTrackingCheckDuplicatedProductBySKUSpec, cancellationToken);
    }
}
