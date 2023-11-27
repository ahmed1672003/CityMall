namespace CityMall.Specifications.Specifications.Products;

public sealed class AsNoTrackingGetUnDeletedProductBySKUSpecification : Specification<Product>
{
    public AsNoTrackingGetUnDeletedProductBySKUSpecification(string SKU)
        : base(p => p.SKU.Equals(SKU))
    {
        StopTracking();
    }
}
