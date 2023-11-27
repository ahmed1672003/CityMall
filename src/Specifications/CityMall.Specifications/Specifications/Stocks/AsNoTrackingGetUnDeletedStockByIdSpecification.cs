namespace CityMall.Specifications.Specifications.Stocks;
public sealed class AsNoTrackingGetUnDeletedStockByIdSpecification : Specification<Stock>
{
    public AsNoTrackingGetUnDeletedStockByIdSpecification(string id)
        : base(s => s.Id.Equals(id))
    {
        StopTracking();
    }
}
