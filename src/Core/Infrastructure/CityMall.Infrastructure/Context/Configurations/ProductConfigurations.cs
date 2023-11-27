
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(Tables.Products);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
