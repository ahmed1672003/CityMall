namespace CityMall.Dtos.Dtos.Categories.Profiles;
public sealed class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<AddCategoryDto, Category>()
            .AfterMap((Dto, Model) =>
            {
                Model.Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
            });
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, GetCategoryDto>();
    }
}
