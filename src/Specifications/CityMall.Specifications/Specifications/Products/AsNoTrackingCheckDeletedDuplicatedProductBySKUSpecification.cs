namespace CityMall.Specifications.Specifications.Products;
public sealed class AsNoTrackingCheckDeletedDuplicatedProductBySKUSpecification : Specification<Product>
{
    public AsNoTrackingCheckDeletedDuplicatedProductBySKUSpecification(string id, string SKU)
        : base(p => p.IsDeleted && p.SKU.Equals(SKU) && !p.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
