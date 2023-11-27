namespace CityMall.Specifications.Specifications.Categories;
public sealed class AsNoTrackingGetAllCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingGetAllCategoriesSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
