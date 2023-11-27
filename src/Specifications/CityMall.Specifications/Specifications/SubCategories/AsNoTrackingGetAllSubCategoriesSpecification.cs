namespace CityMall.Specifications.Specifications.SubCategories;
public sealed class AsNoTrackingGetAllSubCategoriesSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetAllSubCategoriesSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
