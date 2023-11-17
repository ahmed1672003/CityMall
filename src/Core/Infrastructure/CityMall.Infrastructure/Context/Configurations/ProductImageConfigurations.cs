
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class ProductImageConfigurations : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable(Tables.ProductImages);
    }
}
