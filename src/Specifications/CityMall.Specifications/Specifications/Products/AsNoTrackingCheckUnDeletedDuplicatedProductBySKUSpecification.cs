namespace CityMall.Specifications.Specifications.Products;

public sealed class AsNoTrackingCheckUnDeletedDuplicatedProductBySKUSpecification : Specification<Product>
{
    public AsNoTrackingCheckUnDeletedDuplicatedProductBySKUSpecification(string id, string SKU)
        : base(p => p.SKU.Equals(SKU) && !p.Id.Equals(id))
    {
        StopTracking();
    }
}
