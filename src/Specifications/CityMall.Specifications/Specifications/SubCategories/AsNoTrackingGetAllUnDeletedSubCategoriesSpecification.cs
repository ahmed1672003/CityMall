namespace CityMall.Specifications.Specifications.SubCategories;
public sealed class AsNoTrackingGetAllUnDeletedSubCategoriesSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetAllUnDeletedSubCategoriesSpecification() : base(sc => !sc.IsDeleted)
    {
        StopTracking();
    }
}
