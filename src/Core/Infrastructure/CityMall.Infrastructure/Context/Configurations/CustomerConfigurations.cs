
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(Tables.Customers);
        builder.HasQueryFilter(c => !c.IsDeleted);
    }
}
