using CityMall.Dtos.Dtos.Files;

namespace CityMall.Dtos.Dtos.ProductImages.Profiles;
public sealed class ProductImageProfile : Profile
{
    public ProductImageProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<ProductImage, GetProductImageDto>();
        CreateMap<UploadFileResultDto, ProductImage>()
            .AfterMap((result, img) =>
            {
                img.Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
            })
            .ForMember(image => image.ImageUri,
            cfg => cfg.MapFrom(dist => dist.FilePath));
    }
}
