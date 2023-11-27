namespace CityMall.Dtos.Dtos.Stocks.Profiles;
public sealed class StockProfile : Profile
{
    public StockProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<AddStockDto, Stock>()
            .AfterMap((Dto, Src) =>
            {
                Src.Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
            });
        CreateMap<UpdateStockDto, Stock>();
        CreateMap<Stock, GetStockDto>();
    }
}
