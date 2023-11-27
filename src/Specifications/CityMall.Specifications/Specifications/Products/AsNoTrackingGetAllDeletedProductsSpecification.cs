namespace CityMall.Specifications.Specifications.Products;

public sealed class AsNoTrackingGetAllDeletedProductsSpecification : Specification<Product>
{
    public AsNoTrackingGetAllDeletedProductsSpecification() : base(p => p.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
