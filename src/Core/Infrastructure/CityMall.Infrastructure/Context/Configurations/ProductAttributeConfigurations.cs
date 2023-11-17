
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class ProductAttributeConfigurations : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable(Tables.ProductAttributes);
    }
}
