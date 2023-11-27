namespace CityMall.Specifications.Specifications.SubCategories;
public sealed class AsNoTrackingGetUnDeletedSubCategoryByIdSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetUnDeletedSubCategoryByIdSpecification(string id) : base(sc => sc.Id.Equals(id))
    {
        StopTracking();
    }
}
