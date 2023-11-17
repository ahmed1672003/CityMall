namespace CityMall.Infrastructure.Context.Configurations;
public sealed class ProductAttributeMapperConfigurations : IEntityTypeConfiguration<ProductAttributeMapper>
{
    public void Configure(EntityTypeBuilder<ProductAttributeMapper> builder)
    {
        builder.ToTable(Tables.ProductAttributeMappers);
    }
}
