namespace CityMall.Specifications.Specifications.SubCategories;
public sealed class AsNoTrackingGetAllDeletedSubCategoriesSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetAllDeletedSubCategoriesSpecification() : base(sc => sc.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
