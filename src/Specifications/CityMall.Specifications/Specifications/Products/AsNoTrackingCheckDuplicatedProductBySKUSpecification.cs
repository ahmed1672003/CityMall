namespace CityMall.Specifications.Specifications.Products;

public sealed class AsNoTrackingCheckDuplicatedProductBySKUSpecification : Specification<Product>
{
    public AsNoTrackingCheckDuplicatedProductBySKUSpecification(string id, string SKU)
        : base(p => p.SKU.Equals(SKU) && !p.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
