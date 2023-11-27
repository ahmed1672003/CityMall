namespace CityMall.Specifications.Specifications.Categories;
public sealed class AsNoTrackingGetAllUnDeletedCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingGetAllUnDeletedCategoriesSpecification() : base()
    {
        StopTracking();
    }
}
