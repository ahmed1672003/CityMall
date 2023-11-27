namespace CityMall.Dtos.Dtos.SubCategories.Profiles;
public sealed class SubCategoryProfile : Profile
{
    public SubCategoryProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<AddSubCategoryDto, SubCategory>()
            .AfterMap((Dto, Model) =>
            {
                Model.Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
            });
        CreateMap<UpdateSubCategoryDto, SubCategory>();
        CreateMap<SubCategory, GetSubCategoryDto>();
    }
}
