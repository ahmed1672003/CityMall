namespace CityMall.Specifications.Specifications.Categories;
public sealed class AsNoTrackingGetAllDeletedCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingGetAllDeletedCategoriesSpecification() : base(c => c.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
