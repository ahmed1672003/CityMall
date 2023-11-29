using CityMall.Domain.Exceptions.Images;
using CityMall.Dtos.Dtos.ProductImages;
using CityMall.Services.Exceptions.Products;
using CityMall.Specifications.Specifications.ProductImages;
using CityMall.Specifications.Specifications.Products;

namespace CityMall.Services.Services;
public sealed class ProductImageService : IProductImageService
{
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    public ProductImageService(
        IFileService fileService,
        IUnitOfWork context,
        ISpecificationsFactory specificationsFactory,
        IMapper mapper)
    {
        _fileService = fileService;
        _context = context;
        _specificationsFactory = specificationsFactory;
        _mapper = mapper;
    }
    public async Task AddRangeAsync(AddProductImagesDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            _fileService.EnsureFilesSize(Dto.Images);
            _fileService.EnsureFilesExctensions(Dto.Images);

            ISpecification<Product> asNoTrackingGetUnDeletedProductByIdSpec = _specificationsFactory
                                    .CreateProductSpecifications(typeof(AsNoTrackingGetUnDeletedProductByIdSpecification), Dto.ProductId);

            List<ProductImage> productImages = new List<ProductImage>(0);


            foreach (var img in Dto.Images)
            {
                var result = await _fileService.UploadFileAsync(img, "ProductImages");
                if (!result.Success)
                    throw new InvalidUploadImageException($"Error From {nameof(ProductImageService)}.{nameof(AddRangeAsync)}");

                productImages.Add(new ProductImage()
                {
                    Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty),
                    ContentType = result.ContentType,
                    FileName = result.FileName,
                    ImageUri = result.FilePath,
                    ProductId = Dto.ProductId,
                    CreatedAt = DateTime.Now
                });
            }
            await _context.ProductImages.CreateRangeAsync(productImages, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new ProductImageCommandException($"Error From {nameof(ProductImageService)}.{nameof(AddRangeAsync)}");
        }
    }
    public async Task<IEnumerable<GetProductImageDto>> GetAllByProductIdAsync(string productId, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<ProductImage> asNoTrackingGetProductImagesByProductIdSpec = _specificationsFactory
                                        .CreateProductImageSpecifications(typeof(AsNoTrackingGetProductImagesByProductIdSpecification), productId);
            return _mapper.Map<IEnumerable<GetProductImageDto>>(await _context.ProductImages.RetrieveAllAsync(asNoTrackingGetProductImagesByProductIdSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            throw new ProductImageQueryException($"Error From {nameof(ProductImageService)}.{nameof(GetAllByProductIdAsync)}");
        }
    }
    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            ISpecification<ProductImage> asNoTrackingGetProductImageByIdSpec = _specificationsFactory
                                                        .CreateProductImageSpecifications(typeof(AsNoTrackingGetProductImageByIdSpecification), id);


            ProductImage model = await _context.ProductImages.RetrieveAsync(asNoTrackingGetProductImageByIdSpec, cancellationToken);

            var success = await _fileService.DeleteFileAsync("ProductImages", model.FileName);

            if (!success)
                throw new InvalidDeleteImageException($"Error From {nameof(ProductImageService)}.{nameof(DeleteByIdAsync)}");
            await _context.ProductImages.ExecuteDeleteAsync(asNoTrackingGetProductImageByIdSpec, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new ProductImageCommandException($"Error From {nameof(ProductImageService)}.{nameof(DeleteByIdAsync)}");
        }
    }

    public async Task<bool> AnyByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        ISpecification<ProductImage> asNoTrackingGetProductImageByIdSpec = _specificationsFactory
                                                       .CreateProductImageSpecifications(typeof(AsNoTrackingGetProductImageByIdSpecification), id);
        return await _context.ProductImages.AnyAsync(asNoTrackingGetProductImageByIdSpec, cancellationToken);
    }
}
