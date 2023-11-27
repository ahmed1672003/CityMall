
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class StockConfigurations : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable(Tables.Stocks);
        builder.HasQueryFilter(s => !s.IsDeleted);
    }
}
