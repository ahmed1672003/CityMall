namespace CityMall.Specifications.Specifications.Products;

public sealed class AsNoTrackingGetProductBySKUSpecification : Specification<Product>
{
    public AsNoTrackingGetProductBySKUSpecification(string SKU)
        : base(p => p.SKU.Equals(SKU))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}