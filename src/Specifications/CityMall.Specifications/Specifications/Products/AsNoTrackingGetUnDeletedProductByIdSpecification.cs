namespace CityMall.Specifications.Specifications.Products;
public sealed class AsNoTrackingGetUnDeletedProductByIdSpecification : Specification<Product>
{
    public AsNoTrackingGetUnDeletedProductByIdSpecification(string id)
        : base(p => p.Id.Equals(id))
    {
        StopTracking();
    }
}