namespace CityMall.Specifications.Specifications.Products;

public sealed class AsNoTrackingGetDeletedProductBySKUSpecification : Specification<Product>
{
    public AsNoTrackingGetDeletedProductBySKUSpecification(string SKU) :
        base(p => p.SKU.Equals(SKU) && p.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
