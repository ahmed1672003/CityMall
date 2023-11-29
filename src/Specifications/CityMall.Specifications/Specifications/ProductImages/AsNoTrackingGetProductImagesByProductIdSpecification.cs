namespace CityMall.Specifications.Specifications.ProductImages;
public sealed class AsNoTrackingGetProductImagesByProductIdSpecification : Specification<ProductImage>
{
    public AsNoTrackingGetProductImagesByProductIdSpecification(string productId)
        : base(pi => pi.ProductId.Equals(productId))
    {
        StopTracking();
    }
}
