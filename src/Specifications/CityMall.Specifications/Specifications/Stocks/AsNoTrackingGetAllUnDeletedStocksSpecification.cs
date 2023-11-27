namespace CityMall.Specifications.Specifications.Stocks;

public sealed class AsNoTrackingGetAllUnDeletedStocksSpecification : Specification<Stock>
{
    public AsNoTrackingGetAllUnDeletedStocksSpecification() : base(s => !s.IsDeleted)
    {
        StopTracking();
    }
}
