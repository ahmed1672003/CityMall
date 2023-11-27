namespace CityMall.Specifications.Specifications.Categories;
public sealed class AsNoTrackingGetUnDeletedCategoryByIdSpecification : Specification<Category>
{
    public AsNoTrackingGetUnDeletedCategoryByIdSpecification(string id) : base(c => c.Id.Equals(id))
    {
        StopTracking();
    }
}
