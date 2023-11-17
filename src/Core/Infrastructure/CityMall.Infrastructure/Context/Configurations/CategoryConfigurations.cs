
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(Tables.Categories);
    }
}
