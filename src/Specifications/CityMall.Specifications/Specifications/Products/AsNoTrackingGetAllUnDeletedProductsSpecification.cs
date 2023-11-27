namespace CityMall.Specifications.Specifications.Products;

public sealed class AsNoTrackingGetAllUnDeletedProductsSpecification : Specification<Product>
{
    public AsNoTrackingGetAllUnDeletedProductsSpecification() : base(p => !p.IsDeleted)
    {
        StopTracking();
    }
}
