namespace CityMall.Specifications.Specifications.Categories;
public sealed class AsNoTrackingGetCategoryByIdSpecification : Specification<Category>
{
    public AsNoTrackingGetCategoryByIdSpecification(string id) : base(c => c.Id.Equals(id))
    {
        StopTracking();
    }
}
