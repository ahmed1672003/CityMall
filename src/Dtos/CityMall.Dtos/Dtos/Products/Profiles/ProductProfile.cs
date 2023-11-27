namespace CityMall.Dtos.Dtos.Products.Profiles;
public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        Map();
    }

    void Map()
    {
        CreateMap<AddProductDto, Product>()
            .AfterMap((Dto, Model) =>
            {
                Model.Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);

                if (string.IsNullOrEmpty(Model.Name))
                    Model.SKU = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
            });
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Product, GetProductDto>();
    }
}

